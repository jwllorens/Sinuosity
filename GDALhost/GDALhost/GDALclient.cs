using System.Text.Json;
using PipeHandler;

namespace GDALIPC
{
    public partial class GDALhost : NamedPipeClient
    {
        private static readonly Dictionary<string, string> _supportedCommands = new Dictionary<string, string>();
        private Guid _pingId = Guid.Empty;

        [AttributeUsage(AttributeTargets.Method)]
        public class CalculationMethodAttribute : System.Attribute
        {
            public string CallPattern { get; }

            public CalculationMethodAttribute(string callPattern)
            {
                CallPattern = callPattern;
            }
        }
        public static IReadOnlyDictionary<string, string> GetCalculationMethods()
        {
            return _supportedCommands.AsReadOnly();
        }
        public GDALhost(string name, Action<string> log = null) : base(name, log)
        {
            ClientStarted += GDALhost_HostStarted;
            ConnectedToServer += GDALhost_HostConnected;
            Disconnected += GDALhost_Disconnected;

            Message_Received += GDALhost_MessageReceived;

            CommandRequest_Received += GDALhost_CommandRequest_Received;
            CommandResponse_Received += GDALhost_CommandResponse_Received;
            CommandProgress_Received += GDALhost_CommandProgress_Received;
            CommandResult_Received += GDALhost_CommandResult_Received;
            GenericMessage_Received += GDALhost_GenericMessage_Received;
        }
        static GDALhost()
        {
            var methods = typeof(GDALhost)
                .GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static)
                .Where(m => m.GetCustomAttributes(typeof(CalculationMethodAttribute), false).Any());

            foreach (var method in methods)
            {
                var attribute = (CalculationMethodAttribute)method.GetCustomAttributes(typeof(CalculationMethodAttribute), false).First();
                if (!_supportedCommands.ContainsKey(method.Name))
                {
                    _supportedCommands[method.Name] = attribute.CallPattern;
                }
                else
                {
                    throw new InvalidOperationException($"Duplicate calculation method: {method.Name}");
                }
            }
        }
        public string GetSupportedCommands()
        {
            string commands = "";
            foreach (var kvp in GetCalculationMethods())
            {
                commands = commands + $"\r\n\t\t{kvp.Key} : arguments = {kvp.Value}";
            }
            return ($"Supported commands (as JSON):{commands}");
        }
      
        private void GDALhost_HostStarted(object sender, EventArgs e)
        {
        }
        private async void GDALhost_HostConnected(object sender, EventArgs e)
        {
            _pingId = await SendCommandRequest("ping", new string[] { });
        }
        private async void GDALhost_GenericMessage_Received(object sender, GenericMessage_Received_EventArgs e)
        {
            if (e.Message.Id == Guid.Empty)
            {
                if (!(Log == null)) Log($"Received Generic Message with invalid ID. Discarding.\r\n");
                return;
            }
            if (!(Log == null)) LogGenericMessage(e.Message, "Received");
        }
        private async void GDALhost_CommandRequest_Received(object sender, CommandRequest_Received_EventArgs e)
        {
            if (e.Message.Id == Guid.Empty)
            {
                if (!(Log == null)) Log($"Received Command Request with invalid ID. Discarding.\r\n");
                return;
            }
            if (!(Log == null)) LogCommandRequest(e.Message, "Received");
            switch (e.Message.Command.ToLower())
            {
                case "ping":
                    await SendCommandResult(e.Message.Id, e.Message.Command, "success", null, "pong");
                    break;
                case "shutdown":
                    await SendCommandResult(e.Message.Id, e.Message.Command, "success", null, "Shutting down...");
                    Dispose();
                    Environment.Exit(0);
                    break;
                case "listcommands":
                    await SendCommandResult(e.Message.Id, e.Message.Command, "success", null, GetSupportedCommands());
                    break;
                default:
                    ProcessCommand(e.Message);
                    break;
            }
            return;
        }
        private async void GDALhost_CommandResponse_Received(object sender, CommandResponse_Received_EventArgs e)
        {
            if (e.Message.Id == Guid.Empty)
            {
                if (!(Log == null)) Log($"Received Command Response with invalid ID. Discarding.\r\n");
                return;
            }
            if (!(Log == null)) LogCommandResponse(e.Message, "Received");
        }
        private async void GDALhost_CommandProgress_Received(object sender, CommandProgress_Received_EventArgs e)
        {
            if (e.Message.Id == Guid.Empty)
            {
                if (!(Log == null)) Log($"Received Command Progress with invalid ID. Discarding.\r\n");
                return;
            }
            if (!(Log == null)) LogCommandProgress(e.Message, "Received");
        }
        private async void GDALhost_CommandResult_Received(object sender, CommandResult_Received_EventArgs e)
        {
            if (e.Message.Id == Guid.Empty)
            {
                if (!(Log == null)) Log($"Received Command Result with invalid ID. Discarding.\r\n");
                return;
            }
            if (!(Log == null)) LogCommandResult(e.Message, "Received");
        }
        private async void GDALhost_MessageReceived(object sender, Message_Received_EventArgs e)
        {
            try
            {
                var message = JsonSerializer.Deserialize<MessageBase>(e.Message);
                Guid messageId = message.Id;
                if (message.Type != "GenericMessage" && message.Type != "CommandRequest" && message.Type != "CommandResponse" && message.Type != "CommandProgress" && message.Type != "CommandResult")
                {
                    if (!(Log == null)) Log($"Received invalid message type: {message.Type}");
                    await Send(JsonSerializer.Serialize(new CommandResponse(messageId, null, "error", $"Invalid message type: {message.Type}")));
                    return;
                }
            }
            catch (JsonException ex)
            {
                if (!(Log == null)) Log($"Invalid JSON: {ex.Message}");
                await Send(JsonSerializer.Serialize(new CommandResponse(Guid.Empty, null, "error", $"Invalid JSON: {ex.Message}")));
            }
            catch (Exception ex)
            {
                if (!(Log == null)) Log($"Error processing message: {ex.Message}");
                await Send(JsonSerializer.Serialize(new CommandResponse(Guid.Empty, null, "error", $"Error: {ex.Message}")));
            }
        }
        private async void GDALhost_Disconnected(object sender, EventArgs e)
        {
            Dispose();
            Task.Delay(1000).Wait(); // Wait for 1 second before exiting
            Environment.Exit(0); // Failsafe to terminate client process
        }
        public override async Task Connect()
        {
            if (!(Log == null)) Log("Starting GDAL host...");
            await _connect();
        }
        protected override void pipeClient_ClientStarted(object sender, EventArgs e)
        {
            if (!(Log == null)) Log("GDAL host started.");
        }
        protected override void pipeClient_ClientConnected(object sender, EventArgs e)
        {
            if (!(Log == null)) Log("GDAL host connected.\r\n");
        }
        protected override void pipeClient_Disconnected(object sender, EventArgs e)
        {
            if (!(Log == null)) Log("GDAL host disconnected.\r\n");
        }
        protected override void _logConnectionAttempt()
        {
            if (!(Log == null)) Log("Attempting to connect to GDAL interface...");
        }
    }
}