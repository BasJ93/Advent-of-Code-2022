using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode.Base.Interfaces;
using AdventOfCode2022.Solutions;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day1Tests
{
    [Fact]
    public async Task Test1()
    {
        // Arrange

        List<string> input = new ()
        {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000"
        };

        // Act

        ISolution solutionUnderTest = new Day1();

        string result = await solutionUnderTest.Task1(input, CancellationToken.None);
        
        // Assert
        
        Assert.Equal("24000", result);
    }
    
    [Fact]
    public async Task Test2()
    {
        // Arrange

        List<string> input = new ()
        {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000"
        };

        // Act

        ISolution solutionUnderTest = new Day1();

        string result = await solutionUnderTest.Task2(input, CancellationToken.None);
        
        // Assert
        
        Assert.Equal("45000", result);
    }
}