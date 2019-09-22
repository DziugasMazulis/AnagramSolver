using AnagramSolver.Contracts;
using AnagramSolver.Contracts.Models;
using System;
using System.Collections.Generic;

namespace AnagramSolver.BusinessLogic
{
    public class IntersectionFinder : IIntersectionFinder
    {
        private readonly List<EntryModel> _entries;

        public IntersectionFinder(List<EntryModel> entries)
        {
            _entries = entries;
        }

        public int[] FindEntries(DateTime fromDate, DateTime toDate)
        {
            int fromIndex = _entries.BinarySearch(new EntryModel { Date = fromDate });
            fromIndex = ValidateIndex(fromIndex);

            int toIndex = _entries.BinarySearch(new EntryModel { Date = toDate });
            toIndex = ValidateIndex(toIndex) - 1;

            if (fromIndex >= _entries.Count || toIndex < 0)
            {
                return new int[2] { -1, -1 };
            }

            return new int[2] { fromIndex, toIndex };
        }

        private int ValidateIndex(int index)
        {
            if (index < 0)
            {
                return index * -1 - 1;
            }
            
            return index;
        }
    }
}
