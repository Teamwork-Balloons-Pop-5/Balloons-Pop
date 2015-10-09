namespace BalloonsPop.Game
{
    using BalloonsPop.Console.ConsoleUI.Playfield;
    using System;

    public class CheckCellInMatrix
    {
        public static void CheckLeft(Playfield balloonsMatrix, int row, int column, string searchedItem)
        {
            int newRow = row;
            int newColumn = column - 1;
            try
            {
                if (balloonsMatrix.Field[newRow, newColumn] == searchedItem)
                {
                    balloonsMatrix.Field[newRow, newColumn] = "0";
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

        public static void CheckRight(Playfield balloonsMatrix, int row, int column, string searchedItem)
        {
            int newRow = row;
            int newColumn = column + 1;
            try
            {
                if (balloonsMatrix.Field[newRow, newColumn] == searchedItem)
                {
                    balloonsMatrix.Field[newRow, newColumn] = "0";
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

        public static void CheckUp(Playfield balloonsMatrix, int row, int column, string searchedItem)
        {
            int newRow = row + 1;
            int newColumn = column;
            try
            {
                if (balloonsMatrix.Field[newRow, newColumn] == searchedItem)
                {
                    balloonsMatrix.Field[newRow, newColumn] = "0";
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

        public static void CheckDown(Playfield balloonsMatrix, int row, int column, string searchedItem)
        {
            int newRow = row - 1;
            int newColumn = column;
            try
            {
                if (balloonsMatrix.Field[newRow, newColumn] == searchedItem)
                {
                    balloonsMatrix.Field[newRow, newColumn] = "0";
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

    }
}
