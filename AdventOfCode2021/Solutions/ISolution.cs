using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    public interface ISolution
    {
        DayEnum Day { get; }

        bool Test { get; set; }
    }
}
