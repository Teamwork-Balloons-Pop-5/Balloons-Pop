namespace BalloonsPop.Console.ConsoleUI.Colors
{
    using System;

    public class BalloonColor
    {
        public static void SetColor(int currentBalloon)
        {
            switch (currentBalloon)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(currentBalloon + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(currentBalloon + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(currentBalloon + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(currentBalloon + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}
