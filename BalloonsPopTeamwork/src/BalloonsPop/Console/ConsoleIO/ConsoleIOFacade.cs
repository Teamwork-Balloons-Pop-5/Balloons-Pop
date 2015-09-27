namespace BalloonsPop.Console.ConsoleIO
{
    using System;
    using System.Text;

    using BalloonsPop.Common.Constants;

    public static class ConsoleIOFacade
    {
        public static void PrintWelcomeMessage()
        {
            MessagePrinter.PrintLine(GlobalGameMessages.WelcomeMessage);
        }

        public static void PrintInvalidInputMessage()
        {
            MessagePrinter.PrintLine(GlobalGameMessages.WrongInputMessage);
        }

        public static void PrintExitMessage(int userMoves, int balloonsLeft)
        {
            MessagePrinter.PrintLine(GlobalGameMessages.ExitGameMessage);
            MessagePrinter.PrintLine(userMoves.ToString());
            MessagePrinter.PrintLine(balloonsLeft.ToString());
        }

        public static void PrintInvalidMoveMessage()
        {
            MessagePrinter.PrintLine(GlobalGameMessages.TryingToPopMissingBalloonMessage);
        }

        public static void PrintWinMessage(int userMoves)
        {
            string message = string.Format(GlobalGameMessages.InTopFiveWinningMessage, userMoves);
            MessagePrinter.PrintLine(message);
        }

        public static string ReadInput()
        {
            MessagePrinter.Print(GlobalGameMessages.AskingToEnterRowAndColumnMessage);

            string userInput = Console.ReadLine();

            return userInput;
        }

        public static string ReadUserName()
        {
            MessagePrinter.Print(GlobalGameMessages.AskingForUserNameMessage);

            string userName = Console.ReadLine();

            return userName;
        }

        public static int ReadPlayfieldSize()
        {
            // TO DO - need to implement
            return 1;
        }
    }
}
