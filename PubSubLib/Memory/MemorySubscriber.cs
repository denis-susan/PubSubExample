using System;
using PubSubLib.Interfaces;

namespace PubSubLib.Memory
{
    public class MemorySubscriber<TMessage> : ISubscriber<TMessage>
    {
        
        private readonly IMessageHub _hub;
        public Action<TMessage> OnChange { get; set; }
        
        public MemorySubscriber(IMessageHub hub)
        {
            _hub = hub;
            _hub.Subscribe(this);
        }

    }
}