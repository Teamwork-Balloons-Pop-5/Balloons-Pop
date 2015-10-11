namespace BalloonsPop.Console.ConsoleIO.Reader
{
    using System;

    using BalloonsPop.Console.ConsoleIO.Reader.Contracts;
    using BalloonsPop.Common;
    using BalloonsPop.Common.Constants;

    public class Reader : IReader
    {
        // Finished
        public int ReadPlayfieldSize()
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

        // Finished
        public string ReadUsername()
        {
            string username = Console.ReadLine();
            var isCorrect = false;

            while (!isCorrect)
            {
                username = Console.ReadLine();
                isCorrect = Validator.IsStringLenghtValid(username,
                                                          GlobalGameLogicDependencesValues.MinUsernameLength,
                                                          GlobalGameLogicDependencesValues.MaxUsernameLength);
            }

            return username;
        }

        // Finished
        public string ReadUserInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}
