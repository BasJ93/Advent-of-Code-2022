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
                name: "--dayToRun",
                getDefaultValue: () => 0,
                description: "The day to run"
            );
            
            dayOption.AddAlias("-d");

            rootCommand.Add(dayOption);

            rootCommand.Description = "Advent of Code 2022";

            // rootCommand.Handler = new DayCommandHandler();

            ITaskRunner taskRunner = new TaskRunner();

            rootCommand.SetHandler((dayToRun) => taskRunner.RunDay(dayToRun, new CancellationToken()), dayOption);

            return rootCommand.InvokeAsync(args).Result;
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
        //context.

        return 0;
    }
}