using Entropy.Models;
using Entropy.Notification;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entropy.ViewModels.OutputVMs
{
    internal class SymbolsProbabilitiesVM : NotificationObject    
    {
        private SymbolsProbabilities _symbolsProbability;

        public string Symbols => _symbolsProbability.Symbols;
        public string StringProbability => $"{GetSymbolsCount()}/{GetCount()}";

        public int GetSymbolsCount() => _symbolsProbability.SymbolsCount;
        public int GetCount() => _symbolsProbability.Count;
        public double GetProbability() => _symbolsProbability.Probability;

        public SymbolsProbabilitiesVM(SymbolsProbabilities symbolsProbability)
        {
            _symbolsProbability = symbolsProbability;
        }   
    }
}
