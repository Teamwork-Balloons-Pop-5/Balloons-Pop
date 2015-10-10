namespace BalloonsPop.Game
{
    using BalloonsPop.Console.ConsoleUI.Playfield;

    public class Matrix
    {
        public static bool ChangeMatrix(Playfield matrixToModify, int row, int column)
        {
            if (matrixToModify.Field[row, column] == "0")
            {
                return true;
            }

            string searchedTarget = matrixToModify.Field[row, column];

            matrixToModify.Field[row, column] = "0";

            CheckCellInMatrix.CheckLeft(matrixToModify, row, column, searchedTarget);
            CheckCellInMatrix.CheckRight(matrixToModify, row, column, searchedTarget);

            CheckCellInMatrix.CheckUp(matrixToModify, row, column, searchedTarget);
            CheckCellInMatrix.CheckDown(matrixToModify, row, column, searchedTarget);

            return false;
        }
    }
}
