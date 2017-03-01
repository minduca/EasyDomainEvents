using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Domain.Core.Data
{
    /// <summary>
    /// Generic repository for simplification purposes
    /// </summary>
    public interface IRepository<TEntity> 
    {
        TEntity GetById(int id);

        int Insert(TEntity entity);

        void Update(TEntity entity);
    }
}
