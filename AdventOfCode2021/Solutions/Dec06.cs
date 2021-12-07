using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    public partial class Dec06 : BaseSolution, IPart1Solution<long>, IPart2Solution<long>
    {
        public override DayEnum Day => DayEnum.Dec06;

        public List<int> startFish;

        public long Part01Solution()
        {
            return GenericSolution();
        }

        public long GenericSolution(bool part1 = true)
        {

            int days = part1 ? 80 : 256;
            HashSet<LanternFishGroup> fishGroups = SetStartGroup();



            LanternFishGroup currGroup;
            LanternFishGroup tempFish;
            HashSet<LanternFishGroup> tempFishGroups; ;


            for (int day = 0; day < days; day++)
            {
                tempFishGroups = new HashSet<LanternFishGroup>();
                for (int i = 8; i >= 0; i--)
                {
                    currGroup = new LanternFishGroup(i);

                    fishGroups.TryGetValue(currGroup, out currGroup);
                    tempFish = new LanternFishGroup(currGroup);
                    if (currGroup.Day > 0)
                    {
                        tempFish.Day--;
                    }
                    else
                    {
                        tempFish.Day = 8;

                        tempFishGroups.TryGetValue(new LanternFishGroup(6), out currGroup);
                        currGroup.FishAmount += tempFish.FishAmount;
                    }
                    tempFishGroups.Add(tempFish);
                }
                fishGroups = new HashSet<LanternFishGroup>(tempFishGroups);
            }

            long amountFish = 0;
            foreach (var fish in fishGroups)
            {
                amountFish += fish.FishAmount;
            }

            return amountFish;
        }



        private HashSet<LanternFishGroup> SetBlankGroups()
        {
            return new HashSet<LanternFishGroup>()
            {
                new LanternFishGroup(0),
                new LanternFishGroup(1),
                new LanternFishGroup(2),
                new LanternFishGroup(3),
                new LanternFishGroup(4),
                new LanternFishGroup(5),
                new LanternFishGroup(6),
                new LanternFishGroup(7),
                new LanternFishGroup(8),
            };
        }

        private HashSet<LanternFishGroup> SetStartGroup()
        {
            var newGroups = SetBlankGroups();

            LanternFishGroup currGroup;

            foreach (var fish in startFish)
            {
                currGroup = new LanternFishGroup(fish);
                newGroups.TryGetValue(currGroup, out currGroup);
                currGroup.FishAmount++;
            }
            return newGroups;
        }

        public void SetPart01()
        {
            var list = ReadInputFiles.SimpleReadPerLine(Part01FileName);
            var listFishString = list[0].Split(',');
            startFish = new List<int>();

            foreach (var fish in listFishString)
            {
                startFish.Add(int.Parse(fish));
            }
        }

        public long Part02Solution()
        {
            return GenericSolution(false);
        }

        public void SetPart02()
        {
            SetPart01();
        }
    }
}
