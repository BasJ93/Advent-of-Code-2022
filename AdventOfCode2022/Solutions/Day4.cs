using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode.Base.Interfaces;

namespace AdventOfCode2022.Solutions;

public class Day4 : ISolution
{
    public async Task<long> Task1(IEnumerable<string> input, CancellationToken ctx)
    {
        long numberOfFullyContainedAssignments = 0;

        foreach (string assignment in input)
        {
            IEnumerable<string> pair = assignment.Split(',');
            CleaningTask task1 = new(pair.First());
            CleaningTask task2 = new(pair.Last());

            // Taskx should be contained in Tasky
            // So, x1 <= y1 and x2 >= y2
            // Or, y1 <= x1 and y2 >= x2

            if (task1.Contains(task2) || task2.Contains(task1))
            {
                numberOfFullyContainedAssignments++;
            }
        }

        return numberOfFullyContainedAssignments;
    }

    public async Task<long> Task2(IEnumerable<string> input, CancellationToken ctx)
    {
        long numberOfOverlappingAssigments = 0;

        foreach (string assignment in input)
        {
            IEnumerable<string> pair = assignment.Split(',');
            CleaningTask task1 = new(pair.First());
            CleaningTask task2 = new(pair.Last());

            if (task1.AssignedSections.Intersect(task2.AssignedSections).Any())
            {
                numberOfOverlappingAssigments++;
            }
        }

        return numberOfOverlappingAssigments;
    }
}

internal record CleaningTask
{
    public List<int> AssignedSections { get; }
    public int FirstSection { get; }
    public int LastSection { get; }

    public CleaningTask(string taskNotation)
    {
        try
        {
            IEnumerable<string> sections = taskNotation.Split('-');
            FirstSection = Convert.ToInt32(sections.First());
            LastSection = Convert.ToInt32(sections.Last());

            AssignedSections = Enumerable.Range(FirstSection, (LastSection - FirstSection) + 1).ToList();
        }
        catch (FormatException)
        {
            
        }
    }
    
    internal bool Contains(CleaningTask other) =>
        (FirstSection <= other.FirstSection && LastSection >= other.LastSection);
}