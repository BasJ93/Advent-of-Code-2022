using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode.Base.Interfaces;
using AdventOfCode2022.Solutions;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day8Tests
{
    private readonly List<string> _input;
    
    private readonly ISolution _solutionUnderTest;

    public Day8Tests()
    {
        _input = new List<string>
        {
            "30373",
            "25512",
            "65332",
            "33549",
            "35390"
        };
        
        _solutionUnderTest = new Day8();
    }

    [Fact]
    public async Task Test1()
    {
        // Arrange
        // Act

        string result = await _solutionUnderTest.Task1(_input, CancellationToken.None);

        // Assert

        Assert.Equal("21", result);
    }

    [Fact]
    public async Task Test2()
    {
        // Arrange
        // Act

        string result = await _solutionUnderTest.Task2(_input, CancellationToken.None);

        // Assert

        Assert.Equal("expected", result);
    }
}