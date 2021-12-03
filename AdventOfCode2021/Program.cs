using System;
using AdventOfCode2021.Solutions;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunPart1<Dec03, int>("03","01");
            RunPart2<Dec03, int>("03","01");
        }

        private static void RunPart1<T, U>(string fileDay, string filePart, bool useFile = true) where T: IPart1Solution<U>, new()
        {
            var sol = new T();
            if (useFile)
            {
                sol.SetPart01($"Dec{fileDay}Part{filePart}");
            }
            Console.WriteLine(sol.Part01Solution());
        }

        private static void RunPart2<T, U>(string fileDay, string filePart, bool useFile = true) where T: IPart2Solution<U>, new()
        {
            var sol = new T();
            if (useFile)
            {
                sol.SetPart02($"Dec{fileDay}Part{filePart}");
            }
            Console.WriteLine(sol.Part02Solution());
        }
    }
}
