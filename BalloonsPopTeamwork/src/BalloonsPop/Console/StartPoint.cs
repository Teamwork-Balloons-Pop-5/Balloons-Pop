namespace BalloonsPop.Console
{
    using System;
    using System.Collections.Generic;
    
    using Common.Constants;
    using GameLogic;

    public class StartPoint
    {
        public static byte[,] GenerateBalloons(byte rows, byte columns)
        {
            byte[,] balloonsMatrix = new byte[rows, columns];
            Random randomNumber = new Random();

            for (byte row = 0; row < rows; row++)
            {
                for (byte column = 0; column < columns; column++)
                {
                    byte numberToInsert = (byte)randomNumber.Next(1, 5);
                    balloonsMatrix[row, column] = numberToInsert;
                }
            }

            return balloonsMatrix;
        }

        public static void CheckLeft(byte[,] balloonsMatrix, int row, int column, int searchedItem)
        {
            int newRow = row;
            int newColumn = column - 1;
            try
            {
                if (balloonsMatrix[newRow, newColumn] == searchedItem)
                {
                    balloonsMatrix[newRow, newColumn] = 0;
                    CheckLeft(balloonsMatrix, newRow, newColumn, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        public static void CheckRight(byte[,] balloonsMatrix, int row, int column, int searchedItem)
        {
            int newRow = row;
            int newColumn = column + 1;
            try
            {
                if (balloonsMatrix[newRow, newColumn] == searchedItem)
                {
                    balloonsMatrix[newRow, newColumn] = 0;
                    CheckRight(balloonsMatrix, newRow, newColumn, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        public static void CheckUp(byte[,] balloonsMatrix, int row, int column, int searchedItem)
        {
            int newRow = row + 1;
            int newColumn = column;
            try
            {
                if (balloonsMatrix[newRow, newColumn] == searchedItem)
                {
                    balloonsMatrix[newRow, newColumn] = 0;
                    CheckUp(balloonsMatrix, newRow, newColumn, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        public static void CheckDown(byte[,] balloonsMatrix, int row, int column, int searchedItem)
        {
            int newRow = row - 1;
            int newColumn = column;
            try
            {
                if (balloonsMatrix[newRow, newColumn] == searchedItem)
                {
                    balloonsMatrix[newRow, newColumn] = 0;
                    CheckDown(balloonsMatrix, newRow, newColumn, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        public static bool Change(byte[,] matrixToModify, int row, int column)
        {
            if (matrixToModify[row, column] == 0)
            {
                return true;
            }

            byte searchedTarget = matrixToModify[row, column];

            matrixToModify[row, column] = 0;

            CheckLeft(matrixToModify, row, column, searchedTarget);
            CheckRight(matrixToModify, row, column, searchedTarget);

            CheckUp(matrixToModify, row, column, searchedTarget);
            CheckDown(matrixToModify, row, column, searchedTarget);

            return false;
        }

        public static bool CheckIfWinner(byte[,] field)
        {
            bool isWinner = true;

            Stack<byte> columnValues = new Stack<byte>();

            int rowsLenght = field.GetLength(0);
            int columnsLength = field.GetLength(1);

            for (int col = 0; col < columnsLength; col++)
            {
                for (int row = 0; row < rowsLenght; row++)
                {
                    if (field[row, col] != 0)
                    {
                        isWinner = false;
                        columnValues.Push(field[row, col]);
                    }
                }

                for (int row = rowsLenght - 1; row >= 0; row--)
                {
                    try
                    {
                        field[row, col] = columnValues.Pop();
                    }
                    catch (Exception)
                    {
                        field[row, col] = 0;
                    }
                }
            }

            return isWinner;
        }

        public static void SortAndPrintChartFive(string[,] tableToSort)
        {
            List<Highscore> klasirane = new List<Highscore>();

            for (int i = 0; i < 5; ++i)
            {
                if (tableToSort[i, 0] == null)
                {
                    break;
                }

                klasirane.Add(new Highscore(int.Parse(tableToSort[i, 0]), tableToSort[i, 1]));
            }

            klasirane.Sort();

            Console.WriteLine(TopFiveChartPrintingMessages.TopFiveChartTitle);

            for (int i = 0; i < klasirane.Count; ++i)
            {
                Highscore slot = klasirane[i];
                Console.WriteLine(TopFiveChartPrintingMessages.TopFivePlayerStringFormat, slot.Name, slot.Value, i + 1);
            }

            Console.WriteLine(TopFiveChartPrintingMessages.RowOfSymbols);
        }

        public static void Main()
        {
            string[,] topFive = new string[5, 2];
            byte[,] matrix = GenerateBalloons(5, 10);

            Console.Write("    ");

            for (byte column = 0; column < matrix.GetLongLength(1); column++)
            {
                Console.Write(column + " ");
            }

            Console.Write("\n   ");

            for (byte column = 0; column < (matrix.GetLongLength(1) * 2) + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (byte i = 0; i < matrix.GetLongLength(0); i++)
            {
                Console.Write(i + " | ");

                for (byte j = 0; j < matrix.GetLongLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        Console.Write("  ");
                        continue;
                    }

                    Console.Write(matrix[i, j] + " ");
                }

                Console.Write("| ");
                Console.WriteLine();
            }

            Console.Write("   ");

            for (byte column = 0; column < (matrix.GetLongLength(1) * 2) + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
            string temp = null;
            int userMoves = 0;

            while (temp != "EXIT")
            {
                Console.WriteLine(GlobalGameMessages.AskingToEnterRowAndColumnMessage);
                temp = Console.ReadLine();
                temp = temp.ToUpper().Trim();

                switch (temp)
                {
                    case "RESTART":
                        matrix = GenerateBalloons(5, 10);
                        Console.Write("    ");
                        for (byte column = 0; column < matrix.GetLongLength(1); column++)
                        {
                            Console.Write(column + " ");
                        }

                        Console.Write("\n   ");
                        for (byte column = 0; column < (matrix.GetLongLength(1) * 2) + 1; column++)
                        {
                            Console.Write("-");
                        }

                        Console.WriteLine();

                        for (byte i = 0; i < matrix.GetLongLength(0); i++)
                        {
                            Console.Write(i + " | ");
                            for (byte j = 0; j < matrix.GetLongLength(1); j++)
                            {
                                if (matrix[i, j] == 0)
                                {
                                    Console.Write("  ");
                                    continue;
                                }

                                Console.Write(matrix[i, j] + " ");
                            }

                            Console.Write("| ");
                            Console.WriteLine();
                        }

                        Console.Write("   ");
                        for (byte column = 0; column < (matrix.GetLongLength(1) * 2) + 1; column++)
                        {
                            Console.Write("-");
                        }

                        Console.WriteLine();
                        userMoves = 0;
                        break;

                    case "TOP":
                        SortAndPrintChartFive(topFive);
                        break;

                    default:
                        if ((temp.Length == 3) && (temp[0] >= '0' && temp[0] <= '9') && (temp[2] >= '0' && temp[2] <= '9') && (temp[1] == ' ' || temp[1] == '.' || temp[1] == ','))
                        {
                            int userRow, userColumn;
                            userRow = int.Parse(temp[0].ToString());

                            if (userRow > 4)
                            {
                                Console.WriteLine(GlobalGameMessages.WrongInputMessage);
                                continue;
                            }

                            userColumn = int.Parse(temp[2].ToString());

                            if (Change(matrix, userRow, userColumn))
                            {
                                Console.WriteLine(GlobalGameMessages.TryingToPopMissingBalloonMessage);
                                continue;
                            }

                            userMoves++;

                            if (CheckIfWinner(matrix))
                            {
                                Console.WriteLine(GlobalGameMessages.InTopFiveWinningMessage, userMoves);
                                if (topFive.SignIfSkilled(userMoves))
                                {
                                    SortAndPrintChartFive(topFive);
                                }
                                else
                                {
                                    Console.WriteLine(GlobalGameMessages.NotInTopFiveWinningMessage);
                                }

                                matrix = GenerateBalloons(5, 10);
                                userMoves = 0;
                            }

                            Console.Write("    ");
                            for (byte column = 0; column < matrix.GetLongLength(1); column++)
                            {
                                Console.Write(column + " ");
                            }

                            Console.Write("\n   ");
                            for (byte column = 0; column < (matrix.GetLongLength(1) * 2) + 1; column++)
                            {
                                Console.Write("-");
                            }

                            Console.WriteLine();

                            for (byte i = 0; i < matrix.GetLongLength(0); i++)
                            {
                                Console.Write(i + " | ");
                                for (byte j = 0; j < matrix.GetLongLength(1); j++)
                                {
                                    if (matrix[i, j] == 0)
                                    {
                                        Console.Write("  ");
                                        continue;
                                    }

                                    Console.Write(matrix[i, j] + " ");
                                }

                                Console.Write("| ");
                                Console.WriteLine();
                            }

                            Console.Write("   ");

                            for (byte column = 0; column < (matrix.GetLongLength(1) * 2) + 1; column++)
                            {
                                Console.Write("-");
                            }

                            Console.WriteLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine(GlobalGameMessages.WrongInputMessage);
                            break;
                        }
                }
            }

            Console.WriteLine("Good Bye! ");
        }
    }
}

