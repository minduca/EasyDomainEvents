using Minduca.Domain.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Infrastructure
{
    /// <summary>
    /// Application layer, locator of application services
    /// </summary>
    public interface IAppLayer : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
        TService GetService<TService>();
    }
}
