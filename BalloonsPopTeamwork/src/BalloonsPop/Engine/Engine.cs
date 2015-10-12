// <copyright  file="Engine.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Engine
{
    using System;
    using BalloonsPop.Common;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Console.ConsoleIO;
    using BalloonsPop.Console.ConsoleIO.Printer;
    using BalloonsPop.Console.ConsoleIO.Printer.Contracts;
    using BalloonsPop.Console.ConsoleIO.Reader;
    using BalloonsPop.Console.ConsoleIO.Reader.Contracts;
    using BalloonsPop.Console.ConsoleUI.Colors;
    using BalloonsPop.Console.ConsoleUI.Playfield;
    using BalloonsPop.Engine.Contracts;
    using BalloonsPop.Game.Logic;
    using Wintellect.PowerCollections;

    /// <summary>
    /// creates instance of game engine that is responsible for the main actions in the game
    /// </summary>
    public class Engine : IEngine
    {
        /// <summary>
        /// The constant holds the message prompting the user to enter a choice
        /// </summary>
        private const string UserInputMessage = "Enter your choice: ";

        /// <summary>
        /// This field holds the playfield matrix
        /// </summary>
        private Playfield playfield;

        /// <summary>
        /// This field holds the logic with which the balloons will be popped
        /// </summary>
        private IPopStrategy popLogic;

        /// <summary>
        /// This field holds the remaining balloons count
        /// </summary>
        private int balloonsLeft;

        /// <summary>
        /// This field holds the user moves count
        /// </summary>
        private int userMoves;

        /// <summary>
        /// This field holds the menu printer instance
        /// </summary>
        private MenuPrinter menuPrinter = new MenuPrinter();

        /// <summary>
        /// This field holds the playfield printer instance
        /// </summary>
        private PlayfieldPrinter playfieldPrinter = new PlayfieldPrinter();

        /// <summary>
        /// This field holds the balloon colour instance
        /// </summary>
        private BalloonColor colors = new BalloonColor();

        /// <summary>
        /// This field holds the message printer instance
        /// </summary>
        private MessagePrinter messagePrinter = new MessagePrinter();

        /// <summary>
        /// This field holds the scoreboard printer instance
        /// </summary>
        private ScoreboardPrinter scoreboardPrinter = new ScoreboardPrinter();

        /// <summary>
        /// This field holds the reader instance
        /// </summary>
        private IReader reader = new Reader();

        /// <summary>
        /// This field holds ordered dictionary from int and string that takes the username and points
        /// </summary>
        private OrderedMultiDictionary<int, string> statistics = new OrderedMultiDictionary<int, string>(true);

        /// <summary>
        /// checks wether game is finished
        /// </summary>
        private bool IsFinished
        {
            get
            {
                return this.balloonsLeft == 0;
            }
        }

        /// <summary>
        /// Runs game till IsFinished is true
        /// </summary>
        public void Run(
                    Playfield playfield,
                        IPopStrategy gamePopLogic, 
                        BalloonColor colors,
                        IPrinter menuPrinter, 
                        IPrinter playfieldPrinter)
        {
            menuPrinter.Print();

            playfield = this.InitializePlayfield();
            gamePopLogic = new RecursivePopStrategy();

            this.InitializeGame(playfield, gamePopLogic);
            playfieldPrinter.Print(playfield, colors);
            this.PlayGame();
        }

        /// <summary>
        /// Starts game
        /// </summary>
        private void InitializeGame(Playfield gamePlayfield, IPopStrategy gamePopLogic)
        {
            this.playfield = gamePlayfield;
            this.popLogic = gamePopLogic;
            this.balloonsLeft = gamePlayfield.Width * gamePlayfield.Height;
            this.userMoves = 0;
        }

        /// <summary>
        /// Creates the playfield matrix with the balloons in it
        /// </summary>
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

        /// <summary>
        /// Runs game and applies game logic
        /// </summary>
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

            this.ProcessUserDecision();
        }

        /// <summary>
        /// Checks in which stage of the game are we and runs it
        /// </summary>
        private void ProcessInput(string input)
        {
            switch (input)
            {
                case "top":
                    this.scoreboardPrinter.Print(this.statistics);
                    break;
                case "restart":
                    this.Run(this.playfield, this.popLogic, this.colors, this.menuPrinter, this.playfieldPrinter);
                    break;
                case "exit":
                    this.Exit();
                    break;
                default:
                    this.ProcessInputBalloonPosition(input);
                    break;
            }
        }

        /// <summary>
        /// Exits game
        /// </summary>
        private void Exit()
        {
            this.messagePrinter.Print(GlobalGameMessages.ExitGameMessage);

            Environment.Exit(0);
        }

        /// <summary>
        /// Moves the ballons based on what has been popped so far
        /// </summary>
        private void ProcessInputBalloonPosition(string input)
        {
            try
            {
                var splittedUserInput = input.Trim().Split(new char[] { ' ', ',', '.', '/' });

                string row = splittedUserInput[0];
                string column = splittedUserInput[1];

                bool areValid = Validator.IsValidRowAndColumn(row, column);

                if (!areValid)
                {
                    this.messagePrinter.Print(GlobalGameMessages.WrongInputMessage);
                }

                int currentRow = int.Parse(splittedUserInput[0]);
                int currentCol = int.Parse(splittedUserInput[1]);

                if (this.IsLegalMove(currentRow, currentCol))
                {
                    this.RemovePoppedBalloons(currentRow, currentCol);
                }
                else
                {
                    this.messagePrinter.Print(GlobalGameMessages.TryingToPopMissingBalloonMessage);
                }
            }
            catch (FormatException)
            {
                this.messagePrinter.Print("Row and col are not entered in the valid format.");
                this.messagePrinter.Print(GlobalGameMessages.WrongInputMessage);
            }
            catch (IndexOutOfRangeException)
            {
                this.messagePrinter.Print("You did not enter two numbers for row and col.");
                this.messagePrinter.Print(GlobalGameMessages.WrongInputMessage);
            }
        }

        /// <summary>
        /// adds user to scoreboard
        /// </summary>
        private void AddUserToScoreboard()
        {
            string message = string.Format(GlobalGameMessages.InTopFiveWinningMessage, this.userMoves);
            this.messagePrinter.PrintTextLine(message);

            this.messagePrinter.PrintText(GlobalGameMessages.AskingForUserNameMessage);
            string username = this.reader.ReadUsername();

            this.statistics.Add(this.userMoves, username);
        }

        /// <summary>
        /// asks user for restart and runs the user choice
        /// </summary>
        private void ProcessUserDecision()
        {
            this.messagePrinter.Print("Do you want to play again: Yes/No");
            string userDescision = this.reader.ReadUserInput().ToLower();

            if (userDescision == "yes")
            {
                this.Run(this.playfield, this.popLogic, this.colors, this.menuPrinter, this.playfieldPrinter);
            }
            else
            {
                this.Exit();
            }
        }

        /// <summary>
        /// removes popped balloons
        /// </summary>
        private void RemovePoppedBalloons(int row, int col)
        {
            this.balloonsLeft -= this.popLogic.PopBaloons(row, col, this.playfield);
        }

        /// <summary>
        /// checks wether the user has entered valid move
        /// </summary>
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
