namespace BalloonsPop.Console.ConsoleIO
{
    using System;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Common;

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

            var isCorrectect = Validator.IsStringLenghtValid(userName, Common.Constants.GlobalGameLogicDependencesValues.MINUSERNAMELENGHT, Common.Constants.GlobalGameLogicDependencesValues.MAXUSERNAMELENGHT);

            while (!isCorrectect)
            {
                printer.Print(string.Format(GlobalGameMessages.UserNameLenghtMessage, Common.Constants.GlobalGameLogicDependencesValues.MINUSERNAMELENGHT, Common.Constants.GlobalGameLogicDependencesValues.MAXUSERNAMELENGHT));
                printer.Print(GlobalGameMessages.AskingForUserNameMessage);
                userName = Console.ReadLine();
            }
            return userName;
        }

        public static int ReadPlayfieldSize()
        {
            // TO DO - need to implement
            return 1;
        }
    }
}
