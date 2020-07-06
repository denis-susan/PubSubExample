using System;

namespace PubSubLib.Interfaces
{
    public interface ISubscriber<TMessage>
    {
        /// <summary>
        /// Receives a message from a publisher.
        /// </summary>
        Action<TMessage> OnChange { get; set; }
    }
}