using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entropy.Models.Entropies
{
    internal abstract class Entropy
    {
        protected double _result = 0;
        protected int _alphabetPower;

        protected Entropy(int alphabetPower)
        {
            _alphabetPower = alphabetPower;
        }

        public double GetValue() => _result;

        public abstract void Generate();
    }
}
