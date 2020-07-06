using System;
using PubSubLib.Interfaces;

namespace PubSubLib.Memory
{
    public class MemoryPublisher<TMessage> : IPublisher<TMessage>
    {
        private readonly IMessageHub _hub;

        public MemoryPublisher(IMessageHub hub)
        {
            _hub = hub;
        }

        public void Publish(TMessage message) => _hub.Publish(message);
    }
}