namespace BalloonsPop.Console.ConsoleUI.Menu
{
    using System;

    using Common.Constants;

    public class Menu
    {
        public static void PrintMenuHeader()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(GameTitle.GameTitleBorder + Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.Yellow;
            CenterString(GameTitle.GameTitlePartOne);

            Console.ForegroundColor = ConsoleColor.Red;
            CenterString(GameTitle.GameTitlePartTwo);
            CenterString(GameTitle.GameTitlePartThree);

            Console.ForegroundColor = ConsoleColor.Green;
            CenterString(GameTitle.GameTitlePartFour);
            CenterString(GameTitle.GameTitlePartFive);

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            CenterString(GameTitle.GameTitlePartSix);
            CenterString(GameTitle.GameTitlePartSeven);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Environment.NewLine + GameTitle.GameTitleBorder);

            Console.ResetColor();
        }

        public static void PrintMenuBody()
        {
            string WelcomeMessage = "Welcome to the game of Balloons Pop.";
            string Aim = "The aim of the game is to pop all balloons.";
            string How = "To do this you enter balloon coordinates in a turn-by-turn basis.\n";
            string chooseMode = "Please choose game mode";
            string Mode1 = "1. EASY";
            string Mode2 = "2. MEDIUM";
            string Mode3 = "3. HARD";

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            CenterString(WelcomeMessage);
            CenterString(Aim);
            CenterString(How);

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            CenterString(chooseMode);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            CenterString(Mode1);

            Console.WriteLine("");
            CenterString(Mode2);

            Console.WriteLine("");
            CenterString(Mode3);

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Environment.NewLine + GameTitle.GameTitleBorder);
            Console.ResetColor();
        }

        public static void PrintMenuFooter()
        {
            string gameModeString = string.Empty;
            int gameMode = 0;
            string error = string.Empty;
            bool validGameMode = false;

            do
            {
                try // Asks for game mode until a valid choice is made 
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
                        }
                    }
                    while ((gameMode > 3) || (gameMode < 1)); // Selected game mode must be between 1 & 3 to be valid.
                }
                catch (FormatException) // Catches FormatExceptions & loops until there's no exception.
                {
                    error = " Please enter a number in digit form (e.g. 3)";

                    Console.ForegroundColor = ConsoleColor.Red;
                    CenterString(error);
                    Console.ResetColor();
                }
                catch (OverflowException)
                {
                    error = " Please either choose game mode 1, 2, or 3. There are no hidden easter eggs here.";

                    Console.ForegroundColor = ConsoleColor.Red;
                    CenterString(error);
                    Console.ResetColor();
                }
            }
            while (!validGameMode);

            Console.Clear();
            PrintMenuHeader();
        }

        public static void CenterString(string text)
        {
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        public static void CenterStringWrite(string text)
        {
            Console.Write(string.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        public static void InitializeMenu()
        {
            Console.SetWindowSize(135, 43);
            PrintMenuHeader();
            PrintMenuBody();
            PrintMenuFooter();
        }
    }
}
