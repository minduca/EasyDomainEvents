using Minduca.Domain.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Infrastructure.Data
{
    /// <summary>
    /// Fake repository of a given entity
    /// </summary>
    class DummyRepository<TEntity> : IRepository<TEntity>
    {
        private int idCounter = 0;
        private Dictionary<int, TEntity> _db = new Dictionary<int, TEntity>();

        public TEntity GetById(int id)
        {
            TEntity entity = default(TEntity);
            _db.TryGetValue(id, out entity);
            return entity;
        }

        public int Insert(TEntity entity)
        {
            int id = ++idCounter;
            _db.Add(id, entity);
            return id;
        }

        public void Update(TEntity entity)
        {
            
        }
    }
}
