using System;

namespace AdventOfCode.Base.Extensions;

public static class TimeSpanExtensions
{
    /// <summary>
    /// Format a timespan in to a standard time string.
    /// </summary>
    /// <param name="ts">The timespan to format.</param>
    /// <returns>The formatted string.</returns>
    public static string ToElapsedTime(this TimeSpan ts)
    {
        return String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
    }
}