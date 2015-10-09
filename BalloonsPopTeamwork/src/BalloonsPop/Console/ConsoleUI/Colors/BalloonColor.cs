namespace BalloonsPop.Console.ConsoleUI.Colors
{
    using System;

    public class BalloonColor
    {
        public static void PaintBalloonField(string currentBalloon)
        {
            switch (currentBalloon)
            {
                case "1":
                    SetColor(ConsoleColor.Green, currentBalloon, ConsoleColor.White);
                    break;
                case "2":
                    SetColor(ConsoleColor.Blue, currentBalloon, ConsoleColor.White);
                    break;
                case "3":
                    SetColor(ConsoleColor.Red, currentBalloon, ConsoleColor.White);
                    break;
                case "4":
                    SetColor(ConsoleColor.Yellow, currentBalloon, ConsoleColor.White);
                    break;
            }
        }

        private static void SetColor(ConsoleColor balloonColor, string balloonDigit, ConsoleColor textColor)
        {
            Console.ForegroundColor = balloonColor;
            Console.Write(balloonDigit + " ");
            Console.ForegroundColor = textColor;
        }
    }
}
