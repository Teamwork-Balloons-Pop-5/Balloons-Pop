namespace BalloonsPop.Game
{
    public class Matrix
    {
        public static bool ChangeMatrix(byte[,] matrixToModify, int row, int column)
        {
            if (matrixToModify[row, column] == 0)
            {
                return true;
            }

            byte searchedTarget = matrixToModify[row, column];

            matrixToModify[row, column] = 0;

            CheckCellInMatrix.CheckLeft(matrixToModify, row, column, searchedTarget);
            CheckCellInMatrix.CheckRight(matrixToModify, row, column, searchedTarget);

            CheckCellInMatrix.CheckUp(matrixToModify, row, column, searchedTarget);
            CheckCellInMatrix.CheckDown(matrixToModify, row, column, searchedTarget);

            return false;
        }
    }
}
