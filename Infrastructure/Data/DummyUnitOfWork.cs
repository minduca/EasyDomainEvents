using Minduca.Domain.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Infrastructure.Data
{
    /// <summary>
    /// Dummy unit of work for simplification purposes
    /// </summary>
    class DummyUnitOfWork : IUnitOfWork, IDbStateTracker
    {
        public event Action Disposing;
        public event Action TransactionComplete;

        private bool _totallyFakeHasPendingChanges = true;

        public bool HasPendingChanges()
        {
            //In case of Entity Framework :
            //return context.ChangeTracker.Entries().Any(e =>
            //    e.State == EntityState.Added ||
            //    e.State == EntityState.Deleted ||
            //    e.State == EntityState.Modified);

            return _totallyFakeHasPendingChanges;
        }

        public void Save()
        {
            //In case of Entity Framework :
            //DbContext.SaveChanges();

            _totallyFakeHasPendingChanges = false;

            if (TransactionComplete != null)
                TransactionComplete();

            _totallyFakeHasPendingChanges = true;
        }

        public void Dispose()
        {
            if (Disposing != null)
                Disposing();
        }
    }
}
