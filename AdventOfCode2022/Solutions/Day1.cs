using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode.Base.Interfaces;

namespace AdventOfCode2022.Solutions;

public sealed class Day1 : ISolution
{
    public async Task<long> Task1(IEnumerable<string> input, CancellationToken ctx)
    {
        List<string> inputAsList = input.ToList();

        Dictionary<int, long> elvesWithLoad = CalculateCaloryLoad(inputAsList);

        return elvesWithLoad.MaxBy(kvp => kvp.Value).Value;
    }

    public async Task<long> Task2(IEnumerable<string> input, CancellationToken ctx)
    {
        List<string> inputAsList = input.ToList();

        Dictionary<int, long> elvesWithLoad = CalculateCaloryLoad(inputAsList);

        return elvesWithLoad.OrderByDescending(kvp => kvp.Value).Select(kvp => kvp.Value).Take(3).Sum();
    }
    
    private Dictionary<int, long> CalculateCaloryLoad(List<string> input)
    {
        Dictionary<int, long> elvesWithLoad = new Dictionary<int, long>();

        long load = 0;
        int elve = 0;

        for (int i = 0; i < input.Count; i++)
        {
            if (string.IsNullOrEmpty(input[i]))
            {
                elvesWithLoad.Add(elve, load);
                load = 0;
                elve++;
            }
            else
            {
                load += Convert.ToInt64(input[i]);                
            }
        }

        elvesWithLoad.Add(elve, load);

        return elvesWithLoad;
    }
}