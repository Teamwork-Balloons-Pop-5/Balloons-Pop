// <copyright  file="Matrix.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Game
{
    using BalloonsPop.Console.ConsoleUI.Playfield;

    /// <summary>
    /// creates instance of the playfield that gets modified
    /// </summary>
    public class Matrix
    {
        private CheckCell currentCell = new CheckCell();

        /// <summary>
        /// checks wether the matrix needs to be modified
        /// </summary>
        /// <param name="matrixToModify">object form type playfield that represents the matrix that hold sthe balloons</param>
        /// <param name="row">matrix size</param>
        /// <param name="column">matrix size</param>
        /// <returns>bool value</returns>
        public bool ChangeMatrix(Playfield matrixToModify, int row, int column)
        {
            if (matrixToModify.Field[row, column] == "0")
            {
                return true;
            }

            string searchedTarget = matrixToModify.Field[row, column];

            matrixToModify.Field[row, column] = "0";

            this.currentCell.CheckLeft(matrixToModify, row, column, searchedTarget);
            this.currentCell.CheckRight(matrixToModify, row, column, searchedTarget);

            this.currentCell.CheckUp(matrixToModify, row, column, searchedTarget);
            this.currentCell.CheckDown(matrixToModify, row, column, searchedTarget);

            return false;
        }
    }
}
