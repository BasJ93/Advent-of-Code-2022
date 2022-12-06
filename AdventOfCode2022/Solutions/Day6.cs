using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode.Base.Interfaces;
using AdventOfCode.Helpers;

namespace AdventOfCode2022.Solutions;

public class Day6 : ISolution
{
    public async Task<string> Task1(IEnumerable<string> input, CancellationToken ctx)
    {
        string onlyInput = input.First();

        int result = onlyInput.SlidingEndWindow(4, (s, i) =>
        {
            if (s.ToCharArray().Distinct().Count() == 4)
            {
                return new SlidingResult<int>(true, i);
            }

            return new SlidingResult<int>(false, 0);
        });

        return result.ToString();
    }

    public async Task<string> Task2(IEnumerable<string> input, CancellationToken ctx)
    {
        string onlyInput = input.First();

        int result = onlyInput.SlidingEndWindow(14, (s, i) =>
        {
            if (s.ToCharArray().Distinct().Count() == 14)
            {
                return new SlidingResult<int>(true, i);
            }

            return new SlidingResult<int>(false, 0);
        });

        return result.ToString();
    }
}