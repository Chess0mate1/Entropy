using Entropy.Models.Ensembles;
using Entropy.Notification;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Entropy.ViewModels.OutputVMs
{
    internal class EnsemblesVM : NotificationObject
    {
        public ObservableCollection<SymbolsProbabilitiesVM> SymbolsEnsemble { get; init; } = new();
        public ObservableCollection<SymbolsProbabilitiesVM> BigramsEnsemble { get; init; } = new();
    }
}
