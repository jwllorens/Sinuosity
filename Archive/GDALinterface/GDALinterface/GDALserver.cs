using System.Diagnostics;
using System.Text.Json;
using PipeHandler;

namespace GDALinterface
{
    public partial class GDALserver : NamedPipeServer
    {
        private string _pingCommandId;
        private bool _pinged = false;
        private bool _ponged = false;
        public string ClientExecutablePath { get; private set; }
        public bool ClientReady { get; private set; } = false;
        public bool ConnectionDropped { get; private set; } = false; // Flag to indicate if the connection is dropped
        public event EventHandler<CommandRequest_Received_EventArgs> Ping;
        public event EventHandler<CommandResult_Received_EventArgs> Pong;
        public event EventHandler<EventArgs> ClientReadyToProcess;
        public event EventHandler<CommandResult_Received_EventArgs> ListCommands_ResultReceived;
        public GDALserver(string name, String hostPath, Action<string> log = null) : base(name, log)
        {
            ClientExecutablePath = hostPath;
            ServerStarted += GDALserver_ServerStarted;
            Message_Received += GDALserver_MessageReceived;
            Ping += GDALserver_Ping; // Subscribe to the Ping event
            Pong += GDALserver_Pong; // Subscribe to the Pong event
            ClientReadyToProcess += GDALserver_ClientReadyToProcess; // Subscribe to the ClientReadyToProcess event
            Disconnected += GDALserver_ClientDisconnected; // Subscribe to the ClientDisconnected event
        }
        private async void GDALserver_MessageReceived(object sender, Message_Received_EventArgs e)
        {
            try
            {
                // Deserialize the incoming message
                var message = JsonSerializer.Deserialize<MessageBase>(e.Message);
                string messageId = message.Id;  // Go ahead and grab the ID in case we need it

                switch (message.Type.ToLower())
                {
                    case "commandrequest": //first case, command request.  The server doesn't answer to many commands but we need to handle it anyways

                        if (string.IsNullOrEmpty(messageId))  //All command requests must have a GUID to map result responses back to them.  Exit if ID is null
                        {
                            if (!(Log == null)) Log($"Received Command Request with invalid ID. Discarding.\r\n");
                            return;
                        }

                        CommandRequest commandRequest = JsonSerializer.Deserialize<CommandRequest>(e.Message); //If we made it here, it's a command request with an ID.  Deserialize it again as the proper type. 
                        LogCommandRequest(commandRequest, "Received");  //Here we figure out what command is being requested.

                        switch (commandRequest.Command.ToLower())
                        {
                            case "ping":  //Basic ping command.  
                                await SendCommandResult(messageId, commandRequest.Command, "success", null, "pong");
                                Ping?.Invoke(this, new CommandRequest_Received_EventArgs(e.Message));
                                break;
                            default:  //If we made it here, we don't know what the command is.  Send an error message back to the client.
                                await SendCommandResponse(messageId, commandRequest.Command, "error", $"Unknown command: {commandRequest.Command}");
                                break;
                        }
                        return;

                    case "commandresponse":  //If the message is a command response, we need to generate some basic logging, invoke an event, and then ignore it.  The server doesn't respond to command responses.

                        if (string.IsNullOrEmpty(messageId))  //check if the command response has an ID.  If it doesn't, we can't map it back to a request, so ignore it. 
                        {
                            if (!(Log == null)) Log($"Received Command Response with invalid ID. Discarding.\r\n");
                            return;
                        }
                        LogCommandResponse(JsonSerializer.Deserialize<CommandResponse>(e.Message), "Received");
                        break;
                    case "commandprogress":

                        if (string.IsNullOrEmpty(messageId))
                        {
                            if (!(Log == null)) Log($"Received Command Progress with invalid ID. Discarding.\r\n");
                            return;
                        }
                        LogCommandProgress(JsonSerializer.Deserialize<CommandProgress>(e.Message), "Received");
                        break; // Ignore ProgressResponse messages
                    case "commandresult":

                        if (string.IsNullOrEmpty(messageId))
                        {
                            if (!(Log == null)) Log($"Received Command Result with invalid ID. Discarding.\r\n");
                            break;
                        }
                        CommandResult commandResult = JsonSerializer.Deserialize<CommandResult>(e.Message); //If we made it here, it's a command result with an ID.  Deserialize it again as the proper type.
                        LogCommandResult(JsonSerializer.Deserialize<CommandResult>(e.Message), "Received");
                        switch (commandResult.Command.ToLower())
                        {
                            case "ping":  //Basic ping command.  
                                Pong?.Invoke(this, new CommandResult_Received_EventArgs(e.Message));
                                break;
                            case "listcommands":
                                ListCommands_ResultReceived?.Invoke(this, new CommandResult_Received_EventArgs(e.Message));
                                break;
                            default:  //If we made it here, we don't know what the command is.  Send an error message back to the client.
                                _CommandResult_EventInvoker(e);
                                break;
                        }
                        break; // Ignore CommandResponse messages
                    default:
                        if (!(Log == null))
                            if (!(Log == null)) Log($"Received invalid message type: {message.Type}");
                        await Send(JsonSerializer.Serialize(new CommandResponse(messageId, null, "error", $"Invalid message type: {message.Type}")));
                        break;
                }
            }
            catch (JsonException ex)
            {
                if (!(Log == null)) Log($"Invalid JSON: {ex.Message}");
                await Send(JsonSerializer.Serialize(new GenericMessage(null, $"Error: Invalid JSON: {ex.Message}")));
            }
            catch (Exception ex)
            {
                if (!(Log == null)) Log($"Error processing message: {ex.Message}");
                await Send(JsonSerializer.Serialize(new GenericMessage(null, $"Error: {ex.Message}")));
            }
        }
        private async void GDALserver_Ping(object sender, CommandRequest_Received_EventArgs e)
        {
            if (!_pinged)
            {
                _pingCommandId = Guid.NewGuid().ToString(); // Generate a new GUID for the ping command
                await SendCommandRequest(_pingCommandId, "ping", null);
                _pinged = true; // Set the pinged flag to true
            }
        }
        private async void GDALserver_Pong(object sender, CommandResult_Received_EventArgs e)
        {
            if (_pinged)
            { 
                if (!_ponged)
                {
                    if (e.Message.Id == _pingCommandId)
                    {
                        _ponged = true;
                        ClientReady = true; // Set the client ready flag to true
                        ClientReadyToProcess?.Invoke(this, EventArgs.Empty); // Invoke the event to indicate the client is ready to process
                    }
                }
            }
        }
        private void GDALserver_ClientReadyToProcess(object sender, EventArgs e)
        {
            // Handle the event when the client is ready to process
            if (!(Log == null)) Log("GDAL host is ready to process commands.\r\n");
        }
        private async void GDALserver_ServerStarted(object sender, EventArgs e)
        {
            ConnectionDropped = false; // Reset the connection dropped flag
            await StartClientProcess();
        }
        private async Task StartClientProcess()
        {
            //return;
            if (!File.Exists(ClientExecutablePath))
            {
                if (!(Log == null)) Log($"Error: GDAL host executable not found at {ClientExecutablePath}");
                return;
            }

            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = ClientExecutablePath,
                    UseShellExecute = true, // Run as independent process
                    CreateNoWindow = false // Visible window for debugging
                };

                if (!(Log == null)) Log("Starting GDAL host process...");

                Process.Start(startInfo);

                // Wait for client to ping the server
                if (!await WaitForClientReady(50000))
                {
                    if (!(Log == null)) Log("Error: Failure to establish communication with client executable within 5 seconds");
                }
            }
            catch (Exception ex)
            {
                if (!(Log == null)) Log($"Error starting GDALclient process: {ex.Message}");
            }
        }
        private async Task<bool> WaitForClientReady(int timeoutMs)
        {
            var start = DateTime.Now;
            while (!ClientReady && (DateTime.Now - start).TotalMilliseconds < timeoutMs)
            {
                await Task.Delay(100);
            }
            return ClientReady;
        }
        private async void GDALserver_ClientDisconnected(object sender, EventArgs e)
        {
            if (!(Log == null)) Log("GDAL host disconnected.\r\n");
            ClientReady = false; // Reset the client ready flag
            _pinged = false; // Reset the pinged flag
            _ponged = false; // Reset the ponged flag
            _pingCommandId = null; // Reset the ping command ID
            ConnectionDropped = true; // Set the connection dropped flag
        }
        public override async Task Start()
        {
            if (!(Log == null)) Log("Starting GDAL interface...");
            await _start();
        }
        protected override void pipeServer_ServersStarted(object sender, EventArgs e)
        {
            if (!(Log == null)) Log("GDAL interface started.");
        }
        protected override void pipeServer_ClientConnected(object sender, EventArgs e)
        {
            if (!(Log == null)) Log("GDAL host connected.\r\n");
        }
    }
}