namespace BalloonsPop.Console.ConsoleUI
{
    using System;

    using BalloonsPop.Console.ConsoleUI.Colors;

    public class ConsoleUI
    {
        public static void PrintingMatrixOnConsole(byte[,] matrix)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("    ");

            for (byte column = 0; column < matrix.GetLongLength(1); column++)
            {
                Console.Write(column + " ");
            }

            Console.Write("\n   ");

            for (byte column = 0; column < (matrix.GetLongLength(1) * 2) + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (byte i = 0; i < matrix.GetLongLength(0); i++)
            {
                Console.Write(i + " | ");

                for (byte j = 0; j < matrix.GetLongLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        Console.Write("  ");
                        continue;
                    }

                    // Set balloon color
                   BalloonColor.PaintBalloonField(matrix[i, j]);
                }

                Console.Write("| ");
                Console.WriteLine();
            }

            Console.Write("   ");

            for (byte column = 0; column < (matrix.GetLongLength(1) * 2) + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }
    }
}
