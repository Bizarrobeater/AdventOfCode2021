using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    public class Dec01 : ISolution
    {
        List<string> inputFile;
        public string InputFileName { get; set; }

        public Dec01()
        {
        }

        public string Part01Solution()
        {
            int counter = 0;
            for (int i = 1; i < inputFile.Count; i++)
            {
                if (int.Parse(inputFile[i]) > int.Parse(inputFile[i-1]))
                {
                    counter++;
                }
            }
            return counter.ToString();
        }

        public string Part02Solution()
        {
            List<int> newList = new List<int>();

            for (int i = 0; i < inputFile.Count - 2; i++)
            {
                newList.Add(int.Parse(inputFile[i]) + int.Parse(inputFile[i + 1]) + int.Parse(inputFile[i + 2]));
            }


            int counter = 0;

            for (int i = 1; i < newList.Count; i++)
            {
                if (newList[i] > newList[i -1])
                {
                    counter++;
                }
            }
            return counter.ToString();
        }

        public void SetPart01(string inputFileName)
        {
            InputFileName = inputFileName;
            inputFile = ReadInputFiles.SimpleReadPerLine(InputFileName);
        }

        public void SetPart02(string inputFileName)
        {
            SetPart01(inputFileName);
        }
    }
}
