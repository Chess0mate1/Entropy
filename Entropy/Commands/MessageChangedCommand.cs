using Entropy.ViewModels.InputVMs;

using OOP_RGR_MVVM.Notification.Senders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entropy.Commands
{
    internal class MessageChangedCommand : CommandBase
    {
        private MessageSender _sender;
        private InputVM _vm;

        public MessageChangedCommand(MessageSender sender, InputVM vm)
        {
            _sender = sender;
            _vm = vm;
        }

        public override void Execute(object? parameter = null)
        {
            _sender.UpdateMessage(_vm.Message);
        }
    }
}
