// <copyright  file="MenuPrinter.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Console.ConsoleIO.Printer
{
    using System;
    using BalloonsPop.Common.Constants;

    /// <summary>
    /// creates printer for the game menu
    /// </summary>
    public class MenuPrinter : Printer
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
        /// constant that holds the text that asks the user to select game mode
        /// </summary>
        private const string SelecGameModeMessage = "Please select your desired game mode: ";

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
        /// Prints text on the same line
        /// </summary>
        /// <param name="text">takes a string and prints it on the same line</param>
        public override void PrintText(string text)
        {
            Console.Write(string.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        /// <summary>
        /// Prints a line
        /// </summary>
        /// <param name="text">takes a string and prints it on a separate line</param>
        public override void PrintTextLine(string text)
        {
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        /// <summary>
        /// Prints the menu
        /// </summary>
        /// <param name="objs">takes an object array and prints it</param>
        public override void Print(params object[] objs)
        {
            Console.Clear();
            this.SetMenuSize();
            this.PrintMenuHeader();
            this.PrintMenuBody();
            this.PrintMenuFooter();
        }

        /// <summary>
        /// Prints the menu header to the console
        /// </summary>
        private void PrintMenuHeader()
        {
            this.PrintTextWithColor(ConsoleColor.White, true, BorderTop);
            this.PrintTextWithColor(ConsoleColor.Yellow, true, GameTitle.GameTitlePartOne);
            this.PrintTextWithColor(ConsoleColor.Red, true, GameTitle.GameTitlePartTwo, GameTitle.GameTitlePartThree);
            this.PrintTextWithColor(ConsoleColor.Green, true, GameTitle.GameTitlePartFour, GameTitle.GameTitlePartFive);
            this.PrintTextWithColor(ConsoleColor.DarkBlue, true, GameTitle.GameTitlePartSix, GameTitle.GameTitlePartSeven);
            this.PrintTextWithColor(ConsoleColor.White, true, BorderBottom);
        }

        /// <summary>
        /// Prints the menu body to the console
        /// </summary>
        private void PrintMenuBody()
        {
            this.PrintTextWithColor(
                ConsoleColor.White, 
                          true,
                          WelcomeGameMessage,
                          AimOfGameMessage,
                          HowToPlayMessage,
                          EmptyTextLine);

            this.PrintTextWithColor(ConsoleColor.DarkBlue, true, ChooseGameModeMessage, EmptyTextLine);

            this.PrintTextWithColor(
                ConsoleColor.Green,
                          true,
                          GameModeEasy,
                          EmptyTextLine,
                          GameModeMedium,
                          EmptyTextLine,
                          GameModeHard,
                          EmptyTextLine);

            this.PrintTextWithColor(ConsoleColor.White, true, BorderBottom);
        }

        /// <summary>
        /// Sets the size for the menu
        /// </summary>
        private void SetMenuSize()
        {
            Console.SetWindowSize(
                GlobalGameLogicDependencesValues.WindowWidth,
                GlobalGameLogicDependencesValues.WindowHeight);
        }

        /// <summary>
        /// Prints the menu footer to the console
        /// </summary>
        private void PrintMenuFooter()
        {
            this.PrintTextWithColor(ConsoleColor.Yellow, false, SelecGameModeMessage);
        }

        /// <summary>
        /// Prints the balloons with colour to the console
        /// </summary>
        /// <param name="color">object form type {ConsoleColor} that gives the colour which the balloon needs to be printed with</param>
        /// <param name="hasNewLine">bool variable that sets wether we have to print new line or not</param>
        /// <param name="messages">string array that prints the messages to the game</param>
        private void PrintTextWithColor(ConsoleColor color, bool hasNewLine = true, params string[] messages)
        {
            Console.ForegroundColor = color;

            foreach (var message in messages)
            {
                if (hasNewLine)
                {
                    this.PrintTextLine(message);
                }
                else
                {
                    this.PrintText(message);
                }
            }
        }
    }
}
