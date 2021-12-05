using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    public abstract class BaseSolution : ISolution
    {
        public abstract DayEnum Day { get; }

        public bool Test { get; set; }

        public string Part1FileName
        {
            get
            {
                string testPart = Test ? "Test" : "";
                return $"{Day}Part01{testPart}";
            }
        }
        public string Part2FileName
        {
            get
            {
                string testPart = Test ? "Test" : "";
                return $"{Day}Part02{testPart}";
            }
        }
    }
}
