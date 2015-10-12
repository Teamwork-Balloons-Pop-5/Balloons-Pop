namespace BalloonsPop.Console
{
    using System;

    using BalloonsPop.Common.Constants;
    using BalloonsPop.Engine;

    public class StartPoint
    {        
        public static void Main()
        {
            Game game = new Game();
            game.Start();
        }
    }
}