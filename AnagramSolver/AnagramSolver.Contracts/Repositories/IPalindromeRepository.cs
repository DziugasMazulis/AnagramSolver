using System.Collections.Generic;

namespace AnagramSolver.Contracts.Repositories
{
    public interface IPalindromeRepository
    {
        void WriteEntries(List<int> anagramsIndexes);
    }
}
