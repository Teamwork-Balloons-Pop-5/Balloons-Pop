namespace BalloonsPop.GameLogic
{
    using System;

    public class Generator
    {
        public static byte[,] GenerateBalloons(byte rows, byte columns)
        {
            byte[,] balloonsMatrix = new byte[rows, columns];
            Random randomNumber = new Random();

            for (byte row = 0; row < rows; row++)
            {
                for (byte column = 0; column < columns; column++)
                {
                    byte numberToInsert = (byte)randomNumber.Next(1, 5);
                    balloonsMatrix[row, column] = numberToInsert;
                }
            }

            return balloonsMatrix;
        }
    }
}
