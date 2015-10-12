// <copyright  file="PlayfieldPrinter.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Console.ConsoleIO.Printer
{
    using System;
    using BalloonsPop.Console.ConsoleUI.Colors;
    using BalloonsPop.Console.ConsoleUI.Playfield;

    /// <summary>
    /// creates printer for the playfield of the game
    /// </summary>
    public class PlayfieldPrinter : Printer
    {
        /// <summary>
        /// Prints text on the same line
        /// </summary>
        /// <param name="text">takes a string and prints it on the same line</param>
        public override void PrintText(string text)
        {
            Console.Write(text);
        }

        /// <summary>
        /// Prints a line
        /// </summary>
        /// <param name="text">takes a string and prints it on a separate line</param>
        public override void PrintTextLine(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Prints an object array
        /// </summary>
        /// <param name="arguments">takes object array and prints it</param>
        public override void Print(params object[] arguments)
        {
            // TODO: Need to refactor the code inside
            var playfield = arguments[0] as Playfield;
            var colors = arguments[1] as BalloonColor;

            Console.ForegroundColor = ConsoleColor.White;
            this.PrintText("      ");

            for (byte column = 0; column < playfield.Width; column++)
            {
                this.PrintText(column + " ");
            }

            this.PrintText("\n     ");

            this.PrintPlayfieldHorizontalBorder(playfield.Width, "-");

            this.PrintText(Environment.NewLine);

            for (byte row = 0; row < playfield.Height; row++)
            {
                this.PrintText(row.ToString().PadLeft(3) + " | ");

                for (byte column = 0; column < playfield.Width; column++)
                {
                    if (playfield.Field[row, column] == "0")
                    {
                        this.PrintText("  ");
                        continue;
                    }

                    colors.PaintBalloon(playfield.Field[row, column]);
                }

                this.PrintText("| ");
                this.PrintText(Environment.NewLine);
            }

            this.PrintText("     ");

            this.PrintPlayfieldHorizontalBorder(playfield.Width, "-");

            Console.WriteLine();
        }

        /// <summary>
        /// Prints the border for the playfield
        /// </summary>
        /// <param name="width">int value that gives us the width of the playfield</param>
        /// <param name="borderType">string that gives us what border will be printed</param>
        private void PrintPlayfieldHorizontalBorder(int width, string borderType)
        {
            for (byte column = 0; column < (width * 2) + 1; column++)
            {
                this.PrintText(borderType);
            }
        }
    }
}
