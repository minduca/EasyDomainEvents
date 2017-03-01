
namespace Minduca.Domain.Core.Events
{
    /// <summary>
    /// Handles an event. If there is a database transaction, the
    /// execution is delayed until the transaction is complete.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHandles<T> where T : IDomainEvent
    {
        void Handle(T domainEvent);

        bool Deferred { get; }
    }
}
