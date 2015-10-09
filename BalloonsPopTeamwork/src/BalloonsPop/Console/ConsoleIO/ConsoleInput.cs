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

            var isCorrect = Validator.IsStringLenghtValid(userName, Common.Constants.GlobalGameLogicDependencesValues.MinUsernameLength, Common.Constants.GlobalGameLogicDependencesValues.MaxUsernameLength);

            while (isCorrect)
            {
                printer.Print(string.Format(GlobalGameMessages.UserNameLenghtMessage, Common.Constants.GlobalGameLogicDependencesValues.MinUsernameLength, Common.Constants.GlobalGameLogicDependencesValues.MaxUsernameLength));
                printer.Print(GlobalGameMessages.AskingForUserNameMessage);
                userName = Console.ReadLine();
            }
            return userName;
        }

        public static int ReadPlayfieldSize()
        {
            int n = int.Parse(Console.ReadLine());
            return n;
        }
    }
}
