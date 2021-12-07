using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    public class Dec07 : BaseSolution, IPart1Solution<int>, IPart2Solution<long>
    {
        List<int> startInput;

        public override DayEnum Day => DayEnum.Dec07;

        public int Part01Solution()
        {
            int listLength = startInput.Count;
            int halfLength = listLength % 2 == 1 ? (listLength / 2) + 1 : listLength / 2;

            int median = startInput[halfLength];
            int fuelTotal = 0;

            foreach (var crab in startInput)
            {
                fuelTotal += Math.Abs(crab - median);
            }
            return fuelTotal;
        }

        public long Part02Solution()
        {
            int average = (int)startInput.Average();



            long fuelTotal = 0;
            int fueldTemp;

            foreach (var crab in startInput)
            {
                fueldTemp = Math.Abs(crab - average);
                fuelTotal += (fueldTemp * (fueldTemp + 1)) / 2;
            }



            return fuelTotal;
        }

        public void SetPart01()
        {
            startInput = new List<int>();
            var inputString = ReadInputFiles.InputOneLine(Part01FileName);
            var listInputString = inputString.Split(',');
            foreach (var item in listInputString)
            {
                startInput.Add(int.Parse(item));
            }
            startInput.Sort();
        }

        public void SetPart02()
        {
            SetPart01();
        }
    }
}
