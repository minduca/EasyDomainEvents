using Minduca.Domain.Core.Events;
using System;

namespace Minduca.Infrastructure
{
    /// <summary>
    /// Simple domain events raiser that is functional, but doesn't support deferred execution
    /// </summary>
    class DomainEventsRaiser : IDomainEventsRaiser
    {
        /// <summary>
        /// Locator of event handlers
        /// </summary>
        private readonly IServiceProvider _resolver;

        internal DomainEventsRaiser(IServiceProvider resolver)
        {
            _resolver = resolver;
        }

        /// <summary>
        /// Raises the given domain event
        /// </summary>
        /// <typeparam name="T">Domain event type</typeparam>
        /// <param name="domainEvent">Domain event</param>
        public void Raise<T>(T domainEvent) where T : IDomainEvent
        {
            //Get all the handlers that handle events of type T
            IHandles<T>[] allHandlers = (IHandles<T>[])_resolver.GetService(typeof(IHandles<T>[]));

            if (allHandlers != null && allHandlers.Length > 0)
                foreach (var handler in allHandlers)
                    handler.Handle(domainEvent);
        }
    }
}
