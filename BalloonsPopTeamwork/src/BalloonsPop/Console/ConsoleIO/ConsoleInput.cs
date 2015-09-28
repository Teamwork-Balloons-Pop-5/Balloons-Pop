namespace BalloonsPop.Console.ConsoleIO
{
    using System;

    using BalloonsPop.Common.Constants;

    public class ConsoleInput
    {
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
