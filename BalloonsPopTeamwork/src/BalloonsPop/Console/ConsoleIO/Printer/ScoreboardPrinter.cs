// <copyright  file="ScoreboardPrinter.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Console.ConsoleIO.Printer
{
    using System;
    using System.Text;
    using Wintellect.PowerCollections;

    /// <summary>
    /// creates printer for the ScoreBoard of the game
    /// </summary>
    public class ScoreboardPrinter : Printer
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
        /// Prints text line
        /// </summary>
        /// <param name="text">takes a string and prints it on a separate line</param>
        public override void PrintTextLine(string text)
        {
            Console.WriteLine(text);
        }
      
        /// <summary>
        /// Prints scoreboard
        /// </summary>
        /// <param name="arguments">takes object array and prints it</param>
        public override void Print(params object[] arguments)
        {
            // TODO: Need to refactor the code inside
            var statistics = arguments[0] as OrderedMultiDictionary<int, string>;

            int resultsCount = Math.Min(5, statistics.Count);
            int counter = 0;

            StringBuilder scoreboard = new StringBuilder();

            scoreboard.AppendLine("Scoreboard:");

            if (statistics.Count == 0)
            {
                scoreboard.AppendLine("No players to show.");
            }

            foreach (var player in statistics)
            {
                if (counter == resultsCount)
                {
                    break;
                }
                else
                {
                    counter++;
                    var format = string.Format("{0}. {1} --> {2} moves", resultsCount, player.Value, player.Key);
                    scoreboard.AppendLine(format);
                }
            }

            string result = scoreboard.ToString();
            this.PrintTextLine(result);
        }
    }
}
