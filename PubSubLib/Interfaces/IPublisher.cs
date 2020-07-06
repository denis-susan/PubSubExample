using System;

namespace PubSubLib.Interfaces
{
    public interface IPublisher<TMessage> 
    {
        /// <summary>
        /// Publishes a message.
        /// </summary>
        /// <param name="message"></param>
        void Publish(TMessage message);
    }
}