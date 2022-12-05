using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode.Base.Interfaces;
using AdventOfCode2022.Solutions;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day3Tests
{
    private readonly List<string> _input;

    private readonly ISolution _solutionUnderTest;

    public Day3Tests()
    {
        _input = new List<string>
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        };

        _solutionUnderTest = new Day3();
    }

    [Fact]
    public async Task Test1()
    {
        // Arrange
        // Act

        string result = await _solutionUnderTest.Task1(_input, CancellationToken.None);

        // Assert

        Assert.Equal("157", result);
    }

    [Fact]
    public async Task Test2()
    {
        // Arrange
        // Act

        string result = await _solutionUnderTest.Task2(_input, CancellationToken.None);

        // Assert

        Assert.Equal("70", result);
    }
}