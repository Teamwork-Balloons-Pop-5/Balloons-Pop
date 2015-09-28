namespace BalloonsPop.Game
{
    using System;
    using System.Collections.Generic;

    using Common.Constants;

    public class Chart
    {
        public static void SortAndPrintChartFive(string[,] tableToSort)
        {
            List<Highscore> klasirane = new List<Highscore>();

            for (int i = 0; i < 5; ++i)
            {
                if (tableToSort[i, 0] == null)
                {
                    break;
                }

                klasirane.Add(new Highscore(int.Parse(tableToSort[i, 0]), tableToSort[i, 1]));
            }

            klasirane.Sort();

            Console.WriteLine(TopFiveChartPrintingMessages.TopFiveChartTitle);

            for (int i = 0; i < klasirane.Count; ++i)
            {
                Highscore slot = klasirane[i];
                Console.WriteLine(TopFiveChartPrintingMessages.TopFivePlayerStringFormat, slot.Name, slot.Value, i + 1);
            }

            Console.WriteLine(TopFiveChartPrintingMessages.RowOfSymbols);
        }
    }
}
