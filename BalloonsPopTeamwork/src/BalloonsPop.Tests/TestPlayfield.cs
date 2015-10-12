namespace BalloonsPop.Tests
{
    using BalloonsPop.Console.ConsoleUI.Playfield;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
