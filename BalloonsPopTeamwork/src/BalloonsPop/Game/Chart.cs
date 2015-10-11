namespace BalloonsPop.Game
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Console.ConsoleIO;
    using BalloonsPop.Console.ConsoleIO.Reader;

    public class Chart
    {
        public static void SortAndPrintChartFive(int spentMoves)
        {
            // To do: get current score
            var consoleInut = new Reader().ReadUserInput();
            var userName = new Reader().ReadUsername();
            var currentScore = new Highscore(userName, spentMoves); // get current score
            var scores = GetHighScoresFromFile(); // read from file
            var results = new List<Highscore>();
            foreach (var item in scores)
            {
                results.Add(ScoreParser(item));
            } // add old highscores
            results.Add(currentScore); // add current score to highscores
            results.Sort((x1, x2) => x1.Value.CompareTo(x2.Value)); // sort score

            if (results.Count == Common.Constants.GlobalGameLogicDependencesValues.TopChartLength + 1)
            {
                results.RemoveAt(Common.Constants.GlobalGameLogicDependencesValues.TopChartLength);
            } // remove the last score from the sorted highscore list
            SaveToFile(results); // save to file
        }

        private static IEnumerable<string> GetHighScoresFromFile()
        {
            string[] scores = System.IO.File.ReadAllLines("../../Game/HighScore.txt");
            return scores;
        }

        private static Highscore ScoreParser(string scoreText)
        {
            string[] temp = scoreText.Split('\t');
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

            System.IO.File.WriteAllLines("../../Game/HighScore.txt", output.ToArray());
        }
    }
}
