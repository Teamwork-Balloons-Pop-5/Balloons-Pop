﻿// <copyright  file="MovingPopStrategy.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Game.Logic
{
    using System;
    using System.Collections.Generic;
    using BalloonsPop.Console.ConsoleUI.Playfield;

    /// <summary>
    /// instance for PopStrategy
    /// </summary>
    public class MovingPopStrategy : IPopStrategy
    {
        /// <summary>
        /// count of balloons
        /// </summary>
        /// <param name="row">int for cell position</param>
        /// <param name="col">int for cell position</param>
        /// <param name="playfield">object that contains the playfield matrics form type Playfield</param>
        /// <returns></returns>
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

        /// <summary>
        /// counts how many balloons have been popped in the current move
        /// </summary>
        /// <param name="row">int for cell position</param>
        /// <param name="col">int for cell position</param>
        /// <param name="playfield">object that contains the playfield matrics form type Playfield</param>
        /// <param name="selectedCellValue">string for the user input for which balloon to be popped</param>
        /// <returns>int of count of popped ballons within the current move</returns>
        private int PopBaloons(int row, int col, Playfield playfield, string selectedCellValue = null)
        {
            int poppedBaloons = 0;
            bool isRowValid = row >= 0 && row < playfield.Height;
            bool isColValid = col >= 0 && col < playfield.Width;

            if (isRowValid && isColValid)
            {
                if (playfield.Field[row, col] == selectedCellValue)
                {
                    this.playfieldMatrix.ChangeMatrix(playfield, row, col);
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

        /// <summary>
        /// refreshes the playfield after balloons are popped
        /// </summary>
        /// <param name="matrix">the playfield of type Playfield</param>
        private void FallBalloons(Playfield matrix)
        {
            // This is a complex algorithm
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