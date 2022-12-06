using System;

namespace AdventOfCode.Helpers;

public static class SlidingWindow
{
    /// <summary>
    /// Method to create a sliding window on a string and execute the Func on it. Windows is selected by end index (windowSize).
    /// </summary>
    /// <param name="input">The string to slide the windows through.</param>
    /// <param name="windowSize">The size of the window.</param>
    /// <param name="checker">A Func delegate to execute on the window.</param>
    /// <typeparam name="TResult">The return type.</typeparam>
    /// <returns>The result of <param name="checker"></param></returns>
    /// <exception cref="InvalidProgramException">If the end of the string is reached without the checker succeeding.</exception>
    public static TResult SlidingEndWindow<TResult>(this string input, int windowSize, Func<string, int, SlidingResult<TResult>> checker)
    {
        for (int i = windowSize; i < input.Length; i++)
        {
            string window = input[(i - windowSize)..i];
                
            SlidingResult<TResult> result = checker.Invoke(window, i);

            if (result.Success)
            {
                return result.Result;
            }
        }
        
        throw new InvalidProgramException();
    }
}

sealed public class SlidingResult<TResult>
{
    public bool Success { get; set; }
    public TResult Result { get; set; }

    public SlidingResult(bool success, TResult result)
    {
        Success = success;
        Result = result;
    }
} 