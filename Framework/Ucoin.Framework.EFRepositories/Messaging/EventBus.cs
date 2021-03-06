﻿
namespace Ucoin.Framework.SqlDb.Messaging
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Ucoin.Framework.Messaging;
    using Ucoin.Framework.Serialization;

    /// <summary>
    /// This is an extremely basic implementation of <see cref="IEventBus"/> that is used only for running the sample
    /// application without the dependency to the Windows Azure Service Bus when using the DebugLocal solution configuration.
    /// It should not be used in production systems.
    /// </summary>
    public class EventBus : IEventBus
    {
        private readonly IMessageSender sender;
        private readonly ISerializer serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventBus"/> class.
        /// </summary>
        /// <param name="serializer">The serializer to use for the message body.</param>
        public EventBus(IMessageSender sender, ISerializer serializer)
        {
            this.sender = sender;
            this.serializer = serializer;
        }

        /// <summary>
        /// Sends the specified event.
        /// </summary>
        public void Publish(Envelope<IEvent> @event)
        {
            var message = this.BuildMessage(@event);

            this.sender.Send(message);
        }

        /// <summary>
        /// Publishes the specified events.
        /// </summary>
        public void Publish(IEnumerable<Envelope<IEvent>> events)
        {
            var messages = events.Select(e => this.BuildMessage(e));

            this.sender.Send(messages);
        }

        private Message BuildMessage(Envelope<IEvent> @event)
        {
            var payload = this.serializer.SerializeToString(@event.Body);
            return new Message(payload, correlationId: @event.CorrelationId);
        }
    }
}
