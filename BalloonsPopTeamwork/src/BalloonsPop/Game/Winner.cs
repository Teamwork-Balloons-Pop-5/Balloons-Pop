namespace BalloonsPop.Game
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Console.ConsoleUI.Playfield;

    public class Winner
    {
        public static bool CheckIfWinner(Playfield matrix)
        {
            bool isWinner = true;

            Stack<string> columnValues = new Stack<string>();

            int rowsLenght = matrix.Height;
            int columnsLength = matrix.Width;

            for (int col = 0; col < columnsLength; col++)
            {
                for (int row = 0; row < rowsLenght; row++)
                {
                    if (matrix.Field[row, col] != "0")
                    {
                        isWinner = false;
                        columnValues.Push(matrix.Field[row, col]);
                    }
                }

                for (int row = rowsLenght - 1; row >= 0; row--)
                {
                    try
                    {
                        matrix.Field[row, col] = columnValues.Pop();
                    }
                    catch (Exception)
                    {
                        matrix.Field[row, col] = "0";
                    }
                }
            }

            return isWinner;
        }
    }
}
