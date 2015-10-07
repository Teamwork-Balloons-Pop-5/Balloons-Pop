namespace BalloonsPop.Game
{
    using System;
    using System.Collections.Generic;
    using Common.Constants;

    public class Chart
    {
        public static void SortAndPrintChartFive(string[,] tableToSort)
        {
            /*
            List<Highscore> highScoreChart = new List<Highscore>();

            for (int i = 0; i < Common.Constants.GlobalGameLogicDependencesValues.TOPCHARTLENGHT; ++i)
            {
                if (tableToSort[i, 0] == null)
                {
                    break;
                }

                highScoreChart.Add(new Highscore(int.Parse(tableToSort[i, 0]), tableToSort[i, 1]));
            }

            highScoreChart.Sort();

            Console.WriteLine(TopChartPrintingMessages.TopChartTitle);

            for (int i = 0; i < highScoreChart.Count; ++i)
            {
                Highscore slot = highScoreChart[i];
                Console.WriteLine(TopChartPrintingMessages.TopPlayerStringFormat, slot.Name, slot.Value, i + 1);
            }

            Console.WriteLine(TopChartPrintingMessages.RowOfSymbols);
             * */
            //To do: get current score
            var currentScore = new Highscore("hardcoded score", 1); // get current score
            var scores = GetHighScoresFromFile(); //read from file
            var results = new List<Highscore>();
            foreach (var item in scores)
            {
                results.Add(ScoreParser(item));
            } // add old highscores
            results.Add(currentScore); //add current score to highscores
            results.Sort((x1, x2) => x1.Value.CompareTo(x2.Value)); //sort score

            if (results.Count == Common.Constants.GlobalGameLogicDependencesValues.TOPCHARTLENGHT + 1)
            {
                results.RemoveAt(Common.Constants.GlobalGameLogicDependencesValues.TOPCHARTLENGHT);
            } //remove the last score from the sorted highscore list
            SaveToFile(results); //save to file
        }

        private static IEnumerable<string> GetHighScoresFromFile()
        {
            string[] scores = System.IO.File.ReadAllLines("HighScore.txt");
            return scores;
        }

        private static Highscore ScoreParser(string scoreText)
        {
            string[] temp = scoreText.Split('-');
            return new Highscore(temp[0], int.Parse(temp[1]));
        }

        private static void SaveToFile(List<Highscore> tempScore)
        {
            List<string> output = new List<string>();

            foreach (var item in tempScore)
            {
                output.Add(item.ToString());
                Console.WriteLine(item.ToString());
            }

            System.IO.File.WriteAllLines("HighScore.txt", output.ToArray());
        }
    }
}
