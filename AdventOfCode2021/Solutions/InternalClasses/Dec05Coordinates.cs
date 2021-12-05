using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    public partial class Dec05
    {
        internal class CoordinateCollection
        {
            HashSet<Coordinate> Coordinates;

            public int TallVents
            {
                get
                {
                    int counter = 0;
                    foreach (var item in Coordinates)
                    {
                        if (item.Counter > 1)
                        {
                            counter++;
                        }
                    }
                    return counter;
                }
            }

            public CoordinateCollection(List<string> stringCoordinates, bool part1 = true)
            {
                Coordinates = new HashSet<Coordinate>();
                foreach (var coordinate in stringCoordinates)
                {
                    AddCoordinates(coordinate, part1);
                }
            }

            private void AddCoordinates(string coordinateString, bool part1)
            {
                string[] tempSplit = coordinateString.Split(" -> ");
                Coordinate start = new Coordinate(tempSplit[0]);
                Coordinate end = new Coordinate(tempSplit[1]);

                if (start.X == end.X || start.Y == end.Y)
                {
                    AddHorizontalOrVerticalCoordinates(start, end);
                }
                else if (!part1)
                {
                    AddDiagonalCoordinates(start, end);
                }
            }

            private void AddDiagonalCoordinates(Coordinate start, Coordinate end)
            {
                int xDir = end.X > start.X ? 1 : -1;
                int yDir = end.Y > start.Y ? 1 : -1;

                int currX = start.X;
                int currY = start.Y;

                while (!end.Equals(currX - xDir, currY - yDir))
                {
                    AddToCoordinates(new Coordinate(currX, currY));
                    currX += xDir;
                    currY += yDir;
                }
            }

            private void AddHorizontalOrVerticalCoordinates(Coordinate start, Coordinate end)
            {
                int minX = Math.Min(start.X, end.X);
                int maxX = Math.Max(start.X, end.X);
                int minY = Math.Min(start.Y, end.Y);
                int maxY = Math.Max(start.Y, end.Y);

                for (int X = minX; X <= maxX; X++)
                {
                    for (int Y = minY; Y <= maxY; Y++)
                    {
                        AddToCoordinates(new Coordinate(X, Y));
                    }
                }
            }

            private void AddToCoordinates(Coordinate coordinate)
            {
                if(Coordinates.TryGetValue(coordinate, out Coordinate existing))
                {
                    existing.AddVent();
                }
                else
                {
                    Coordinates.Add(coordinate);
                    coordinate.AddVent();
                }
            }
        }

        internal class Coordinate : IEquatable<Coordinate>
        {
            public int X { get; init; }
            public int Y { get; init; }

            public int Counter { get; private set; }

            public Coordinate(string coordinate)
            {
                string[] splitCoordinate = coordinate.Split(',');
                string stringX = splitCoordinate[0].Trim();
                string stringY = splitCoordinate[1].Trim();
                X = int.Parse(stringX);
                Y = int.Parse(stringY);
                Counter = 0;
            }

            public Coordinate(int x, int y)
            {
                this.X = x;
                this.Y = y;
                Counter = 0;
            }

            public void AddVent()
            {
                Counter++;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }

            public bool Equals(Coordinate other)
            {
                return this.X == other.X && this.Y == other.Y;
            }

            public bool Equals(int x, int y)
            {
                return this.X == x && this.Y == y;
            }
        }
    }
}
