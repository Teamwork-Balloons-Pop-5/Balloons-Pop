﻿namespace BalloonsPop.Console.ConsoleIO
{
    using System;

    using BalloonsPop.Common.Constants;
    using BalloonsPop.Console.ConsoleUI.Playfield;
    using Wintellect.PowerCollections;
    using System.Text;
    using BalloonsPop.Console.ConsoleUI.Colors;

    public class ConsoleOutput
    {
        private MessagePrinter printer = new MessagePrinter();

        public void PrintWelcomeMessage()
        {
            printer.PrintLine(GlobalGameMessages.WelcomeMessage);
        }

        public void PrintInvalidInputMessage()
        {
            printer.PrintLine(GlobalGameMessages.WrongInputMessage);
        }

        public void PrintExitMessage(int userMoves, int balloonsLeft)
        {
            printer.PrintLine(GlobalGameMessages.ExitGameMessage);
            printer.PrintLine(userMoves.ToString());
            printer.PrintLine(balloonsLeft.ToString());
        }

        public void PrintInvalidMoveMessage()
        {
            printer.PrintLine(GlobalGameMessages.TryingToPopMissingBalloonMessage);
        }

        public void PrintWinMessage(int userMoves)
        {
            string message = string.Format(GlobalGameMessages.InTopFiveWinningMessage, userMoves);
            printer.PrintLine(message);
        }

        public void PrintTable(Playfield playfield)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("      ");

            for (byte column = 0; column < playfield.Width; column++)
            {
                Console.Write(column + " ");
            }

            Console.Write("\n     ");

            for (byte column = 0; column < (playfield.Width * 2) + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (byte i = 0; i < playfield.Height; i++)
            {
                Console.Write(i.ToString().PadLeft(3) + " | ");

                for (byte j = 0; j < playfield.Width; j++)
                {
                    if (playfield.Field[i, j] == "0")
                    {
                        Console.Write("  ");
                        continue;
                    }

                    if (playfield.Field[i, j] == ".")
                    {
                        Console.WriteLine(playfield.Field[i, j]);
                    }

                    // Set balloon color
                    BalloonColor.PaintBalloonField(playfield.Field[i, j]);
                }

                Console.Write("| ");
                Console.WriteLine();
            }

            Console.Write("     ");

            for (byte column = 0; column < (playfield.Width * 2) + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }

        public string CreateScoreboardString(OrderedMultiDictionary<int, string> statistics)
        {
            int resultsCount = Math.Min(5, statistics.Count);
            int counter = 0;

            StringBuilder scoreboard = new StringBuilder();

            scoreboard.AppendLine("Scoreboard:");

            foreach (var result in statistics)
            {
                if (counter == resultsCount)
                {
                    break;
                }
                else
                {
                    counter++;
                    var format = String.Format("{0}. {1} --> {2} moves", resultsCount, result.Value, result.Key);
                    scoreboard.AppendLine(format);
                }
            }

            return scoreboard.ToString();
        }
    }
}
