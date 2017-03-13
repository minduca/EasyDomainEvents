using System;

namespace Minduca.Domain.Core.Data
{

    /// <summary>
    /// Tracks the database's state
    /// </summary>
    public interface IDbStateTracker : IDisposable
    {
        /// <summary>
        /// Triggered when disposing 
        /// </summary>
        event Action Disposing;

        /// <summary>
        /// Triggered when the transaction is completed
        /// </summary>
        event Action TransactionComplete;

        /// <summary>
        /// Returns true if there are uncommitted pending changes. Otherwise, returns false.
        /// </summary>
        bool HasPendingChanges();
    }
}
