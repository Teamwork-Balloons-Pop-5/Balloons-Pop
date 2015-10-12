// <copyright  file="CheckCellInMatrix.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Game
{
    using System;
    using BalloonsPop.Console.ConsoleUI.Playfield;

    /// <summary>
    /// creates instance of the logical checker wether a cell is within the genaretd playfield matrix
    /// </summary>
    public class CheckCell
    {
        /// <summary>
        /// checks the cells to the left
        /// </summary>
        /// <param name="balloonsMatrix">the playfield for teh game</param>
        /// <param name="row">takes the playfield size</param>
        /// <param name="column">takes the playfield size</param>
        /// <param name="searchedItem">string with the cell that we check for</param>
        public void CheckLeft(Playfield balloonsMatrix, int row, int column, string searchedItem)
        {
            int newRow = row;
            int newColumn = column - 1;
            try
            {
                if (balloonsMatrix.Field[newRow, newColumn] == searchedItem)
                {
                    balloonsMatrix.Field[newRow, newColumn] = "0";
                    this.CheckLeft(balloonsMatrix, newRow, newColumn, searchedItem);
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

        /// <summary>
        /// checks the cells to the right
        /// </summary>
        /// <param name="balloonsMatrix">the playfield for teh game</param>
        /// <param name="row">takes the playfield size</param>
        /// <param name="column">takes the playfield size</param>
        /// <param name="searchedItem">string with the cell that we check for</param>
        public void CheckRight(Playfield balloonsMatrix, int row, int column, string searchedItem)
        {
            int newRow = row;
            int newColumn = column + 1;
            try
            {
                if (balloonsMatrix.Field[newRow, newColumn] == searchedItem)
                {
                    balloonsMatrix.Field[newRow, newColumn] = "0";
                    this.CheckRight(balloonsMatrix, newRow, newColumn, searchedItem);
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

        /// <summary>
        /// checks the cells up
        /// </summary>
        /// <param name="balloonsMatrix">the playfield for teh game</param>
        /// <param name="row">takes the playfield size</param>
        /// <param name="column">takes the playfield size</param>
        /// <param name="searchedItem">string with the cell that we check for</param>
        public void CheckUp(Playfield balloonsMatrix, int row, int column, string searchedItem)
        {
            int newRow = row + 1;
            int newColumn = column;
            try
            {
                if (balloonsMatrix.Field[newRow, newColumn] == searchedItem)
                {
                    balloonsMatrix.Field[newRow, newColumn] = "0";
                    this.CheckUp(balloonsMatrix, newRow, newColumn, searchedItem);
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

        /// <summary>
        /// checks the cells down
        /// </summary>
        /// <param name="balloonsMatrix">the playfield for teh game</param>
        /// <param name="row">takes the playfield size</param>
        /// <param name="column">takes the playfield size</param>
        /// <param name="searchedItem">string with the cell that we check for</param>
        public void CheckDown(Playfield balloonsMatrix, int row, int column, string searchedItem)
        {
            int newRow = row - 1;
            int newColumn = column;
            try
            {
                if (balloonsMatrix.Field[newRow, newColumn] == searchedItem)
                {
                    balloonsMatrix.Field[newRow, newColumn] = "0";
                    this.CheckDown(balloonsMatrix, newRow, newColumn, searchedItem);
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
