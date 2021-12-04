using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class ReadInputFiles
    {
        public static List<string> SimpleReadPerLine(string fileName)
        {
            var result = new List<string>();

            foreach (string line in File.ReadLines($"InputFiles\\{fileName}.txt"))
            {
                result.Add(line);
            }
            return result;
        }

        public static string ReadAllAsString(string fileName)
        {
            return File.ReadAllText($"InputFiles\\{fileName}.txt");
        }
    }
}
