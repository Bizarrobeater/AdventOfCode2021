using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    public class Dec02 : BaseSolution, IPart1Solution<string>, IPart2Solution<string>
    {
        private List<string> inputFile;

        public override DayEnum Day => DayEnum.Dec02;

        public string Part01Solution()
        {
            int horizontal = 0;
            int depth = 0;
            string[] splitString;
            string direction;
            int value;
            foreach (var command in inputFile)
            {
                splitString = command.Split(' ');
                direction = splitString[0];
                value = int.Parse(splitString[1]);


                switch (direction)
                {
                    case "forward":
                        horizontal += value;
                        break;
                    case "up":
                        depth -= value;
                        break;
                    case "down":
                        depth += value;
                        break;
                }
            }

            return (horizontal * depth).ToString();
        }

        public string Part02Solution()
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;
            string[] splitString;
            string direction;
            int value;
            foreach (var command in inputFile)
            {
                splitString = command.Split(' ');
                direction = splitString[0];
                value = int.Parse(splitString[1]);


                switch (direction)
                {
                    case "forward":
                        horizontal += value;
                        depth += value * aim;
                        break;
                    case "up":
                        aim -= value;
                        break;
                    case "down":
                        aim += value;
                        break;
                }
            }

            return (horizontal * depth).ToString();
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
