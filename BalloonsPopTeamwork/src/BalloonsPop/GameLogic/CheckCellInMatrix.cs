namespace BalloonsPop.GameLogic
{
    using System;

    public class CheckCellInMatrix
    {
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

    }
}
