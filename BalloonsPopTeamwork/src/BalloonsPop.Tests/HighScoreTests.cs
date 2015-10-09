namespace BalloonsPop.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using BalloonsPop.Console.ConsoleUI;
    using BalloonsPop.Console.ConsoleIO;
    using BalloonsPop.Game;
    using BalloonsPop.Common.Exceptions;

    [TestClass]
    public class HighScoreTests
    {
        [TestMethod]
        public void SetProperHighScoreName()
        {
            var highScore = new Highscore();
            var name = "Veli";

            highScore.Name = name;

            Assert.AreEqual(highScore.Name, name);
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidLenghtStringException))]
        public void SetWrongHighScoreName()
        {
            var highScore = new Highscore();
            var name = "1";

            highScore.Name = name;
        }

        [TestMethod]
        public void SetProperHighScorePoints()
        {
            var highScore = new Highscore();
            var value = 10;

            highScore.Value = value;

            Assert.AreEqual(highScore.Value, value);
        }

        [TestMethod]
        [ExpectedException(typeof(NotPositiveIntegerException))]
        public void SetWrongHighScorePoints()
        {
            var highScore = new Highscore();
            var value = -1;

            highScore.Value = value;
        }

        [TestMethod]
        public void HighScoreToStringTest()
        {
            var highScore = new Highscore("Veli", 10);
            var outputValue = "Veli-10";

            Assert.AreEqual(highScore.ToString(), outputValue);
        }
    }
}
