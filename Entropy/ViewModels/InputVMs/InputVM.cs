using Entropy.Commands;
using Entropy.Notification;

using OOP_RGR_MVVM.Notification.Senders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entropy.ViewModels.InputVMs
{
    internal class InputVM
    {
        public string Message { get; set; }

        public MessageChangedCommand MessageChangedCommand { get; set; }

        public InputVM(MessageSender sender)
        {
            MessageChangedCommand = new(sender, this);
        }
    }
}
