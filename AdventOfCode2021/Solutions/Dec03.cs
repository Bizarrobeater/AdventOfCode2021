using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    public class Dec03 : IPart1Solution<int>, IPart2Solution<int>
    {
        List<int[]> inputFile;
        public int Part01Solution()
        {
            int listLength = inputFile.Count;
            int inputLength = inputFile[0].Length;

            int adder;

            string gammaRate = "";
            string epsilonRate = "";
            for (int y = 0; y < inputLength; y++)
            {
                adder = 0;
                foreach (var item in inputFile)
                {
                    adder += item[y];
                }
                if (adder > listLength / 2)
                {
                    gammaRate += "1";
                    epsilonRate += "0";
                }
                else
                {
                    gammaRate += "0";
                    epsilonRate += "1";
                }
            }

            return Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);

        }

        public int Part02Solution()
        {
            return OxygenRating() * Co2Rating();
        }

        private int OxygenRating()
        {
            int inputLength = inputFile[0].Length;

            List<int[]> zeroes;
            List<int[]> ones;
            List<int[]> inUse;


            int adder;
            inUse = inputFile;
            for (int y = 0; y < inputLength; y++)
            {
                adder = 0;
                zeroes = new List<int[]>();
                ones = new List<int[]>();

                foreach (var item in inUse)
                {
                    if (item[y] == 1)
                    {
                        ones.Add(item);
                    }
                    else
                    {
                        zeroes.Add(item);
                    }
                    adder += item[y];
                }

                if (adder >= (inUse.Count / 2 + inUse.Count % 2))
                {
                    inUse = ones;
                }
                else
                {
                    inUse = zeroes;
                }

                if (inUse.Count == 1)
                {
                    break;
                }
            }

            return Convert.ToInt32(string.Join("", inUse[0]), 2);
        }

        private int Co2Rating()
        {
            int inputLength = inputFile[0].Length;

            List<int[]> zeroes;
            List<int[]> ones;
            List<int[]> inUse;


            int adder;
            inUse = inputFile;
            for (int y = 0; y < inputLength; y++)
            {
                adder = 0;
                zeroes = new List<int[]>();
                ones = new List<int[]>();

                foreach (var item in inUse)
                {
                    if (item[y] == 1)
                    {
                        ones.Add(item);
                    }
                    else
                    {
                        zeroes.Add(item);
                    }
                    adder += item[y];
                }

                if (adder >= (inUse.Count / 2 + inUse.Count % 2))
                {
                    inUse = zeroes;
                }
                else
                {
                    inUse = ones;
                }

                if (inUse.Count == 1)
                {
                    break;
                }
            }

            return Convert.ToInt32(string.Join("", inUse[0]), 2);
        }

        public void SetPart01(string inputFileName)
        {
            var temp = ReadInputFiles.SimpleReadPerLine(inputFileName);
            inputFile = new List<int[]>();

            int[] part;
            char[] charTemp;
            foreach (var item in temp)
            {
                charTemp = item.ToCharArray();
                part = new int[charTemp.Length];
                for (int i = 0; i < charTemp.Length; i++)
                {
                    part[i] = int.Parse(charTemp[i].ToString());
                }
                inputFile.Add(part);
            }
        }

        public void SetPart02(string inputFileName)
        {
            SetPart01(inputFileName);
        }
    }
}
