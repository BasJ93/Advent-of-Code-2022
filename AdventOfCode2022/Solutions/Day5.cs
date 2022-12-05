using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode.Base.Interfaces;

namespace AdventOfCode2022.Solutions;

public class Day5 : ISolution
{
    public async Task<string> Task1(IEnumerable<string> input, CancellationToken ctx)
    {
        Dictionary<int, List<char>> stacks = CreateStartingStacks(input);

        List<string> operations = ExtractOperations(input).ToList();
        
        foreach (string operation in operations)
        {
            MovementOperation movement = new MovementOperation(operation);

            stacks.CM9000(movement);
        }

        IEnumerable<char> topContainers = stacks.Select(kvp => kvp.Value.Last());

        return string.Join("", topContainers);
    }

    public async Task<string> Task2(IEnumerable<string> input, CancellationToken ctx)
    {
        Dictionary<int, List<char>> stacks = CreateStartingStacks(input);

        List<string> operations = ExtractOperations(input).ToList();
        
        foreach (string operation in operations)
        {
            MovementOperation movement = new MovementOperation(operation);

            stacks.CM9001(movement);
        }

        IEnumerable<char> topContainers = stacks.Select(kvp => kvp.Value.Last());

        return string.Join("", topContainers);
    }

    private Dictionary<int, List<char>> CreateStartingStacks(IEnumerable<string> input)
    {
        Dictionary<int, List<char>> stacks = new Dictionary<int, List<char>>();

        List<string> inputAsList = input.ToList();

        int separator = inputAsList.IndexOf("");

        List<string> startingStacks = inputAsList.Take(separator).Reverse().ToList();

        List<string> operations = inputAsList.Skip(separator + 1).ToList();

        List<string> stackNames = startingStacks.First()
            .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();

        foreach (string stackName in stackNames)
        {
            stacks.Add(Convert.ToInt32(stackName), new List<char>());
        }

        foreach (var stackRow in startingStacks.Skip(1))
        {
            for (int i = 0; i < stacks.Count; i++)
            {
                int index = (i * 4) + 1;
                if (stackRow[index] != ' ')
                    stacks[i + 1].Add(stackRow[index]);
            }
        }

        return stacks;
    }
    
    private IEnumerable<string> ExtractOperations(IEnumerable<string> input)
    {
        Dictionary<int, List<char>> stacks = new Dictionary<int, List<char>>();

        List<string> inputAsList = input.ToList();

        int separator = inputAsList.IndexOf("");

        List<string> operations = inputAsList.Skip(separator + 1).ToList();

        return operations;
    }
}

internal record MovementOperation
{
    internal int NumberOfContainers { get; }

    internal int CurrentStack { get; }

    internal int TargetStack { get; }

    private readonly Regex _extractor = new Regex(@"\d+");

    public MovementOperation(string operation)
    {
        MatchCollection matches = _extractor.Matches(operation);

        NumberOfContainers = Convert.ToInt32(matches[0].Value);
        CurrentStack = Convert.ToInt32(matches[1].Value);
        TargetStack = Convert.ToInt32(matches[2].Value);
    }
}

internal static class DictionaryExtensions
{
    internal static void CM9000(this Dictionary<int, List<char>> stacks, MovementOperation operation)
    {
        for (int i = 0; i < operation.NumberOfContainers; i++)
        {
            char container = stacks[operation.CurrentStack].Last();
            stacks[operation.CurrentStack].RemoveAt(stacks[operation.CurrentStack].Count - 1);
            stacks[operation.TargetStack].Add(container);
        }
    }

    internal static void CM9001(this Dictionary<int, List<char>> stacks, MovementOperation operation)
    {
        List<char> container = stacks[operation.CurrentStack]
            .GetRange(stacks[operation.CurrentStack].Count - operation.NumberOfContainers,
                operation.NumberOfContainers);
        stacks[operation.CurrentStack].RemoveRange(
            stacks[operation.CurrentStack].Count - operation.NumberOfContainers,
            operation.NumberOfContainers);
        stacks[operation.TargetStack].AddRange(container);
    }
}