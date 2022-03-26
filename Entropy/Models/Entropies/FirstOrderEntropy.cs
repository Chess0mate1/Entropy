using Entropy.Models.Ensembles;
using Entropy.ViewModels.OutputVMs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Entropy.Models.Entropies
{
    internal class FirstOrderEntropy : Entropy
    {
        private List<SymbolsProbabilitiesVM> _symbolsProbabilities;
        private List<SymbolsProbabilitiesVM> _bigramsProbabilities;

        public FirstOrderEntropy(int alphabetPower,
            SymbolsEnsemble symbolsEnsemble,
            BigramsEnsemble bigramsEnsemble)
            : base(alphabetPower)
        {
            _symbolsProbabilities = symbolsEnsemble.GetValue();
            _bigramsProbabilities = bigramsEnsemble.GetValue();
        }

        public override void Generate()
        {
            for (int i = 0; i < _alphabetPower; i++)
            {
                double bigramProbabilitiesSum = 0;

                int currentStartIndex = _symbolsProbabilities.Count * i;
                for (int j = 0; j < _alphabetPower; j++)
                {
                    double bigramProbability = _bigramsProbabilities[j + currentStartIndex].GetProbability();

                    if (bigramProbability is not 0)
                        bigramProbabilitiesSum += bigramProbability * Math.Log2(bigramProbability);
                }

                _result -= _symbolsProbabilities[i].GetProbability() * bigramProbabilitiesSum;
            }
        }
    }
}
