using AnagramSolver.Contracts;
using AnagramSolver.Contracts.Models;
using AnagramSolver.Contracts.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;

namespace AnagramSolver.BusinessLogic.Repositories
{
    public class PalindromeRepository : IPalindromeRepository
    {
        private readonly AppSettings _config;
        private readonly List<EntryModel> _entries;

        public PalindromeRepository(IOptions<AppSettings> config, List<EntryModel> entries)
        {
            _config = config.Value;
            _entries = entries;
        }

        public void WriteEntries(List<int> anagramsIndexes)
        {
            string path = GetPath();

            using (StreamWriter file = 
                new StreamWriter(path))
            {
                foreach (int index in anagramsIndexes)
                {
                    file.WriteLine($"Date: {_entries[index].Date.Date.ToString("d")}, Word:{_entries[index].Word}");
                }
            }
        }

        private string GetPath()
        {
            string path = Path.Combine(Environment.CurrentDirectory, _config.OutputFileName);

            return path;
        }
    }
}
