using System;
using AdventOfCode2021.Solutions;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunPart1<Dec06, long>(false);
            RunPart2<Dec06, long>(false);
        }

        private static void RunPart1<T, U>(bool testRun, bool useFile = true) where T: BaseSolution, IPart1Solution<U>,  new()
        {
            var sol = new T();
            sol.Test = testRun;
            if (useFile)
            {
                sol.SetPart01();
            }
            Console.WriteLine(sol.Part01Solution());
        }

        private static void RunPart2<T, U>(bool testRun, bool useFile = true) where T: BaseSolution, IPart2Solution<U>, new()
        {
            var sol = new T();
            sol.Test = testRun;
            if (useFile)
            {
                sol.SetPart02();
            }
            Console.WriteLine(sol.Part02Solution());
        }
    }
}
