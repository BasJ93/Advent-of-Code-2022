using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode.Base.Interfaces;

public interface ITaskRunner
{
    Task RunDay(int dayToRun, CancellationToken ctx);
}