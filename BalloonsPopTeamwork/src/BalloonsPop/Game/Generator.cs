namespace BalloonsPop.Game
{
    using BalloonsPop.Console.ConsoleUI.Playfield;
    using System;

    public class Generator
    {
        public static Playfield GenerateBalloons(byte rows, byte columns)
        {
            Playfield balloonsMatrix = new Playfield(rows, columns);
            Random randomNumber = new Random();

            for (byte row = 0; row < rows; row++)
            {
                for (byte column = 0; column < columns; column++)
                {
                    byte numberToInsert = (byte)randomNumber.Next(1, 5);
                    balloonsMatrix.Field[row, column] = numberToInsert.ToString();
                }
            }

            return balloonsMatrix;
        }
    }
}
