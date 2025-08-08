using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using PipeHandler;

namespace PipeHandler
{
    public partial class GDALinterface
    {
        private class Records
        {
            private readonly ConcurrentDictionary<Guid, List<MessageBase>> _records;

            /// <summary>
            /// Adds a message (request, response, progress, or result) to the storage.
            /// </summary>
            /// <param name="message">The message to add.</param>
            /// <exception cref="ArgumentNullException">Thrown if the message is null.</exception>
            /// <exception cref="ArgumentException">Thrown if the message ID is not a valid GUID.</exception>
            public void AddMessage(MessageBase message)
            {
                Guid id = message.Id;

            }



        }

    }
}