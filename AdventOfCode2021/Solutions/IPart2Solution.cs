using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    public interface IPart2Solution<T> : ISolution
    {
        public T Part02Solution();
        public void SetPart02();
}
}
