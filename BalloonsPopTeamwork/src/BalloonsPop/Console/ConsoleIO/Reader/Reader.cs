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

                if (gameMode <= 3 || gameMode >= 1)
                {
                    break;
                }
            }

            Console.Clear();

            return gameMode;
        }

        // Finished
        public string ReadUsername()
        {
            string username = string.Empty;
            var isCorrect = false;

            do
            {
                username = Console.ReadLine();
                isCorrect = Validator.IsStringLenghtValid(username,
                                                          GlobalGameLogicDependencesValues.MinUsernameLength,
                                                          GlobalGameLogicDependencesValues.MaxUsernameLength);
            }
            while (!isCorrect);

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
