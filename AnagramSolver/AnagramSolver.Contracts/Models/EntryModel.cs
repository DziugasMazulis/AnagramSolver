using System;

namespace AnagramSolver.Contracts.Models
{
    public class EntryModel : IComparable<EntryModel>
    {
        public string Word { get; set; }
        public DateTime Date { get; set; }

        public int CompareTo(EntryModel other)
        {
            if (this == null) return -1;
            if (other == null) return 1;

            if (Date == other.Date) return 0;

            return Date > other.Date ? 1 : -1;
        }
    }
}
