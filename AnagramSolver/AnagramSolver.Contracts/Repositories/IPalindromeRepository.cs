using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Contracts.Repositories
{
    public interface IPalindromeRepository
    {
        void WriteEntries(List<int> anagramsIndexes);
    }
}
