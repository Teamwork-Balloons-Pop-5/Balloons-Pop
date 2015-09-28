using BalloonsPop.Common.Constants;
namespace BalloonsPop.Console.ConsoleIO
{
    public class ConsoleOutput
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
    }
}
