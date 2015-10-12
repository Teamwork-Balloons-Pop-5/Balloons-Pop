// <copyright  file="Menu.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Console.ConsoleUI.Menu
{
    using System;
    using Common.Constants;

    /// <summary>
    /// creates the Menu for the game
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// constant that holds the text for easy game mode
        /// </summary>
        private const string GameModeEasy = "1. EASY";
        /// <summary>
        /// constant that holds the text for medium game mode
        /// </summary>
        private const string GameModeMedium = "2. MEDIUM";
        /// <summary>
        /// constant that holds the text for hard game mode
        /// </summary>
        private const string GameModeHard = "3. HARD";
        /// <summary>
        /// constant that holds the text that welcomes the user into the game
        /// </summary>
        private const string WelcomeGameMessage = "Welcome to the game of Balloons Pop.";
        /// <summary>
        /// constant that holds the text that explains the goal of the game to the user
        /// </summary>
        private const string AimOfGameMessage = "The aim of the game is to pop all balloons.";
        /// <summary>
        /// constant that holds the text that serves as tutorial for the game
        /// </summary>
        private const string HowToPlayMessage = "To do this you enter balloon coordinates in a turn-by-turn basis.";
        /// <summary>
        /// constant that holds the text for choose game mode
        /// </summary>
        private const string ChooseGameModeMessage = "Please choose game mode";
        /// <summary>
        /// constant that holds empty text line
        /// </summary>
        private const string EmptyTextLine = "";
        /// <summary>
        /// constant that holds the top border with the caption of the game
        /// </summary>
        private const string BorderTop = GameTitle.GameTitleBorder + EmptyTextLine;
        /// <summary>
        /// constant that holds the bottom border with the caption of the game
        /// </summary>
        private const string BorderBottom = EmptyTextLine + GameTitle.GameTitleBorder;

        /// <summary>
        /// This field holds the game mode of the game that corresponds to which playfield will be generated
        /// </summary>
        private int gameMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu" /> class.
        /// </summary>
        public Menu()
        {
        }

        /// <summary>
        /// Gets or sets the GameMode;
        /// </summary>
        public int GameMode
        {
            get
            {
                return this.gameMode;
            }
        }

        /// <summary>
        /// Prints the menu header to the console
        /// </summary>
        public void PrintMenuHeader()
        {
            this.PrintGameText(ConsoleColor.White, BorderTop);
            this.PrintGameText(ConsoleColor.Yellow, GameTitle.GameTitlePartOne);
            this.PrintGameText(ConsoleColor.Red, GameTitle.GameTitlePartTwo, GameTitle.GameTitlePartThree);
            this.PrintGameText(ConsoleColor.Green, GameTitle.GameTitlePartFour, GameTitle.GameTitlePartFive);
            this.PrintGameText(ConsoleColor.DarkBlue, GameTitle.GameTitlePartSix, GameTitle.GameTitlePartSeven);
            this.PrintGameText(ConsoleColor.White, BorderBottom);
        }

        /// <summary>
        /// Prints the menu body to the console
        /// </summary>
        public void PrintMenuBody()
        {
            this.PrintGameText(
                ConsoleColor.White,
                          WelcomeGameMessage,
                          AimOfGameMessage,
                          HowToPlayMessage,
                          EmptyTextLine);

            this.PrintGameText(ConsoleColor.DarkBlue, ChooseGameModeMessage, EmptyTextLine);

            this.PrintGameText(
                ConsoleColor.Green,
                          GameModeEasy,
                          EmptyTextLine,
                          GameModeMedium,
                          EmptyTextLine,
                          GameModeHard,
                          EmptyTextLine);

            this.PrintGameText(ConsoleColor.White, BorderBottom);
        }

        /// <summary>
        /// Prints the menu footer to the console and asks the user to input game mode till it gets acceptable value
        /// </summary>
        public void PrintMenuFooter()
        {
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
                        this.CenterStringWrite(message1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        gameModeString = Console.ReadLine();
                        Console.ResetColor();
                        gameMode = int.Parse(gameModeString);

                        if ((gameMode > 3) || (gameMode < 1))
                        {
                            error = "Please choose a number either 1, 2, or 3.";
                            Console.ForegroundColor = ConsoleColor.Red;
                            this.CenterString(error);
                            Console.ResetColor();
                        }
                        else
                        {
                            validGameMode = true;
                            this.gameMode = gameMode;
                        }
                    }
                    while ((gameMode > 3) || (gameMode < 1));
                }
                catch (FormatException)
                {
                    error = " Please enter a number in digit form (e.g. 3)";

                    Console.ForegroundColor = ConsoleColor.Red;
                    this.CenterString(error);
                    Console.ResetColor();
                }
            }
            while (!validGameMode);

            Console.Clear();
            this.PrintMenuHeader();
        }

        /// <summary>
        /// sets the window size and prints the menu
        /// </summary>
        public void Load()
        {
            Console.SetWindowSize(
                GlobalGameLogicDependencesValues.WindowWidth, 
                GlobalGameLogicDependencesValues.WindowHeight);

            this.PrintMenuHeader();
            this.PrintMenuBody();
        }

        /// <summary>
        /// Centers the line messages in the console
        /// </summary>
        private void CenterString(string text)
        {
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        /// <summary>
        /// Centers the messages in the console
        /// </summary>
        private void CenterStringWrite(string text)
        {
            Console.Write(string.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        /// <summary>
        /// Printer fo rthe messages in the game
        /// </summary>
        private void PrintGameText(ConsoleColor color, params string[] text)
        {
            Console.ForegroundColor = color;

            foreach (var textLine in text)
            {
                this.CenterString(textLine);
            }
        }
    }
}
