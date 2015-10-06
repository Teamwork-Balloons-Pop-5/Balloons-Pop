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
        private const string borderTop = GameTitle.GameTitleBorder + EmptyTextLine;
        private const string borderBottom = EmptyTextLine + GameTitle.GameTitleBorder;

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
            PrintGameText(ConsoleColor.White, borderTop);
            PrintGameText(ConsoleColor.Yellow, GameTitle.GameTitlePartOne);
            PrintGameText(ConsoleColor.Red, GameTitle.GameTitlePartTwo, GameTitle.GameTitlePartThree);
            PrintGameText(ConsoleColor.Green, GameTitle.GameTitlePartFour, GameTitle.GameTitlePartFive);
            PrintGameText(ConsoleColor.DarkBlue, GameTitle.GameTitlePartSix, GameTitle.GameTitlePartSeven);
            PrintGameText(ConsoleColor.White, borderBottom);
        }

        public void PrintMenuBody()
        {
            PrintGameText(ConsoleColor.White,
                          WelcomeGameMessage, 
                          AimOfGameMessage, 
                          HowToPlayMessage,
                          EmptyTextLine);

            PrintGameText(ConsoleColor.DarkBlue, ChooseGameModeMessage, EmptyTextLine);

            PrintGameText(ConsoleColor.Green, 
                          GameModeEasy, 
                          EmptyTextLine, 
                          GameModeMedium, 
                          EmptyTextLine, 
                          GameModeHard, 
                          EmptyTextLine);

            PrintGameText(ConsoleColor.White, borderBottom);
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
                        string Message1 = "Please select your desired game mode: ";

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("");
                        CenterStringWrite(Message1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        gameModeString = Console.ReadLine();
                        Console.ResetColor();
                        gameMode = int.Parse(gameModeString);

                        if ((gameMode > 3) || (gameMode < 1))
                        {
                            error = "Please choose a number either 1, 2, or 3.";
                            Console.ForegroundColor = ConsoleColor.Red;
                            CenterString(error);
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
                    CenterString(error);
                    Console.ResetColor();
                }
            }
            while (!validGameMode);

            Console.Clear();
            PrintMenuHeader();
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
                CenterString(textLine);
            }
        }

        public void Load()
        {
            Console.SetWindowSize(Common.Constants.GlobalGameLogicDependencesValues.WINDOWWIDTH, Common.Constants.GlobalGameLogicDependencesValues.WINDOWHEIGHT);
            this.PrintMenuHeader();
            this.PrintMenuBody();
            this.PrintMenuFooter();
        }
    }
}
