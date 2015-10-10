namespace BalloonsPop.Console.ConsoleUI
{
    using System;

    using BalloonsPop.Console.ConsoleUI.Colors;

    public class ConsoleUI
    {
        public static void PrintingMatrixOnConsole(Playfield.Playfield matrix)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("    ");

            for (byte column = 0; column < matrix.Width; column++)
            {
                Console.Write(column + " ");
            }

            Console.Write("\n   ");

            for (byte column = 0; column < (matrix.Width * 2) + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (byte i = 0; i < matrix.Height; i++)
            {
                Console.Write(i + " | ");

                for (byte j = 0; j < matrix.Width; j++)
                {
                    if (matrix.Field[i, j] == "0")
                    {
                        Console.Write("  ");
                        continue;
                    }

                    // Set balloon color
                   BalloonColor.PaintBalloonField(matrix.Field[i, j]);
                }

                Console.Write("| ");
                Console.WriteLine();
            }

            Console.Write("   ");

            for (byte column = 0; column < (matrix.Width * 2) + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }
    }
}
