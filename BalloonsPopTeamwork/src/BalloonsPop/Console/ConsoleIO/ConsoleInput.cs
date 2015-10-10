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
            Menu menu = new Menu();
            string gameModeString = string.Empty;
            string error = string.Empty;
            int gameMode = 0;
            bool validGameMode = false;

            do
            {
                try
                {
                    do
                    {
                        string message1 = "Please select your desired game mode: ";

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(string.Empty);
                        Console.Write(string.Format("{0," + ((Console.WindowWidth / 2) + (message1.Length / 2)) + "}", message1));
                        Console.ForegroundColor = ConsoleColor.Green;
                        gameModeString = Console.ReadLine();
                        Console.ResetColor();
                        gameMode = int.Parse(gameModeString);

                        if ((gameMode > 3) || (gameMode < 1))
                        {
                            error = "Please choose a number either 1, 2, or 3.";
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(string.Format("{0," + ((Console.WindowWidth / 2) + (error.Length / 2)) + "}", error));
                            Console.ResetColor();
                        }
                        else
                        {
                            validGameMode = true;

                            // this.gameMode = gameMode;
                        }
                    }
                    while ((gameMode > 3) || (gameMode < 1));
                }
                catch (FormatException)
                {
                    error = " Please enter a number in digit form (e.g. 3)";

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(string.Format("{0," + ((Console.WindowWidth / 2) + (error.Length / 2)) + "}", error));
                    Console.ResetColor();
                }
            }
            while (!validGameMode);

            Console.Clear();
            menu.PrintMenuHeader();

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
