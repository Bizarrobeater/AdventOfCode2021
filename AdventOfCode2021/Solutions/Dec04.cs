using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    public partial class Dec04 : BaseSolution, IPart1Solution<int>, IPart2Solution<int>
    {
        int[] bingoNumbers;

        List<BingoPlate> bingoPlates;

        public override DayEnum Day => DayEnum.Dec04;

        public Dec04()
        {
            bingoPlates = new List<BingoPlate>();
        }



        public int Part01Solution()
        {
            int currNumber;
            BingoPlate currPlate;

            for (int i = 0; i < bingoNumbers.Length; i++)
            {
                currNumber = bingoNumbers[i];
                for (int j = 0; j < bingoPlates.Count; j++)
                {
                    currPlate = bingoPlates[j];
                    currPlate.CallNumber(currNumber);
                    if (currPlate.Bingo)
                    {
                        return currPlate.SumUnMarked * currNumber;
                    }
                }
            }
            return -1;
        }

        public int Part02Solution()
        {
            List<BingoPlate> notWonPlates = bingoPlates;

            List<BingoPlate> tempLosers;
            int currNumber;
            BingoPlate currPlate;

            for (int i = 0; i < bingoNumbers.Length; i++)
            {
                tempLosers = new List<BingoPlate>();
                currNumber = bingoNumbers[i];
                for (int j = 0; j < notWonPlates.Count; j++)
                {
                    currPlate = notWonPlates[j];
                    currPlate.CallNumber(currNumber);
                    if (!currPlate.Bingo)
                    {
                        tempLosers.Add(currPlate);
                    }
                    else if (notWonPlates.Count == 1)
                    {
                        return notWonPlates[0].SumUnMarked * currNumber;
                    }
                }
                notWonPlates = tempLosers;
            }
            return -1;
        }

        public void SetPart01()
        {
            string all = ReadInputFiles.ReadAllAsString(Part01FileName);

            string[] split = all.Split($"{Environment.NewLine}{Environment.NewLine}");

            string[] stringBingoNumbers = split[0].Split(",");

            bingoNumbers = new int[stringBingoNumbers.Length];

            for (int i = 0; i < stringBingoNumbers.Length; i++)
            {
                bingoNumbers[i] = int.Parse(stringBingoNumbers[i].Trim());
            }

            for (int i = 1; i < split.Length; i++)
            {
                bingoPlates.Add(new BingoPlate(split[i].Trim()));
            }
        }

        public void SetPart02()
        {
            SetPart01();
        }
    }
}
