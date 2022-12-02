using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode.Base.Interfaces
{
    /// <summary>
    /// The defition of the solution to a puzzle. Output is formatted as a long.
    /// </summary>
    public interface ISolution
    {
        /// <summary>
        /// Solve the first task of the day.
        /// </summary>
        /// <param name="input">The puzzle input</param>
        /// <returns>The result as a long</returns>
        Task<long> Task1(IEnumerable<string> input, CancellationToken ctx);

        /// <summary>
        /// Solve the second task of the day.
        /// </summary>
        /// <param name="input">The puzzle input</param>
        /// <returns>The ressult as a long</returns>
        Task<long> Task2(IEnumerable<string> input, CancellationToken ctx);
    }
}