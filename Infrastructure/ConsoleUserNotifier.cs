using Minduca.Domain.Core.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Infrastructure
{
    /// <summary>
    /// Write things on the console
    /// </summary>
    class ConsoleUserNotifier : IUserNotifier
    {
        public void Notify(string text)
        {
            Console.WriteLine("\t" + text);
        }
    }
}
