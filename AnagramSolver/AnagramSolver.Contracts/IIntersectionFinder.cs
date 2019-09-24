using System;

namespace AnagramSolver.Contracts
{
    public interface IIntersectionFinder
    {
        int[] FindEntries(DateTime fromDate, DateTime toDate);
    }
}
