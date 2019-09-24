using System.Collections.Generic;

namespace AnagramSolver.Contracts
{
    public interface IAnagramValidator
    {
        List<int> Validate(int fromIndex, int toIndex);
    }
}
