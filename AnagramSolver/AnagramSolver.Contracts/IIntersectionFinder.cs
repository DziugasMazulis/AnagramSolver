using AnagramSolver.Contracts.Models;
using System;
using System.Collections.Generic;

namespace AnagramSolver.Contracts
{
    public interface IIntersectionFinder
    {
        int[] FindEntries(DateTime fromDate, DateTime toDate);
    }
}
