using Entropy.Models.Ensembles;
using Entropy.ViewModels.OutputVMs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entropy.Models.Entropies
{
    internal class UnconditionalEntropy : Entropy
    {
        private List<SymbolsProbabilitiesVM> _symbolsProbabilities;

        public UnconditionalEntropy(int alphabetPower, SymbolsEnsemble symbolsEnsemble)
            : base(alphabetPower)
        {
            _symbolsProbabilities = symbolsEnsemble.GetValue();
        }

        public override void Generate()
        {
            for (int i = 0; i < _alphabetPower; i++)
            {
                double probabylity = _symbolsProbabilities[i].GetProbability();

                if (probabylity is not 0)
                    _result += probabylity * Math.Log2(probabylity);
            }

            _result *= -1;
        }
    }
}
