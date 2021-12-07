using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    public partial class Dec05 : BaseSolution, IPart1Solution<int>, IPart2Solution<int>
    {

        List<string> inputFile;

        public override DayEnum Day => DayEnum.Dec05;

        public int Part01Solution()
        {
            CoordinateCollection collection = new CoordinateCollection(inputFile);
            return collection.TallVents;
        }

        public int Part02Solution()
        {
            CoordinateCollection collection = new CoordinateCollection(inputFile, false);
            return collection.TallVents;
        }

        public void SetPart01()
        {
            inputFile = ReadInputFiles.SimpleReadPerLine(Part01FileName);
        }

        public void SetPart02()
        {
            SetPart01();
        }
    }
}
