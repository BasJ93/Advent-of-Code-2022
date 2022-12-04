using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode.Base.Interfaces;

namespace AdventOfCode2022.Solutions;

public class Day2 : ISolution
{
    // Scores
    private const int Win = 6;
    private const int Draw = 3;
    private const int Loss = 0;

    // Additional score based on chosen shape
    private const int Rock = 1;
    private const int Paper = 2;
    private const int Scissors = 3;

    // Rock beats scissors
    // Paper beats rock
    // Scissors beat paper

    // Rock is A and X
    // Paper is B and Y
    // Scissors is C and Z

    public async Task<long> Task1(IEnumerable<string> input, CancellationToken ctx)
    {
        long total = 0;

        foreach (string game in input)
        {
            string[] splitGame = game.Split(' ');

            string opponent = splitGame.First();
            string player = splitGame.Last();

            switch (opponent)
            {
                case "A":
                    switch (player)
                    {
                        case "X":
                            total += Draw + Rock;
                            break;
                        case "Y":
                            total += Win + Paper;
                            break;
                        case "Z":
                            total += Loss + Scissors;
                            break;
                    }

                    break;
                case "B":
                    switch (player)
                    {
                        case "X":
                            total += Loss + Rock;
                            break;
                        case "Y":
                            total += Draw + Paper;
                            break;
                        case "Z":
                            total += Win + Scissors;
                            break;
                    }

                    break;
                case "C":
                    switch (player)
                    {
                        case "X":
                            total += Win + Rock;
                            break;
                        case "Y":
                            total += Loss + Paper;
                            break;
                        case "Z":
                            total += Draw + Scissors;
                            break;
                    }

                    break;
            }
        }

        return total;
    }

    public async Task<long> Task2(IEnumerable<string> input, CancellationToken ctx)
    {
        long total = 0;

        foreach (string game in input)
        {
            string[] splitGame = game.Split(' ');

            string opponent = splitGame.First();
            string player = splitGame.Last();

            switch (opponent)
            {
                case "A": // Rock
                    switch (player)
                    {
                        case "X":
                            total += Loss + Scissors;
                            break;
                        case "Y":
                            total += Draw + Rock;
                            break;
                        case "Z":
                            total += Win + Paper;
                            break;
                    }

                    break;
                case "B": // Paper
                    switch (player)
                    {
                        case "X":
                            total += Loss + Rock;
                            break;
                        case "Y":
                            total += Draw + Paper;
                            break;
                        case "Z":
                            total += Win + Scissors;
                            break;
                    }

                    break;
                case "C": // Scissors
                    switch (player)
                    {
                        case "X":
                            total += Loss + Paper;
                            break;
                        case "Y":
                            total += Draw + Scissors;
                            break;
                        case "Z":
                            total += Win + Rock;
                            break;
                    }

                    break;
            }
        }

        return total;
    }
}