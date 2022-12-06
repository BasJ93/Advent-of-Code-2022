using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode.Base.Interfaces;
using AdventOfCode2022.Solutions;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day6Tests
{
    private readonly ISolution _solutionUnderTest;

    public Day6Tests()
    {
        _solutionUnderTest = new Day6();
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", "7")]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", "5")]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", "6")]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", "10")]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", "11")]
    public async Task Test1(string input, string expected)
    {
        // Arrange
        
        List<string> mInput = new ()
        {
            input,
        };
        
        // Act

        string result = await _solutionUnderTest.Task1(mInput, CancellationToken.None);

        // Assert

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", "19")]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", "23")]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", "23")]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", "29")]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", "26")]
    public async Task Test2(string input, string expected)
    {
        // Arrange
        
        List<string> mInput = new ()
        {
            input,
        };
        
        // Act

        string result = await _solutionUnderTest.Task2(mInput, CancellationToken.None);

        // Assert

        Assert.Equal(expected, result);
    }
}