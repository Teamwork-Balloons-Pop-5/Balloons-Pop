namespace BalloonsPop.Console.ConsoleIO
{
    using BalloonsPop.Common.Constants;

    public class ConsoleOutput
    {
        private MessagePrinter printer = new MessagePrinter();

        public void PrintWelcomeMessage()
        {
            printer.PrintLine(GlobalGameMessages.WelcomeMessage);
        }

        public void PrintInvalidInputMessage()
        {
            printer.PrintLine(GlobalGameMessages.WrongInputMessage);
        }

        public void PrintExitMessage(int userMoves, int balloonsLeft)
        {
            printer.PrintLine(GlobalGameMessages.ExitGameMessage);
            printer.PrintLine(userMoves.ToString());
            printer.PrintLine(balloonsLeft.ToString());
        }

        public void PrintInvalidMoveMessage()
        {
            printer.PrintLine(GlobalGameMessages.TryingToPopMissingBalloonMessage);
        }

        public void PrintWinMessage(int userMoves)
        {
            string message = string.Format(GlobalGameMessages.InTopFiveWinningMessage, userMoves);
            printer.PrintLine(message);
        }
    }
}
