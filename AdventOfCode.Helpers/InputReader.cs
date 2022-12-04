using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Helpers
{
    public static class InputReader
    {
        // TODO: Add a method to load the input data for a specific day from the input folder
        public static IEnumerable<string> ReadFromInputFile(int day)
        {
            var content = File.ReadAllLines($"Inputs/day{day}.txt");

            return content;
        }
    }
}