namespace BalloonsPop.Console.ConsoleIO
{
    using System;

    using BalloonsPop.Common.Constants;

    public class ConsoleInput
    {
        private MessagePrinter printer = new MessagePrinter();

        public string ReadInput()
        {
            printer.Print(GlobalGameMessages.AskingToEnterRowAndColumnMessage);

            string userInput = Console.ReadLine();

            return userInput;
        }

        public string ReadUserName()
        {
            printer.Print(GlobalGameMessages.AskingForUserNameMessage);

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
