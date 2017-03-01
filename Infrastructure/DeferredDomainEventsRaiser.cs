using Minduca.Domain.Core.Data;
using Minduca.Domain.Core.Events;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Minduca.Infrastructure
{
    /// <summary>
    /// Domain events handler that supports deferred execution
    /// </summary>
    class DeferredDomainEventsRaiser : IDomainEventsRaiser
    {
        /// <summary>
        /// Locator of event handlers
        /// </summary>
        private readonly IServiceProvider _resolver;
        /// <summary>
        /// Collection of events queued for later execution
        /// </summary>
        private readonly ConcurrentQueue<Action> _pendingHandlers = new ConcurrentQueue<Action>();
        /// <summary>
        /// Data access state manager
        /// </summary>
        private readonly IDbStateTracker _dbState;

        public DeferredDomainEventsRaiser(IServiceProvider resolver, IDbStateTracker dbState)
        {
            _resolver = resolver;
            _dbState = dbState;

            _dbState.TransactionComplete += this.Flush;
            _dbState.Disposing += this.FlushOrClear;
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
            {
                IHandles<T>[] handlersToEnqueue = null;
                IHandles<T>[] handlersToFire = allHandlers;

                if (_dbState.HasPendingChanges())
                {
                    //if there is a transaction in progress, events are enqueued to be executed later

                    handlersToEnqueue = allHandlers.Where(h => h.Deferred).ToArray();
                    
                    if (handlersToEnqueue.Length > 0)
                    {
                        lock (_pendingHandlers)
                            foreach (var handler in handlersToEnqueue)
                                _pendingHandlers.Enqueue(() => handler.Handle(domainEvent));

                        handlersToFire = allHandlers.Except(handlersToEnqueue).ToArray();
                    }
                }

                foreach (var handler in handlersToFire)
                    handler.Handle(domainEvent);
            }
        }

        /// <summary>
        /// Fire all the events in the queue
        /// </summary>
        private void Flush()
        {
            Action dispatch;
            lock (_pendingHandlers)
                while (_pendingHandlers.TryDequeue(out dispatch))
                    dispatch();
        }

        /// <summary>
        /// Execute all pending events if there is no open transaction. Otherwise, clears the queue without executing them
        /// </summary>
        private void FlushOrClear()
        {
            if (!_dbState.HasPendingChanges())
                Flush();
            else
            {
                //If the state manager was disposed with a transaction in progress, we clear 
                //the queue without firing the events because this flow is pretty inconsistent 
                //(it could be caused, for instance, by an unhandled exception)
                Clear();
            }
        }

        /// <summary>
        /// Clear the pending events without firing them
        /// </summary>
        private void Clear()
        {
            Action dispatch;
            lock (_pendingHandlers)
                while (_pendingHandlers.TryDequeue(out dispatch)) ;
        }
    }
}
