using Entropy.Models.Entropies;
using Entropy.Notification;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Entropy.ViewModels.OutputVMs
{
    internal class EntropyVM : NotificationObject
    {
        public double MaximumEntropy { get; init; }
        public double UnconditionalEntropy { get; init; }
        public double UnderloadedAlphabet => MaximumEntropy - UnconditionalEntropy;
        public double FirstOrderEntropy { get; init; }

        public EntropyVM(EntropyCollection collection)
        {
            MaximumEntropy = collection.MaximumEntropy.GetValue();
            UnconditionalEntropy = collection.UnconditionalEntropy.GetValue();
            FirstOrderEntropy = collection.FirstOrderEntropy.GetValue();
        }
    }
}
