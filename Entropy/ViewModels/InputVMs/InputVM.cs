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
        private string _message;
        private MessageSender _sender;

        public string Message 
        {
            get => _message;
            set
            {
                _message = value;

                _sender.UpdateMessage(Message);
            }
        }

        public InputVM(MessageSender sender)
        {
            _sender = sender;
        }
    }
}
