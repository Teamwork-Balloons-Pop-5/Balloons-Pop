namespace BalloonsPop.Console
{
    using System;

    using BalloonsPop.Common.Constants;
    using BalloonsPop.Console.ConsoleUI.Menu;
    using BalloonsPop.Engine;

    public class StartPoint
    {        
        public static void Main()
        {
            var menu = new Menu();
            menu.Load();
            Engine.Instance.Start();

            Console.WriteLine(GlobalGameMessages.ExitGameMessage);
        }
    }
}