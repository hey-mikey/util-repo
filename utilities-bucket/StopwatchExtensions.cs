using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace utilities_bucket
{
    /// <summary>
    /// Building off of a suggestion on
    /// https://codereview.stackexchange.com/a/197977/94871
    /// </summary>
    public static class StopwatchExtensions
    {
        /// <summary>
        /// Usage:
        /// Stopwatch.StartNew().Measure(DoSomething, elapsed => Console.WriteLine(elapsed));
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stopwatch"></param>
        /// <param name="action"></param>
        /// <param name="elapsed"></param>
        /// <returns></returns>
        public static T Measure<T>(this Stopwatch stopwatch, Func<T> action, Action<TimeSpan> elapsed)
        {
            try
            {
                return action();
            }
            finally
            {
                elapsed(stopwatch.Elapsed);
            }
        }

        public static void Measure(this Stopwatch stopwatch, Action action, Action<TimeSpan> elapsed)
        {
            stopwatch.Measure<object>(() => { action(); return default; }, elapsed);
        }

        /// <summary>
        /// Usage: Stopwatch.StartNew().Measure(DoSomething, ConsoleHelper.WriteElapsed(nameof(DoSomething)));
        /// </summary>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public static Action<TimeSpan> WriteElapsed(string memberName)
        {
            return elapsed => Console.WriteLine($"'{memberName}' executed in {elapsed}");
        }
    }
}
