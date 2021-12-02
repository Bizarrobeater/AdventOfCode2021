using System;
using AdventOfCode2021.Solutions;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunPart1<Dec02, string>("02","01");
            //RunPart2<Dec02, string>("02","01");
        }

        private static void RunPart1<T, U>(string fileDay, string filePart, bool useFile = false) where T: IPart1Solution<U>, new()
        {
            var sol = new T();
            if (useFile)
            {
                sol.SetPart01($"Dec{fileDay}Part{filePart}");
            }
            Console.WriteLine(sol.Part01Solution());
        }

        private static void RunPart2<T, U>(string fileDay, string filePart, bool useFile = false) where T: IPart1Solution<U>, new()
        {
            var sol = new Dec02();
            if (useFile)
            {
                sol.SetPart02($"Dec{fileDay}Part{filePart}");
            }
            Console.WriteLine(sol.Part02Solution());
        }
    }
}
