using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    public interface IPart1Solution<T> : ISolution
    {
        public T Part01Solution();
        public void SetPart01(string inputFileName);
    }
}
