using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entropy.Models.Ensembles
{
    internal class BigramsEnsemble : Ensemble
    {
        protected override int SymbolsCount => 2;
    }
}
