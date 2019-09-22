using AnagramSolver.Contracts;
using AnagramSolver.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.BusinessLogic
{
    public class AnagramValidator : IAnagramValidator
    {
        private readonly List<EntryModel> _entries;

        public AnagramValidator(List<EntryModel> entries)
        {
            _entries = entries;
        }

        public List<int> Validate(int fromIndex, int toIndex)
        {
            List<int> anagramsIndexes = new List<int>();

            for(int i = fromIndex; i <= toIndex; i++)
            {
                if (IsAnagram(_entries[i].Word))
                {
                    anagramsIndexes.Add(i);
                }
            }

            return anagramsIndexes;
        }

        private bool IsAnagram(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
