using Microsoft.Practices.Unity;
using Minduca.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Register the conventions that allows domain events to be raised and handled
    /// </summary>
    class EventHandlersConvention : RegistrationConvention
    {
        public override Func<Type, IEnumerable<Type>> GetFromTypes()
        {
            return WithMappings.FromAllInterfaces;
        }

        public override Func<Type, IEnumerable<InjectionMember>> GetInjectionMembers()
        {
            return (t) => new InjectionMember[0];
        }

        public override Func<Type, LifetimeManager> GetLifetimeManager()
        {
            return WithLifetime.Transient;
        }

        public override Func<Type, string> GetName()
        {
            return WithName.TypeName;
        }

        public override IEnumerable<Type> GetTypes()
        {
            Type handlerType = typeof(IHandles<>);

            return AllClasses.FromLoadedAssemblies(skipOnError: false).
                        Where(t => !t.IsAbstract &&
                            t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition().Equals(handlerType)));
        }
    }
}
