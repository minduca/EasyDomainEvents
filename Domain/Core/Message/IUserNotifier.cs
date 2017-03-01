using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minduca.Domain.Core.Message
{
    public interface IUserNotifier
    {
        /// <summary>
        /// Sends a message to the user
        /// </summary>
        void Notify(string text);
    }
}
