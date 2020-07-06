using System;
using PubSubLib.Interfaces;

namespace PubSubLib.Interfaces
{
    public interface IMessageHub
    {
        /// <summary>
        /// Publishes a message from a publisher to the aggregator
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="message"></param>
        void Publish<TMessage>(TMessage message);

        /// <summary>
        /// Adds a subscriber to the aggregator.
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="subscriber"></param>
        void Subscribe<TMessage>(ISubscriber<TMessage> subscriber);
    }
}