using Entropy.Models.Ensembles;
using Entropy.Models.Entropies;
using Entropy.Notification;

using OOP_RGR_MVVM.Notification.Senders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Entropy.ViewModels.OutputVMs
{
    internal class OutputVM : NotificationObject
    {
        private EntropyVM _entropyVM;
        private EnsemblesVM _ensemblesVM;
        private int _alphabetPower;

        public EntropyVM EntropyVM
        {
            get => _entropyVM;
            set
            {
                _entropyVM = value;
                OnPropertyChanged();
            }
        }
        public EnsemblesVM EnsemblesVM
        {
            get => _ensemblesVM;
            set
            {
                _ensemblesVM = value;
                OnPropertyChanged();
            }
        }
        public int AlphabetPower
        {
            get => _alphabetPower;
            set
            {
                _alphabetPower = value;
                OnPropertyChanged();
            }
        }

        public OutputVM(MessageSender sender)
        {
            sender.MessageUpdated += OnMessageUpdated;
        }

        private void OnMessageUpdated(string message)
        {
            SymbolsEnsemble symbolsEnsemble = new();
            BigramsEnsemble bigramsEnsemble = new();

            EnsemblesVM = GenerateEnsemblesVM();
            AlphabetPower = GetAlphabetPower();
            EntropyVM = GenerateEntropyVM();

            EnsemblesVM GenerateEnsemblesVM()
            {
                symbolsEnsemble.Generate(message);
                bigramsEnsemble.Generate(message);

                return new EnsemblesVM()
                {
                    SymbolsEnsemble = new(symbolsEnsemble.GetValue()),
                    BigramsEnsemble = new(bigramsEnsemble.GetValue())
                };
            }
            int GetAlphabetPower()
            {
                return symbolsEnsemble.GetValue().Count;
            }
            EntropyVM GenerateEntropyVM()
            {
                MaximumEntropy maximumEntropy = new(AlphabetPower);
                maximumEntropy.Generate();

                UnconditionalEntropy unconditionalEntropy = new(AlphabetPower, symbolsEnsemble);
                unconditionalEntropy.Generate();

                FirstOrderEntropy firstOrderEntropy = new(AlphabetPower, symbolsEnsemble, bigramsEnsemble);
                firstOrderEntropy.Generate();

                EntropyCollection collection = new()
                {
                    MaximumEntropy = maximumEntropy,
                    UnconditionalEntropy = unconditionalEntropy,
                    FirstOrderEntropy = firstOrderEntropy
                };

                return new EntropyVM(collection);
            }
        }
    }
}
