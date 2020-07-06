using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PubSubLib.Interfaces;

namespace PubSubLib.Memory
{
    public class MemoryHub : IMessageHub
    {
        private readonly Dictionary<Type, IList> _subscribers = new Dictionary<Type, IList>();

        public void Publish<TMessage>(TMessage message)
        {
            if (!_subscribers.ContainsKey(typeof(TMessage))) return;

            foreach (ISubscriber<TMessage> subscriber in _subscribers[typeof(TMessage)])
            {
                subscriber.OnChange(message);
            }
        }

        public void Subscribe<TMessage>(ISubscriber<TMessage> subscriber)
        {
            if (!_subscribers.ContainsKey(typeof(TMessage)))
                _subscribers.Add(typeof(TMessage), new List<ISubscriber<TMessage>>());

            _subscribers[typeof(TMessage)].Add(subscriber);
        }
    }
}