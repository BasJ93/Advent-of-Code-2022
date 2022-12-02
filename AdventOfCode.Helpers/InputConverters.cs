using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Helpers
{
    public static class InputConverters
    {
        public static IEnumerable<int> ToInt(this IEnumerable<string> input)
        {
            return input.Select(i => Convert.ToInt32(i));
        }
    }
}