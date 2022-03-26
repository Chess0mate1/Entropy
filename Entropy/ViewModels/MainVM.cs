using Entropy.Notification;
using Entropy.ViewModels.InputVMs;
using Entropy.ViewModels.OutputVMs;

using OOP_RGR_MVVM.Notification.Senders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entropy.ViewModels
{
    internal class MainVM : NotificationObject
    {
        public InputVM InputVM { get; set; }
        public OutputVM OutputVM { get; set; }

        public MainVM()
        {
            MessageSender sender = new();

            OutputVM = new(sender);
            InputVM = new(sender);
        }
    }
}
