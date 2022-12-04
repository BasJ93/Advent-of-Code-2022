using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode.Base.Extensions;
using AdventOfCode.Base.Interfaces;
using AdventOfCode.Helpers;

namespace AdventOfCode.Base.Implementations;

public sealed class TaskRunner : ITaskRunner
{
    public async Task RunDay(int dayToRun, CancellationToken ctx)
    {
        DateTime date = DateTime.Today;

        if (dayToRun != 0)
        {
            date = DateTime.Parse($"2022-12-{dayToRun}");
        }

        var factory = new SolutionFactory();
        ISolution solver = factory.GetSolutionClass(date);

        if (solver != null)
        {
            Console.WriteLine($"Running solver for Day [{date.Day}]");

            var input = InputReader.ReadFromInputFile(date.Day).ToList();

            await RunTask1(solver, input, ctx);

            await RunTask2(solver, input, ctx);
        }
        else
        {
            Console.WriteLine("No solver for specified day found");
        }
    }

    private async Task RunTask1(ISolution solver, IEnumerable<string> input, CancellationToken ctx)
    {
        Stopwatch stopwatch = new Stopwatch();
        try
        {
            stopwatch.Start();

            var result1 = await solver.Task1(input, ctx);

            stopwatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopwatch.Elapsed;

            // Display the TimeSpan value.
            Console.WriteLine($"Task1: [{result1}] (Time: [{ts.ToElapsedTime()}])");
        }
        catch (NotImplementedException)
        {
            stopwatch.Stop();
        }
        catch (Exception ex)
        {
            stopwatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopwatch.Elapsed;

            // Display the TimeSpan value.
            Console.WriteLine($"Task1 threw exception [{ex}] (Time: [{ts.ToElapsedTime()}])");
        }
    }

    private async Task RunTask2(ISolution solver, IEnumerable<string> input, CancellationToken ctx)
    {
        Stopwatch stopwatch = new Stopwatch();
        try
        {
            stopwatch.Start();

            var result2 = await solver.Task2(input, ctx);

            stopwatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopwatch.Elapsed;

            // Display the TimeSpan value.
            Console.WriteLine($"Task2: [{result2}] (Time: [{ts.ToElapsedTime()}])");
        }
        catch (NotImplementedException)
        {
            stopwatch.Stop();
        }
        catch (Exception ex)
        {
            stopwatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopwatch.Elapsed;

            // Display the TimeSpan value.
            Console.WriteLine($"Task2 threw exception [{ex}] (Time: [{ts.ToElapsedTime()}])");
        }
    }
}