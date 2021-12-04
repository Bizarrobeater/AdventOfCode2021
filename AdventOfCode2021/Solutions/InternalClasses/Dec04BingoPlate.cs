using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions
{
    public partial class Dec04
    {
        internal class BingoPlate
        {
            internal BingoLine[] rows;
            internal BingoLine[] columns;

            public bool Bingo
            {
                get
                {
                    foreach (var row in rows)
                    {
                        if (row.LineFull)
                        {
                            return true;
                        }
                    }
                    foreach (var column in columns)
                    {
                        if (column.LineFull)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }

            public int SumUnMarked
            {
                get
                {
                    int counter = 0;
                    foreach (var row in rows)
                    {
                        counter += row.SumUnmarked;
                    }
                    return counter;
                }
            }



            internal BingoPlate(string plateString)
            {
                string[] splitRowPlate = plateString.Split(Environment.NewLine);
                PrepateBingoLines(splitRowPlate.Length, GetColumns(splitRowPlate[0]));


                string[,] splitFullPlate = new string[rows.Length, columns.Length];

                string[] tempColumn;
                BingoNumber tempNumber;
                for (int i = 0; i < splitRowPlate.Length; i++)
                {
                    tempColumn = SplitRow(splitRowPlate[i]);
                    for (int j = 0; j < tempColumn.Length; j++)
                    {
                        tempNumber = new BingoNumber(tempColumn[j]);
                        rows[i].AddNumber(tempNumber);
                        columns[j].AddNumber(tempNumber);
                    }
                }
            }

            public void PrepateBingoLines(int rowLength, int columnLength)
            {
                rows = new BingoLine[rowLength];
                columns = new BingoLine[columnLength];
                for (int i = 0; i < rowLength; i++)
                {
                    rows[i] = new BingoLine();
                }
                for (int i = 0; i < columnLength; i++)
                {
                    columns[i] = new BingoLine();
                }

            }

            public void CallNumber(int calledNumber)
            {
                foreach (var row in rows)
                {
                    row.CallNumber(calledNumber);
                }
            }

            private string[] SplitRow(string unsplitRow)
            {
                string tempString = unsplitRow.Replace("  ", " ").Trim();
                return tempString.Split(' ');
            }

            private int GetColumns(string unsplitRow)
            {
                return SplitRow(unsplitRow).Length;
            }
        }

        internal class BingoLine
        {
            List<BingoNumber> numbers;

            public bool LineFull
            {
                get
                {
                    foreach (var number in numbers)
                    {
                        if (!number.Marked)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            public int SumUnmarked
            {
                get
                {
                    int counter = 0;
                    foreach (var number in numbers)
                    {
                        counter += number.Marked ? 0 : number.Number;
                    }
                    return counter;
                }
            }

            public BingoLine()
            {
                numbers = new List<BingoNumber>();
            }

            public void AddNumber(BingoNumber number)
            {
                numbers.Add(number);
            }

            public void CallNumber(int calledNumber)
            {
                foreach (var number in numbers)
                {
                    if (!number.Marked)
                    {
                        number.CheckNumber(calledNumber);
                    }
                }
            }

        }

        internal class BingoNumber
        {
            internal int Number { get; }
            internal bool Marked { get; set;}

            internal BingoNumber(int number)
            {
                Number = number;
                Marked = false;
            }

            internal BingoNumber(string stringNumber)
                : this(int.Parse(stringNumber))
            {

            }

            internal void CheckNumber(int calledNumber)
            {
                Marked = Number == calledNumber;
            }
        }
    }
}
