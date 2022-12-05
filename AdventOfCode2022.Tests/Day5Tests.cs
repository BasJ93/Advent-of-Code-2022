using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode.Base.Interfaces;
using AdventOfCode2022.Solutions;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day5Tests
{
    private readonly List<string> _input;

    private readonly ISolution _solutionUnderTest;

    public Day5Tests()
    {
        _input = new List<string>
        {
            "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3 ",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2"
        };

        _solutionUnderTest = new Day5();
    }

    [Fact]
    public async Task Test1()
    {
        // Arrange
        // Act

        string result = await _solutionUnderTest.Task1(_input, CancellationToken.None);

        // Assert

        Assert.Equal("CMZ", result);
    }

    [Fact]
    public async Task Test2()
    {
        // Arrange
        // Act

        string result = await _solutionUnderTest.Task2(_input, CancellationToken.None);

        // Assert

        Assert.Equal("MCD", result);
    }
}