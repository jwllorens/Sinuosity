using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PipeHandler
{
    public class MessageBase
    {
        [JsonConstructor]
        public MessageBase(Guid id)
        {
            Id = id;
        }

        [JsonPropertyName("type")]
        public string Type { get; protected set; }

        [JsonPropertyName("id")]
        public Guid Id { get; private set; }
    }
    public class CommandRequest : MessageBase
    {
        [JsonConstructor]
        public CommandRequest(Guid id, string command, string[] arguments) : base(id)
        {
            Type = "CommandRequest";
            Command = command;
            Arguments = arguments;
        }

        [JsonPropertyName("command")]
        public string Command { get; private set; }

        [JsonPropertyName("arguments")]
        public string[] Arguments { get; private set; }
    }
    public class CommandResponse : MessageBase
    {
        [JsonConstructor]
        public CommandResponse(Guid id, string command, string status, string message) : base(id)
        {
            Type = "CommandResponse";
            Command = command;
            Status = status;
            Message = message;
        }

        [JsonPropertyName("command")]
        public string Command { get; private set; }

        [JsonPropertyName("status")]
        public string Status { get; private set; }

        [JsonPropertyName("message")]
        public string Message { get; private set; }
    }
    public class CommandProgress : MessageBase
    {
        [JsonConstructor]
        public CommandProgress(Guid id, string command, int progress, int total, string message) : base(id)
        {
            Type = "CommandProgress";
            Command = command;
            Progress = progress;
            Total = total;
            Message = message;
        }

        [JsonPropertyName("command")]
        public string Command { get; private set; }

        [JsonPropertyName("progress")]
        public int Progress { get; private set; }

        [JsonPropertyName("total")]
        public int Total { get; private set; }

        [JsonPropertyName("message")]
        public string Message { get; private set; }
    }
    public class CommandResult : MessageBase
    {
        [JsonConstructor]
        public CommandResult(Guid id, string command, string status, object result, string message = null) : base(id)
        {
            Type = "CommandResult";
            Command = command;
            Status = status;
            Result = result;
            Message = message;
        }

        [JsonPropertyName("command")]
        public string Command { get; private set; }

        [JsonPropertyName("status")]
        public string Status { get; private set; }

        [JsonPropertyName("result")]
        public object Result { get; private set; }

        [JsonPropertyName("message")]
        public string Message { get; private set; }
    }
    public class GenericMessage : MessageBase
    {
        [JsonConstructor]
        public GenericMessage(Guid id, string message) : base(id)
        {
            Type = "GenericMessage";
            Message = message;
        }

        [JsonPropertyName("message")]
        public string Message { get; private set; }
    }

    public class Message_Received_EventArgs : EventArgs
    {
        public string Message { get; }

        public Message_Received_EventArgs(string message)
        {
            Message = message;
        }
    }
    public class GenericMessage_Received_EventArgs : EventArgs
    {
        public GenericMessage Message { get; }
        public GenericMessage_Received_EventArgs(string message)
        {
            Message = JsonSerializer.Deserialize<GenericMessage>(message);
        }
    }
    public class CommandRequest_Received_EventArgs : EventArgs
    {
        public CommandRequest Message { get; }
        public CommandRequest_Received_EventArgs(string message)
        {
            Message = JsonSerializer.Deserialize<CommandRequest>(message);
        }
    }
    public class CommandResponse_Received_EventArgs : EventArgs
    {
        public CommandResponse Message { get; }
        public CommandResponse_Received_EventArgs(string message)
        {
            Message = JsonSerializer.Deserialize<CommandResponse>(message);
        }
    }
    public class CommandProgress_Received_EventArgs : EventArgs
    {
        public CommandProgress Message { get; }
        public CommandProgress_Received_EventArgs(string message)
        {
            Message = JsonSerializer.Deserialize<CommandProgress>(message);
        }
    }
    public class CommandResult_Received_EventArgs : EventArgs
    {
        public CommandResult Message { get; }
        public CommandResult_Received_EventArgs(string message)
        {
            Message = JsonSerializer.Deserialize<CommandResult>(message);
        }
    }
}