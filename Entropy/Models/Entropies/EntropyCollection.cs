using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entropy.Models.Entropies
{
    internal class EntropyCollection
    {
        public MaximumEntropy MaximumEntropy { get; set; }

        public UnconditionalEntropy UnconditionalEntropy { get; set; }

        public FirstOrderEntropy FirstOrderEntropy { get; set; }
    }
}
