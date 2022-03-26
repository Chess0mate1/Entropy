using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entropy.Models
{
    internal class SymbolsProbabilities
    {
        public string Symbols { get; set; }

        public int Count { get; set; }

        public int SymbolsCount { get; set; }

        public double Probability => (double)SymbolsCount / Count;
    }
}
