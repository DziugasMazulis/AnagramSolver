using AnagramSolver.Contracts.Models;
using System.Collections.Generic;

namespace AnagramSolver.Contracts.Repositories
{
    public interface IEntryRepository
    {
        List<EntryModel> LoadEntries();
    }
}
