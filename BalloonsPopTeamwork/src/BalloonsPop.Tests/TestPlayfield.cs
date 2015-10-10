namespace BalloonsPop.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using BalloonsPop.Console.ConsoleUI;
    using BalloonsPop.Console.ConsoleIO;
    using BalloonsPop.Game;
    using BalloonsPop.Common.Exceptions;
    using BalloonsPop.Console.ConsoleUI.Playfield;

    [TestClass]
    public class PlayfieldTest
    {
        [TestMethod]
        public void SetProperHighScoreName()
        {
            var playField = new Playfield();

            Assert.AreEqual(playField.Height, Playfield.InitialHeight);
            Assert.AreEqual(playField.Width, Playfield.InitialWidth);
          
        }

        
    }
}
