// <copyright  file="Reader.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

﻿namespace BalloonsPop.Console.ConsoleIO.Reader
{
    using System;
    using BalloonsPop.Common;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Console.ConsoleIO.Reader.Contracts;

    /// <summary>
    /// creates reader for the game objects
    /// </summary>
    public class Reader : IReader
    {
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

        /// <summary>
        /// Reads the username of the player
        /// </summary>
        public string ReadUsername()
        {
            string username = string.Empty;
            var isCorrect = false;

            do
            {
                username = Console.ReadLine();
                isCorrect = Validator.IsStringLenghtValid(
                    username,
                    GlobalGameLogicDependencesValues.MinUsernameLength,
                    GlobalGameLogicDependencesValues.MaxUsernameLength);
            }
            while (isCorrect);

            return username;
        }

        /// <summary>
        /// Reads user input
        /// </summary>
        public string ReadUserInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}
