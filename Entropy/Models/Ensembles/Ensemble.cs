using Entropy.ViewModels.OutputVMs;

using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Entropy.Models.Ensembles
{
    internal abstract class Ensemble
    {
        private List<SymbolsProbabilitiesVM> _result = new();
        protected abstract int SymbolsCount { get; }

        public List<SymbolsProbabilitiesVM> GetValue()
            => _result;
        public void Generate(string message)
        {
            _result = new();

            SortedDictionary<string, int> symbolsFrequencies = GetSymbolsFrequencies(message, SymbolsCount);
            int sum = symbolsFrequencies.Where(d => d.Value > 0).Sum(d => d.Value);

            foreach (var symbolsFrequency in symbolsFrequencies)
            {
                SymbolsProbabilities symbolsProbability = new()
                {
                    Symbols = symbolsFrequency.Key,
                    SymbolsCount = symbolsFrequency.Value,
                    Count = sum
                };

                _result.Add(new(symbolsProbability));
            };
        }

        private SortedDictionary<string, int> GetSymbolsFrequencies(string message, int symbolsCount)
        {
            SortedDictionary<string, int> symbolsFrequencies = new();

            SetAllCharsPermutations();
            SetSymbolsFrequencies();

            return symbolsFrequencies;

            void SetAllCharsPermutations()
            {
                foreach (var subChars in GetAllPermutations(message.ToHashSet(), symbolsCount))
                    symbolsFrequencies[subChars] = 0;

                IEnumerable<string> GetAllPermutations(HashSet<char> chars, int charsCount)
                {
                    if (charsCount <= 0)
                        yield return "";
                    else
                        foreach (var @char in chars.ToList())
                            foreach (var subChars in GetAllPermutations(chars, charsCount - 1))
                                yield return @char + subChars;
                }
            }
            void SetSymbolsFrequencies()
            {
                int lastIndex = message.Length - (symbolsCount - 1); //rename                

                for (int i = 0; i < lastIndex; i++)
                {
                    string submessage = message.Substring(i, symbolsCount);

                    symbolsFrequencies[submessage]++;
                }
            }
        }
    }
}
