// <copyright  file="Chart.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Game
{
    using System;
    using System.Collections.Generic;
    using BalloonsPop.Console.ConsoleIO;
    using BalloonsPop.Console.ConsoleIO.Reader;

    /// <summary>
    /// creates instance of the chart for scoreboard
    /// </summary>
    public class Chart
    {
        /// <summary>
        /// takes the current user points, sorts them with the top 5 user points form before and writes only the best 5 back in the file
        /// </summary>
        /// <param name="spentMoves">takes int value of how many moves the user has made before wining</param>
        public static void SortAndPrintChartFive(int spentMoves)
        {
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

        /// <summary>
        /// takes old highscores from file
        /// </summary>
        private static IEnumerable<string> GetHighScoresFromFile()
        {
            string[] scores = System.IO.File.ReadAllLines("../../Game/HighScore.txt");
            return scores;
        }

        /// <summary>
        /// parses the score-username string
        /// </summary>
        /// <param name="scoreText">string representing one line form the scoreboard file</param>
        private static Highscore ScoreParser(string scoreText)
        {
            string[] temp = scoreText.Split('\t');
            return new Highscore(temp[0], int.Parse(temp[1]));
        }

        /// <summary>
        /// saves scores to file
        /// </summary>
        /// <param name="tempScore">the latets sorted highscore list</param>
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
