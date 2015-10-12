// <copyright  file="RecursivePopStrategy.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Game.Logic
{
    using BalloonsPop.Console.ConsoleUI.Playfield;

    /// <summary>
    /// instance for PopStrategy
    /// </summary>
    public class RecursivePopStrategy : IPopStrategy
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
                    // Pop current cell
                    playfield.Field[row, col] = "0";
                    poppedBaloons += 1;

                    // Up
                    poppedBaloons += this.PopBaloons(row - 1, col, playfield, selectedCellValue);

                    // Down
                    poppedBaloons += this.PopBaloons(row + 1, col, playfield, selectedCellValue);

                    // Left
                    poppedBaloons += this.PopBaloons(row, col + 1, playfield, selectedCellValue);

                    // Right
                    poppedBaloons += this.PopBaloons(row, col - 1, playfield, selectedCellValue);
                }
            }

            return poppedBaloons;
        }
    }
}
