using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Contracts
{
    public interface IAnagramValidator
    {
        List<int> Validate(int fromIndex, int toIndex);
    }
}
