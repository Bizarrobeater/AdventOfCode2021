﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    public interface ISolution
    {
        public string InputFileName { get; set; }

        public void SetPart01(string inputFileName);
        public void SetPart02(string inputFileName);


    }
}
