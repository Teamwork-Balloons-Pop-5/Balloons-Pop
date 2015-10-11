namespace BalloonsPop.Console.ConsoleIO
{
    using System;
    using BalloonsPop.Common;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Console.ConsoleUI.Menu;

    public class ConsoleInput
    {
        private MessagePrinter printer = new MessagePrinter();

        public static int ReadPlayfieldSize()
        {
            int gameMode = 0;
            string userInput = string.Empty;
            bool validGameMode = false;

            while (!validGameMode)
            {
                userInput = Console.ReadLine();
                validGameMode = int.TryParse(userInput, out gameMode);
            }

            Console.Clear();

            return gameMode;
        }

        public string ReadInput()
        {
            this.printer.Print(GlobalGameMessages.AskingToEnterRowAndColumnMessage);

            string userInput = Console.ReadLine();

            return userInput;
        }

        public string ReadUserName()
        {
            this.printer.Print(GlobalGameMessages.AskingForUserNameMessage);

            string userName = Console.ReadLine();

            var isCorrect = Validator.IsStringLenghtValid(userName, Common.Constants.GlobalGameLogicDependencesValues.MinUsernameLength, Common.Constants.GlobalGameLogicDependencesValues.MaxUsernameLength);

            while (isCorrect)
            {
                this.printer.Print(string.Format(GlobalGameMessages.UserNameLenghtMessage, Common.Constants.GlobalGameLogicDependencesValues.MinUsernameLength, Common.Constants.GlobalGameLogicDependencesValues.MaxUsernameLength));
                this.printer.Print(GlobalGameMessages.AskingForUserNameMessage);
                userName = Console.ReadLine();
            }

            return userName;
        }
    }
}
