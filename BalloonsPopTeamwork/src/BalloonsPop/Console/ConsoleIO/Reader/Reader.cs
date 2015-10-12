<<<<<<< HEAD
﻿// <copyright  file="Reader.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Console.ConsoleIO.Reader
=======
﻿namespace BalloonsPop.Console.ConsoleIO.Reader
>>>>>>> 8e628ea99bb0e0e8829ca0fd021a641b917ec1e8
{
    using System;
    using BalloonsPop.Common;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Console.ConsoleIO.Reader.Contracts;

<<<<<<< HEAD
    /// <summary>
    /// creates reader for the game objects
    /// </summary>
    public class Reader : IReader
    {
        /// <summary>
        /// Reads the size of the playfield
        /// </summary>
=======
    public class Reader : IReader
    {
        // Finished
>>>>>>> 8e628ea99bb0e0e8829ca0fd021a641b917ec1e8
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

<<<<<<< HEAD
        /// <summary>
        /// Reads the username of the player
        /// </summary>
=======
        // Finished
>>>>>>> 8e628ea99bb0e0e8829ca0fd021a641b917ec1e8
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
<<<<<<< HEAD
            while (!isCorrect);
=======
            while (isCorrect);
>>>>>>> 8e628ea99bb0e0e8829ca0fd021a641b917ec1e8

            return username;
        }

<<<<<<< HEAD
        /// <summary>
        /// Reads user input
        /// </summary>
=======
        // Finished
>>>>>>> 8e628ea99bb0e0e8829ca0fd021a641b917ec1e8
        public string ReadUserInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 8e628ea99bb0e0e8829ca0fd021a641b917ec1e8
