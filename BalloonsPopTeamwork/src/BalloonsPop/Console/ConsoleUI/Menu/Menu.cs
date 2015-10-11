namespace BalloonsPop.Console.ConsoleUI.Menu
{
    using System;

    using Common.Constants;

    public class Menu
    {
        private const string GameModeEasy = "1. EASY";
        private const string GameModeMedium = "2. MEDIUM";
        private const string GameModeHard = "3. HARD";
        private const string WelcomeGameMessage = "Welcome to the game of Balloons Pop.";
        private const string AimOfGameMessage = "The aim of the game is to pop all balloons.";
        private const string HowToPlayMessage = "To do this you enter balloon coordinates in a turn-by-turn basis.";
        private const string ChooseGameModeMessage = "Please choose game mode";
        private const string EmptyTextLine = "";
        private const string BorderTop = GameTitle.GameTitleBorder + EmptyTextLine;
        private const string BorderBottom = EmptyTextLine + GameTitle.GameTitleBorder;

        private int gameMode;

        public Menu()
        {
        }

        public int GameMode
        {
            get
            {
                return this.gameMode;
            }
        }

        public void PrintMenuHeader()
        {
            this.PrintGameText(ConsoleColor.White, BorderTop);
            this.PrintGameText(ConsoleColor.Yellow, GameTitle.GameTitlePartOne);
            this.PrintGameText(ConsoleColor.Red, GameTitle.GameTitlePartTwo, GameTitle.GameTitlePartThree);
            this.PrintGameText(ConsoleColor.Green, GameTitle.GameTitlePartFour, GameTitle.GameTitlePartFive);
            this.PrintGameText(ConsoleColor.DarkBlue, GameTitle.GameTitlePartSix, GameTitle.GameTitlePartSeven);
            this.PrintGameText(ConsoleColor.White, BorderBottom);
        }

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
                        Console.WriteLine(string.Empty);
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

        public void Load()
        {
            Console.SetWindowSize(
                GlobalGameLogicDependencesValues.WindowWidth, 
                GlobalGameLogicDependencesValues.WindowHeight);

            this.PrintMenuHeader();
            this.PrintMenuBody();
        }

        private void CenterString(string text)
        {
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        private void CenterStringWrite(string text)
        {
            Console.Write(string.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

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
