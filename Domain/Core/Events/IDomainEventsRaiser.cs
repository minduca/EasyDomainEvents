
namespace Minduca.Domain.Core.Events
{
    public interface IDomainEventsRaiser
    {
        /// <summary>
        /// Raises the given domain event
        /// </summary>
        /// <typeparam name="T">Domain event type</typeparam>
        /// <param name="domainEvent">Domain event</param>
        void Raise<T>(T domainEvent) where T : IDomainEvent;
    }
}
