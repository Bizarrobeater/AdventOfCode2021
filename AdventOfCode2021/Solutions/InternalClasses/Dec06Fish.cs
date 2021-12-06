using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    public partial class Dec06
    {
        internal class LanternFishGroup : IEquatable<int>, IEquatable<LanternFishGroup>
        {
            public int Day { get; set; }

            public long FishAmount { get; set; }

            public LanternFishGroup(int day)
            {
                Day = day;
                FishAmount = 0;
            }

            public LanternFishGroup(LanternFishGroup fishGroup)
            {
                Day = fishGroup.Day;
                FishAmount = fishGroup.FishAmount;
            }

            public override int GetHashCode()
            {
                return Day;
            }

            public bool Equals(int other)
            {
                return Day == other;
            }

            public bool Equals(LanternFishGroup other)
            {
                return Equals(other.Day);
            }
        }
    }
}
