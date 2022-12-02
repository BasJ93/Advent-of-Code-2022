using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode.Base.Interfaces;
using AdventOfCode2022.Solutions;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day2Tests
{
    [Fact]
    public async Task Test1()
    {
        // Arrange

        List<string> input = new ()
        {
            "A Y",
            "B X",
            "C Z"
        };

        // Act

        ISolution solutionUnderTest = new Day2();

        long result = await solutionUnderTest.Task1(input, CancellationToken.None);
        
        // Assert
        
        Assert.Equal(15, result);
    }
    
    [Fact]
    public async Task Test2()
    {
        // Arrange

        List<string> input = new ()
        {
            "A Y",
            "B X",
            "C Z"
        };

        // Act

        ISolution solutionUnderTest = new Day2();

        long result = await solutionUnderTest.Task2(input, CancellationToken.None);
        
        // Assert
        
        Assert.Equal(12, result);
    }
}