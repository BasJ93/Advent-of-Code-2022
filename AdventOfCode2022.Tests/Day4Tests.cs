using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode.Base.Interfaces;
using AdventOfCode2022.Solutions;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day4Tests
{
    private readonly List<string> _input;

    private readonly ISolution _solutionUnderTest;

    public Day4Tests()
    {
        _input = new List<string>
        {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8"
        };

        _solutionUnderTest = new Day4();
    }

    [Fact]
    public async Task Test1()
    {
        // Arrange
        // Act

        long result = await _solutionUnderTest.Task1(_input, CancellationToken.None);

        // Assert

        Assert.Equal(2, result);
    }

    [Fact]
    public async Task Test2()
    {
        // Arrange
        // Act

        long result = await _solutionUnderTest.Task2(_input, CancellationToken.None);

        // Assert

        Assert.Equal(4, result);
    }
}