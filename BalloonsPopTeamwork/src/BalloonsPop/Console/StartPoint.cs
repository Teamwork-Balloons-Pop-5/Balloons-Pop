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

            // string[,] topFive = new string[5, 2];
            // byte[,] matrix = Generator.GenerateBalloons(5, 10);
            // 
            // ConsoleUI.ConsoleUI.PrintingMatrixOnConsole(matrix);
            // 
            // string temp = null;
            // int userMoves = 0;
            Engine.Instance.Start();

            Console.WriteLine(GlobalGameMessages.ExitGameMessage);
        }
    }
}