using System;
using System.Collections.Immutable;
using AdventOfCode.Helpers;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode.Base.Implementations;
using AdventOfCode.Base.Interfaces;

namespace AdventOfCode2022
{
    class Program
    {
        // TODO: Add appsettings to provide the directory with input data
        static async Task<int> Main(string[] args)
        {
            var rootCommand = new RootCommand();

            var dayOption = new Option<int>(
                "--dayToRun",
                getDefaultValue: () => 0,
                description: "The day to run"
            );

            rootCommand.Add(dayOption);

            rootCommand.Description = "Advent of Code 2021";

            // rootCommand.Handler = new DayCommandHandler();

            rootCommand.SetHandler((dayToRun) => RunDay(dayToRun, new CancellationToken()), dayOption);

            return rootCommand.InvokeAsync(args).Result;
        }

        private static async Task RunDay(int dayToRun, CancellationToken ctx)
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

                var input = InputReader.ReadFromInputFile(date.Day).ToImmutableList();

                Stopwatch stopwatch1 = new Stopwatch();
                try
                {
                    stopwatch1.Start();

                    var result1 = await solver.Task1(input, ctx);

                    stopwatch1.Stop();

                    // Get the elapsed time as a TimeSpan value.
                    TimeSpan ts = stopwatch1.Elapsed;

                    // Format and display the TimeSpan value.
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
                    Console.WriteLine($"Task1: [{result1}] (Time: [{elapsedTime}])");
                }
                catch (NotImplementedException)
                {
                }
                catch (Exception ex)
                {
                    stopwatch1.Stop();

                    // Get the elapsed time as a TimeSpan value.
                    TimeSpan ts = stopwatch1.Elapsed;

                    // Format and display the TimeSpan value.
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
                    Console.WriteLine($"Task1 threw exception [{ex.ToString()}] (Time: [{elapsedTime}])");
                }

                Stopwatch stopwatch2 = new Stopwatch();
                try
                {
                    stopwatch2.Start();

                    var result2 = await solver.Task2(input, ctx);

                    stopwatch2.Stop();

                    // Get the elapsed time as a TimeSpan value.
                    TimeSpan ts = stopwatch2.Elapsed;

                    // Format and display the TimeSpan value.
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);

                    Console.WriteLine($"Task2: [{result2}] (Time: [{elapsedTime}])");
                }
                catch (NotImplementedException)
                {
                }
                catch (Exception ex)
                {
                    stopwatch2.Stop();

                    // Get the elapsed time as a TimeSpan value.
                    TimeSpan ts = stopwatch2.Elapsed;

                    // Format and display the TimeSpan value.
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
                    Console.WriteLine($"Task2 threw exception [{ex.ToString()}] (Time: [{elapsedTime}])");
                }
            }
            else
            {
                Console.WriteLine("No solver for specified day found");
            }
        }
    }
}

internal class DayCommandHandler : ICommandHandler
{
    public int DayToRun { get; set; }

    public int Invoke(InvocationContext context)
    {
        throw new NotImplementedException();
    }

    public async Task<int> InvokeAsync(InvocationContext context)
    {
        DateTime date = DateTime.Today;

        if (DayToRun != 0)
        {
            date = DateTime.Parse($"2022-12-{DayToRun}");
        }

        var factory = new SolutionFactory();
        ISolution solver = factory.GetSolutionClass(date);

        if (solver != null)
        {
            Console.WriteLine($"Running solver for Day [{date.Day}]");

            var input = InputReader.ReadFromInputFile(date.Day).ToImmutableList();

            Stopwatch stopwatch1 = new Stopwatch();
            try
            {
                stopwatch1.Start();

                var result1 = await solver.Task1(input, context.GetCancellationToken());

                stopwatch1.Stop();

                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopwatch1.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine($"Task1: [{result1}] (Time: [{elapsedTime}])");
            }
            catch (NotImplementedException)
            {
            }
            catch (Exception ex)
            {
                stopwatch1.Stop();

                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopwatch1.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine($"Task1 threw exception [{ex.ToString()}] (Time: [{elapsedTime}])");
            }

            Stopwatch stopwatch2 = new Stopwatch();
            try
            {
                stopwatch2.Start();

                var result2 = await solver.Task2(input, context.GetCancellationToken());

                stopwatch2.Stop();

                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopwatch2.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);

                Console.WriteLine($"Task2: [{result2}] (Time: [{elapsedTime}])");
            }
            catch (NotImplementedException)
            {
            }
            catch (Exception ex)
            {
                stopwatch2.Stop();

                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopwatch2.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine($"Task2 threw exception [{ex.ToString()}] (Time: [{elapsedTime}])");
            }
        }
        else
        {
            Console.WriteLine("No solver for specified day found");
        }

        return 0;
    }
}