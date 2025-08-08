using System.Text;
using System.IO.Pipes;
using System.Text.Json;
using System;
using System.Threading.Tasks;

namespace PipeHandler
{
    public interface IPCConnection : IDisposable
    {
        Task Send(string message);
        event EventHandler Disconnected;
        event EventHandler<Message_Received_EventArgs> Message_Received;
    }
    public interface IServer : IPCConnection
    {
        Task Start();
        event EventHandler ServerStarted;
        event EventHandler ClientConnected;
    }
    public interface IClient : IPCConnection
    {
        Task Connect();
        event EventHandler ConnectedToServer;
        event EventHandler ClientStarted;
    }
    public abstract class NamedPipeBase<T> : IPCConnection
        where T : System.IO.Pipes.PipeStream
    {
        public Action<string> Log;
        protected readonly string _name;
        protected T Pipe;
        private StreamString _stream;
        public bool Connected => (Pipe != null && Pipe.IsConnected);
        public NamedPipeBase(string pipeName, Action<string> log = null)
        {
            Log = log;
            _name = pipeName;
        }
        public event EventHandler Disconnected;
        private void OnDisconnected()
        {
            Disconnected?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler<Message_Received_EventArgs> Message_Received;
        public event EventHandler<GenericMessage_Received_EventArgs> GenericMessage_Received;
        public event EventHandler<CommandRequest_Received_EventArgs> CommandRequest_Received;
        public event EventHandler<CommandResponse_Received_EventArgs> CommandResponse_Received;
        public event EventHandler<CommandProgress_Received_EventArgs> CommandProgress_Received;
        public event EventHandler<CommandResult_Received_EventArgs> CommandResult_Received;
        private void OnMessageReceived(string message)
        {
            Message_Received?.Invoke(this, new Message_Received_EventArgs(message));
            if (!(string.IsNullOrEmpty(message)))
            {
                var messageType = JsonSerializer.Deserialize<MessageBase>(message);
                switch (messageType.Type)
                {
                    case "GenericMessage":
                        GenericMessage_Received?.Invoke(this, new GenericMessage_Received_EventArgs(message));
                        break;
                    case "CommandRequest":
                        CommandRequest_Received?.Invoke(this, new CommandRequest_Received_EventArgs(message));
                        break;
                    case "CommandResponse":
                        CommandResponse_Received?.Invoke(this, new CommandResponse_Received_EventArgs(message));
                        break;
                    case "CommandProgress":
                        CommandProgress_Received?.Invoke(this, new CommandProgress_Received_EventArgs(message));
                        break;
                    case "CommandResult":
                        CommandResult_Received?.Invoke(this, new CommandResult_Received_EventArgs(message));
                        break;
                }
            }
        }
        protected void Initialize(T pipeStream)
        {
            Pipe = pipeStream;
            _stream = new StreamString(pipeStream);
        }
        protected async Task StartReading()
        {
            await Task.Factory.StartNew(async () =>
            {
                try
                {
                    while (true)
                    {
                        var message = await _stream.ReadString();
                        OnMessageReceived(message);
                    }
                }
                catch (InvalidOperationException)
                {
                    OnDisconnected();
                    Dispose();
                }
            });
        }
        public async Task Send(string message)
        {
            await _stream.WriteString(message);
        }
        public abstract void Dispose();
        public async Task<Guid> SendCommandRequest(string command, string[] arguments)
        {
            var id = Guid.NewGuid();
            var request = new CommandRequest(id, command, arguments);
            try
            {
                await Send(JsonSerializer.Serialize(request));
                LogCommandRequest(request, "Sent");
                return id;
            }
            catch (Exception ex)
            {
                if (!(Log == null)) Log($"Error sending Command Request: {ex.Message}\r\n");
                return Guid.Empty;
            }
        }
        public async Task SendCommandResponse(Guid id, string command, string status, string message)
        {
            var response = new CommandResponse(id, command, status, message);
            try
            {
                await Send(JsonSerializer.Serialize(response));
                LogCommandResponse(response, "Sent");
            }
            catch (Exception ex)
            {
                if (!(Log == null)) Log($"Error sending Command Response: {ex.Message}\r\n");
            }
        }
        public async Task SendCommandProgress(Guid id, string command, int progress, int total, string message)
        {
            var response = new CommandProgress(id, command, progress, total, message);
            try
            {
                await Send(JsonSerializer.Serialize(response));
                if (!(Log == null))
                {
                    LogCommandProgress(response, "Sent");
                }
            }
            catch (Exception ex)
            {
                if (!(Log == null)) Log($"Error sending Command Progress: {ex.Message}\r\n");
            }
        }
        public async Task SendCommandResult(Guid id, string command, string status, object result, string message)
        {
            var response = new CommandResult(id, command, status, result, message);
            try
            {
                await Send(JsonSerializer.Serialize(response));
                if (!(Log == null))
                {
                    LogCommandResult(response, "Sent");
                }
            }
            catch (Exception ex)
            {
                if (!(Log == null)) Log($"Error sending Command Result: {ex.Message}");
            }
        }
        public async Task SendGenericMessage(Guid id, string message)
        {
            var response = new GenericMessage(id, message);
            try
            {
                await Send(JsonSerializer.Serialize(response));
                if (!(Log == null))
                {
                    LogGenericMessage(response, "Sent");
                }
            }
            catch (Exception ex)
            {
                if (!(Log == null)) Log($"Error sending Generic Message: {ex.Message}");
            }
        }
        public void LogCommandRequest(CommandRequest message, string logBase)
        {
            string logstring = $"{logBase} Command Request:";
            if (!(string.IsNullOrEmpty(message.Command))) logstring += $"\r\n\tCommand = {message.Command}";
            if (!(string.IsNullOrEmpty(message.Id.ToString()))) logstring += $"\r\n\tID = {message.Id}";
            if (!(message.Arguments == null || message.Arguments.Length == 0)) logstring += $"\r\n\tArguments = {string.Join(", ", message.Arguments)}";
            logstring += "\r\n";
            if (!(Log == null)) Log(logstring);
        }
        public void LogCommandResponse(CommandResponse message, string logBase)
        {
            string logstring = $"{logBase} Command Response:";
            if (!(string.IsNullOrEmpty(message.Command))) logstring += $"\r\n\tCommand = {message.Command}";
            if (!(string.IsNullOrEmpty(message.Id.ToString()))) logstring += $"\r\n\tID = {message.Id}";
            if (!(string.IsNullOrEmpty(message.Status))) logstring += $"\r\n\tStatus = {message.Status}";
            if (!(string.IsNullOrEmpty(message.Message))) logstring += $"\r\n\tMessage = {message.Message}";
            logstring += "\r\n";
            if (!(Log == null)) Log(logstring);
        }
        public void LogCommandProgress(CommandProgress message, string logBase)
        {
            string logstring = $"{logBase} Command Progress:";
            if (!(string.IsNullOrEmpty(message.Command))) logstring += $"\r\n\tCommand = {message.Command}";
            if (!(string.IsNullOrEmpty(message.Id.ToString()))) logstring += $"\r\n\tID = {message.Id}";
            logstring += $"\r\n\tProgress = {message.Progress}/{message.Total}";
            if (!(string.IsNullOrEmpty(message.Message))) logstring += $"\r\n\tMessage = {message.Message}";
            logstring += "\r\n";
            if (!(Log == null)) Log(logstring);
        }
        public void LogCommandResult(CommandResult message, string logBase)
        {
            string logstring = $"{logBase} Command Result:";
            if (!(string.IsNullOrEmpty(message.Command))) logstring += $"\r\n\tCommand = {message.Command}";
            if (!(string.IsNullOrEmpty(message.Id.ToString()))) logstring += $"\r\n\tID = {message.Id}";
            if (!(string.IsNullOrEmpty(message.Status))) logstring += $"\r\n\tStatus = {message.Status}";
            if (!(message.Result == null)) logstring += $"\r\n\tResult = {message.Result.ToString()}";
            if (!(string.IsNullOrEmpty(message.Message))) logstring += $"\r\n\tMessage = {message.Message}";
            logstring += "\r\n";
            if (!(Log == null)) Log(logstring);
        }
        public void LogGenericMessage(GenericMessage message, string logBase)
        {
            string logstring = $"{logBase} Generic Message:";
            if (!(string.IsNullOrEmpty(message.Id.ToString()))) logstring += $"\r\n\tID = {message.Id}";
            if (!(string.IsNullOrEmpty(message.Message))) logstring += $"\r\n\tMessage = {message.Message}";
            logstring += "\r\n";
            if (!(Log == null)) Log(logstring);
        }
    }
    public class StreamString
    {
        private PipeStream ioStream;

        public StreamString(PipeStream ioStream)
        {
            this.ioStream = ioStream;
        }

        public async Task<string> ReadString()
        {
            byte[] messageBytes = new byte[256];
            StringBuilder message = new StringBuilder();
            if (ioStream.CanRead)
            {
                // loop until the entire message is read
                do
                {
                    var bytesRead =
                       await ioStream.ReadAsync(messageBytes, 0,
                                   messageBytes.Length);

                    // got bytes from the stream so add them to the message
                    if (bytesRead > 0)
                    {
                        message.Append(
                           Encoding.Unicode.GetString(messageBytes, 0, bytesRead));
                        Array.Clear(messageBytes, 0, messageBytes.Length);
                    }
                    else
                        throw new InvalidOperationException("disconnected.");
                }
                while (!ioStream.IsMessageComplete);
            }
            return message.ToString();
        }

        public async Task WriteString(string message)
        {
            var messageBytes = Encoding.Unicode.GetBytes(message);
            if (ioStream.CanWrite)
            {
                await ioStream.WriteAsync(messageBytes, 0, messageBytes.Length);
                await ioStream.FlushAsync();
                ioStream.WaitForPipeDrain();
            }
        }

    }
    public class NamedPipeServer : NamedPipeBase<NamedPipeServerStream>, IServer
    {
        public NamedPipeServer(string name, Action<string> log) : base(name, log)
        {
            Log = log;
            ServerStarted += pipeServer_ServersStarted;
            ClientConnected += pipeServer_ClientConnected;
        }
        public event EventHandler ClientConnected;
        private void OnClientConnected()
        {
            ClientConnected?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler ServerStarted;
        private void OnServerStarted()
        {
            ServerStarted?.Invoke(this, EventArgs.Empty);
        }
        public virtual async Task Start()
        {
            if (!(Log == null)) Log("Server starting...");
            await _start();
        }
        protected async Task _start()
        {
            try
            {
                Initialize(new NamedPipeServerStream(_name, PipeDirection.InOut, 1,
                  PipeTransmissionMode.Message, PipeOptions.Asynchronous));

                Pipe.BeginWaitForConnection(WaitForConnectionCallBack, null);

                OnServerStarted();
            }
            catch (Exception ex)
            {
                if (!(Log == null)) Log(ex.Message);
            }
        }

        private void WaitForConnectionCallBack(IAsyncResult result)
        {
            Pipe.EndWaitForConnection(result);
            OnClientConnected();

            StartReading().GetAwaiter().GetResult();
        }

        public override void Dispose()
        {
            if (Pipe.IsConnected) Pipe?.Disconnect();
            Pipe?.Dispose();
        }
        protected virtual void pipeServer_ServersStarted(object sender, EventArgs e)
        {
            if (!(Log == null)) Log("Server started.");
        }
        protected virtual void pipeServer_ClientConnected(object sender, EventArgs e)
        {
            if (!(Log == null)) Log("Client connected.\r\n");
        }
    }
    public class NamedPipeClient : NamedPipeBase<NamedPipeClientStream>, IClient
    {
        public NamedPipeClient(string name, Action<string> log = null) : base(name, log)
        {
            ClientStarted += pipeClient_ClientStarted;
            ConnectedToServer += pipeClient_ClientConnected;
            Disconnected += pipeClient_Disconnected;
        }

        public event EventHandler ConnectedToServer;
        private void OnConnectedToServer()
        {
            ConnectedToServer?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler ClientStarted;
        private void OnClientStarted()
        {
            ClientStarted?.Invoke(this, EventArgs.Empty);
        }
        public virtual async Task Connect()
        {
            if (!(Log == null)) Log("Client starting...");
            await _connect();
        }
        protected virtual async Task _connect()
        {
            try
            {
                Initialize(new NamedPipeClientStream(".", _name, PipeDirection.InOut, PipeOptions.Asynchronous));

                OnClientStarted();

                _logConnectionAttempt();
                await Pipe.ConnectAsync();
                Pipe.ReadMode = PipeTransmissionMode.Message;

                OnConnectedToServer();

                await StartReading();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        protected virtual void _logConnectionAttempt()
        {
            if (!(Log == null)) Log("Connecting to server...");
        }

        public override void Dispose()
        {
            Pipe?.Dispose();
        }
        protected virtual void pipeClient_ClientStarted(object sender, EventArgs e)
        {
            if (!(Log == null)) Log("Client started.");
        }
        protected virtual void pipeClient_ClientConnected(object sender, EventArgs e)
        {
            if (!(Log == null)) Log("Client connected.\r\n");
        }
        protected virtual void pipeClient_Disconnected(object sender, EventArgs e)
        {
            if (!(Log == null)) Log("Client disconnected.");
        }

    }
}
