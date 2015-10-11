namespace BalloonsPop.Console.ConsoleIO.Printer
{
    using BalloonsPop.Common.Constants;
    using System;

    public class MenuPrinter : Printer
    {
        private const string GameModeEasy = "1. EASY";
        private const string GameModeMedium = "2. MEDIUM";
        private const string GameModeHard = "3. HARD";
        private const string WelcomeGameMessage = "Welcome to the game of Balloons Pop.";
        private const string AimOfGameMessage = "The aim of the game is to pop all balloons.";
        private const string HowToPlayMessage = "To do this you enter balloon coordinates in a turn-by-turn basis.";
        private const string ChooseGameModeMessage = "Please choose game mode";
        private const string SelecGameModeMessage = "Please select your desired game mode: ";
        private const string EmptyTextLine = "";
        private const string BorderTop = GameTitle.GameTitleBorder + EmptyTextLine;
        private const string BorderBottom = EmptyTextLine + GameTitle.GameTitleBorder;

        // Finished
        public override void PrintText(string text)
        {
            Console.Write(string.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        // Finished
        public override void PrintTextLine(string text)
        {
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        // Finished
        private void PrintMenuHeader()
        {
            this.PrintTextWithColor(ConsoleColor.White, BorderTop);
            this.PrintTextWithColor(ConsoleColor.Yellow, GameTitle.GameTitlePartOne);
            this.PrintTextWithColor(ConsoleColor.Red, GameTitle.GameTitlePartTwo, GameTitle.GameTitlePartThree);
            this.PrintTextWithColor(ConsoleColor.Green, GameTitle.GameTitlePartFour, GameTitle.GameTitlePartFive);
            this.PrintTextWithColor(ConsoleColor.DarkBlue, GameTitle.GameTitlePartSix, GameTitle.GameTitlePartSeven);
            this.PrintTextWithColor(ConsoleColor.White, BorderBottom);
        }

        // Finished
        private void PrintMenuBody()
        {
            this.PrintTextWithColor(
                ConsoleColor.White,
                          WelcomeGameMessage,
                          AimOfGameMessage,
                          HowToPlayMessage,
                          EmptyTextLine);

            this.PrintTextWithColor(ConsoleColor.DarkBlue, ChooseGameModeMessage, EmptyTextLine);

            this.PrintTextWithColor(
                ConsoleColor.Green,
                          GameModeEasy,
                          EmptyTextLine,
                          GameModeMedium,
                          EmptyTextLine,
                          GameModeHard,
                          EmptyTextLine);

            this.PrintTextWithColor(ConsoleColor.White, BorderBottom);
        }

        // Finished
        private void SetMenuSize()
        {
            Console.SetWindowSize(GlobalGameLogicDependencesValues.WindowWidth,
                                  GlobalGameLogicDependencesValues.WindowHeight);
        }

        // Finished
        private void PrintMenuFooter()
        {
            this.PrintTextWithColor(ConsoleColor.Yellow, SelecGameModeMessage);
        }

        // Finished
        private void PrintTextWithColor(ConsoleColor color, params string[] messages)
        {
            Console.ForegroundColor = color;

            foreach (var message in messages)
            {
                this.PrintTextLine(message);
            }
        }

        // Finished
        public override void Print(params object[] objs)
        {
            this.SetMenuSize();
            this.PrintMenuHeader();
            this.PrintMenuBody();
            this.PrintMenuFooter();
        }
    }
}
