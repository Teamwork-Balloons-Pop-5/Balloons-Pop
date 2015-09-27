namespace BalloonsPop.Console
{
    using System;
    using System.Collections.Generic;
    
    using Common.Constants;
    using GameLogic;
    using Engine;
    using BalloonsPop.Console.ConsoleUI;
    using BalloonsPop.Console.ConsoleUI.Menu;

    public class StartPoint
    {        
        public static void Main()
        {
            Menu.InitializeMenu();

            string[,] topFive = new string[5, 2];
            byte[,] matrix = Generator.GenerateBalloons(5, 10);

            ConsoleUI.ConsoleUI.PrintingMatrixOnConsole(matrix);

            string temp = null;
            int userMoves = 0;

            Engine.Instance.Run(temp, matrix, userMoves, topFive);

            Console.WriteLine(GlobalGameMessages.ExitGameMessage);
        }
    }
}

