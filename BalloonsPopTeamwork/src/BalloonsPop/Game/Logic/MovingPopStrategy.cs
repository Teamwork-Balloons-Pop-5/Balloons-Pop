namespace BalloonsPop.Game.Logic
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Console.ConsoleUI.Playfield;

    public class MovingPopStrategy : IPopStrategy
    {
        public int PopBaloons(int row, int col, Playfield playfield)
        {
            bool isRowValid = row >= 0 && row < playfield.Height;
            bool isColValid = col >= 0 && col < playfield.Width;

            if (isRowValid && isColValid)
            {
                string selectedCellValue = playfield.Field[row, col];

                if (selectedCellValue == "0")
                {
                    return 0;
                }
                else
                {
                    return this.PopBaloons(row, col, playfield, selectedCellValue);
                }
            }

            return 0;
        }

        private int PopBaloons(int row, int col, Playfield playfield, string selectedCellValue = null)
        {
            int poppedBaloons = 0;
            bool isRowValid = row >= 0 && row < playfield.Height;
            bool isColValid = col >= 0 && col < playfield.Width;

            if (isRowValid && isColValid)
            {
                if (playfield.Field[row, col] == selectedCellValue)
                {
                    Matrix.ChangeMatrix(playfield, row, col);
                    poppedBaloons++;

                    poppedBaloons += this.PopBaloons(row - 1, col, playfield, selectedCellValue);
                    poppedBaloons += this.PopBaloons(row + 1, col, playfield, selectedCellValue);
                    poppedBaloons += this.PopBaloons(row, col + 1, playfield, selectedCellValue);
                    poppedBaloons += this.PopBaloons(row, col - 1, playfield, selectedCellValue);
                    this.FallBalloons(playfield);
                }
            }

            return poppedBaloons;
        }

        // This is a complex algorithm
        private void FallBalloons(Playfield matrix)
        {
            Stack<string> columnValues = new Stack<string>();

            int rowsLenght = matrix.Height;
            int columnsLength = matrix.Width;

            for (int col = 0; col < columnsLength; col++)
            {
                for (int row = 0; row < rowsLenght; row++)
                {
                    if (matrix.Field[row, col] != "0")
                    {
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
        }
    }
}