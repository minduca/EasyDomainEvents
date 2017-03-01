using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Infrastructure
{
    /// <summary>
    /// Factory that creates the application layer
    /// </summary>
    public interface IScopeFactory
    {
        IAppLayer CreateAppLayer();
    }
}
