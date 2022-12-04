using System;
using System.Reflection;
using AdventOfCode.Base.Interfaces;

namespace AdventOfCode.Base.Implementations
{
    public class SolutionFactory
    {
        public ISolution GetSolutionClass(DateTime dateTime)
        {
            int day = dateTime.Day;

            Assembly assembly = Assembly.GetEntryAssembly();

            if (assembly == null)
            {
                throw new DllNotFoundException();
            }
            
            ISolution dayClass = (ISolution)assembly.CreateInstance($"{assembly.GetName().Name}.Solutions.Day{day}");

            return dayClass;
        }
    }
}