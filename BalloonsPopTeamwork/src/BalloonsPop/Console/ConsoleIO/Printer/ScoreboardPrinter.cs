namespace BalloonsPop.Console.ConsoleIO.Printer
{
    using System;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ScoreboardPrinter : Printer
    {
        // Finished
        public override void PrintText(string text)
        {
            Console.Write(text);
        }

        // Finished
        public override void PrintTextLine(string text)
        {
            Console.WriteLine(text);
        }

        // Need to refactor the code inside
        public override void Print(params object[] arguments)
        {
            var statistics = arguments[0] as OrderedMultiDictionary<int, string>;

            int resultsCount = Math.Min(5, statistics.Count);
            int counter = 0;

            StringBuilder scoreboard = new StringBuilder();

            scoreboard.AppendLine("Scoreboard:");

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
