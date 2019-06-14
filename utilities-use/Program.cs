using System;
using System.Diagnostics;
using System.Threading;
using utilities_bucket;

namespace utilities_use
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(IamAGiraffe() + " is the method name");
            Console.WriteLine();
            Stopwatch.StartNew().Measure(DoSomething, elapsed => Console.WriteLine(nameof(DoSomething) + " lasted " + elapsed + " seconds."));
            Console.ReadLine();
        }

        private static string IamAGiraffe()
        {
            return Utility.GetCallerMemberName();
        }

        private static void DoSomething()
        {
            Thread.Sleep(41523);
        }
    }
}
