namespace BalloonsPop.Engine
{
    using System;

    using BalloonsPop.Console.ConsoleIO;
    using BalloonsPop.Console.ConsoleUI.Menu;
    using BalloonsPop.Console.ConsoleUI.Playfield;
    using BalloonsPop.Engine.Contracts;
    using BalloonsPop.Game.Logic;
    using Wintellect.PowerCollections;
    using BalloonsPop.Console.ConsoleIO.Printer.Contracts;
    using BalloonsPop.Console.ConsoleIO.Printer;
    using BalloonsPop.Console.ConsoleIO.Reader.Contracts;
    using BalloonsPop.Console.ConsoleIO.Reader;
    using BalloonsPop.Console.ConsoleUI.Colors;
    using BalloonsPop.Common.Constants;

    public sealed class Engine : IEngine
    {
        private const string UserInputMessage = "Enter your choise: ";

        private static Engine engineInstance;
        private Playfield playfield;
        private IPopStrategy popLogic;
        private int balloonsLeft;
        private int userMoves;
        private MenuPrinter menuPrinter = new MenuPrinter();
        private PlayfieldPrinter playfieldPrinter = new PlayfieldPrinter();
        private BalloonColor colors = new BalloonColor();
        private MessagePrinter messagePrinter = new MessagePrinter();
        private ScoreboardPrinter scoreboardPrinter = new ScoreboardPrinter();
        private IReader reader = new Reader();
        private OrderedMultiDictionary<int, string> statistics = new OrderedMultiDictionary<int, string>(true);

        // ConsoleIO
        // private ConsoleOutput consoleOutput = new ConsoleOutput();
        // private ConsoleInput consoleInput = new ConsoleInput();
        private Menu menu = new Menu();

        private Engine()
        {
        }

        public static Engine Instance
        {
            get
            {
                if (engineInstance == null)
                {
                    engineInstance = new Engine();
                }

                return engineInstance;
            }
        }

        private bool IsFinished
        {
            get
            {
                return this.balloonsLeft == 0;
            }
        }

        public void Start()
        {
            this.menuPrinter.Print();

            var playfield = this.InitializePlayfield();
            var gamePopLogic = new MovingPopStrategy();

            this.InitializeGame(playfield, gamePopLogic);
            this.playfieldPrinter.Print(this.playfield, this.colors);
            this.PlayGame();
        }

        private void InitializeGame(Playfield gamePlayfield, IPopStrategy gamePopLogic)
        {
            this.playfield = gamePlayfield;
            this.popLogic = gamePopLogic;
            this.balloonsLeft = gamePlayfield.Width * gamePlayfield.Height;
            this.userMoves = 0;
        }

        // Finished
        private Playfield InitializePlayfield()
        {
            int playfieldSize = this.reader.ReadPlayfieldSize();
            bool isPlayfieldSizeCorrect = true;

            Playfield playfield = null;

            while (isPlayfieldSizeCorrect)
            {
                PlayfieldFactory playfiledFactory = null;

                switch (playfieldSize)
                {
                    case 1:
                        playfiledFactory = new SmallPlayfieldCreator();
                        playfield = playfiledFactory.CreatePlayfield();
                        isPlayfieldSizeCorrect = false;
                        break;
                    case 2:
                        playfiledFactory = new MediumPlayfieldCreator();
                        playfield = playfiledFactory.CreatePlayfield();
                        isPlayfieldSizeCorrect = false;
                        break;
                    case 3:
                        playfiledFactory = new LargePlayfieldCreator();
                        playfield = playfiledFactory.CreatePlayfield();
                        isPlayfieldSizeCorrect = false;
                        break;
                }
            }

            return playfield;
        }

        private void PlayGame()
        {
            while (!this.IsFinished)
            {
                this.userMoves++;

                this.messagePrinter.PrintText(UserInputMessage);
                string currentInput = this.reader.ReadUserInput();

                this.ProcessInput(currentInput);

                this.playfieldPrinter.Print(this.playfield, this.colors);
            }

            this.AddUserToScoreboard();

            this.scoreboardPrinter.Print(this.statistics);

            this.ProcessUserDescision();
        }

        private void ProcessInput(string input)
        {
            switch (input)
            {
                case "top":
                    this.scoreboardPrinter.Print(this.statistics);
                    break;
                case "restart":
                    this.Start();
                    break;
                case "exit":
                    this.Exit();
                    break;
                default:
                    this.ProcessInputBalloonPosition(input);
                    break;
            }
        }

        private void Exit()
        {
            this.messagePrinter.Print(GlobalGameMessages.ExitGameMessage);

            Environment.Exit(0);
        }

        private void ProcessInputBalloonPosition(string input)
        {
            try
            {
                var splittedUserInput = input.Split(' ');
                int currentRow = int.Parse(splittedUserInput[0]);
                int currentCol = int.Parse(splittedUserInput[1]);

                if (this.IsLegalMove(currentRow, currentCol))
                {
                    this.RemoveAllBaloons(currentRow, currentCol);
                }
                else
                {
                    this.messagePrinter.Print(GlobalGameMessages.TryingToPopMissingBalloonMessage);
                }
            }
            catch (FormatException)
            {
                // extract to consoleIO or remove
                Console.WriteLine("Row and col are not entered in the valid format.");
                this.messagePrinter.Print(GlobalGameMessages.WrongInputMessage);
            }
            catch (IndexOutOfRangeException)
            {
                // extract to ConsoleIOFacade or remove
                Console.WriteLine("You did not enter two numbers for row and col.");
                this.messagePrinter.Print(GlobalGameMessages.WrongInputMessage);
            }
        }

        private void AddUserToScoreboard()
        {
            string message = string.Format(GlobalGameMessages.InTopFiveWinningMessage, this.userMoves);
            this.messagePrinter.PrintTextLine(message);

            this.messagePrinter.PrintText(GlobalGameMessages.AskingForUserNameMessage);
            string username = this.reader.ReadUsername();

            this.statistics.Add(this.userMoves, username);
        }

        private void ProcessUserDescision()
        {
            this.messagePrinter.Print("Do you want to play again: Yes/No");
            string userDescision = Console.ReadLine().ToLower();

            if (userDescision == "yes")
            {
                this.Start();
            }
            else
            {
                this.Exit();
            }
        }

        private void RemoveAllBaloons(int row, int col)
        {
            this.balloonsLeft -= this.popLogic.PopBaloons(row, col, this.playfield);
        }

        private bool IsLegalMove(int row, int col)
        {
            bool isValidRow = (row >= 0) && (row < this.playfield.Height);
            bool isValidCol = (col >= 0) && (col < this.playfield.Width);

            if (isValidRow && isValidCol)
            {
                return this.playfield.Field[row, col] != "0";
            }
            else
            {
                return false;
            }
        }
    }
}
