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
    class AppLayer : IAppLayer
    {
        private readonly IServiceProvider _serviceProvider;

        public AppLayer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IUnitOfWork UnitOfWork { get { return (IUnitOfWork)_serviceProvider.GetService(typeof(IUnitOfWork)); } }

        public TService GetService<TService>()
        {
            return (TService)_serviceProvider.GetService(typeof(TService));
        }

        public void Dispose()
        {
            IDisposable disposable = _serviceProvider as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}
