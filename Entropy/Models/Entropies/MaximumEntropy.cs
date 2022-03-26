using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entropy.Models.Entropies
{
    internal class MaximumEntropy : Entropy
    {
        public MaximumEntropy(int alphabetPower)
            : base(alphabetPower) { }

        public override void Generate()
        {
            _result = Math.Log2(_alphabetPower);
        }
    }
}
