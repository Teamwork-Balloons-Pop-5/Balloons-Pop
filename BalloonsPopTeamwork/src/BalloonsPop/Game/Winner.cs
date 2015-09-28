namespace BalloonsPop.Game
{
    using System;
    using System.Collections.Generic;

    public class Winner
    {
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
    }
}
