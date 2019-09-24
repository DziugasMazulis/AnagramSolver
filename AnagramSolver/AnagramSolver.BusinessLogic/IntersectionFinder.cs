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

            EntryModel entryModel = new EntryModel { Date = toDate };
            int startingIndex = fromIndex;
            ValidateIndex(ref startingIndex);
            int range = _entries.Count - startingIndex;
            int toIndex = _entries.BinarySearch(startingIndex, range, entryModel, null);


            if (!DoEntriesIntersectWithDates(fromIndex, toIndex))
            {
                return null;
            }

            if (IsEntryDateEqualToDate(fromIndex) && IsEntryDateEqualToDate(toIndex))
            {
                return new int[2] { fromIndex, toIndex};
            }

            if (IsEntryDateEqualToDate(fromIndex))
            {
                fromIndex++;
            }

            ValidateIndex(ref fromIndex);
            ValidateIndex(ref toIndex);
            ValidateIndexes(ref fromIndex, ref toIndex);

            return new int[2] { fromIndex, toIndex};
        }

        private bool DoEntriesIntersectWithDates(int fromIndex, int toIndex) => fromIndex == toIndex && fromIndex < 0 ? false : true;

        private bool IsEntryDateEqualToDate(int index) => index >= 0 ? true : false;

        private int ValidateIndex(ref int index) => index < 0 ? index = index * -1 - 1 : index;

        private void ValidateIndexes(ref int fromIndex, ref int toIndex)
        {
            if (fromIndex == -1)
            {
                fromIndex = 0;
            }

            if (toIndex == _entries.Count)
            {
                toIndex --;
            }
        }
    }
}
