using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Notification.Senders
{
    internal class MessageSender
    {
        public event Action<string>? MessageUpdated;

        public void UpdateMessage(string message)
        {
            MessageUpdated?.Invoke(message);
        }
    }
}
