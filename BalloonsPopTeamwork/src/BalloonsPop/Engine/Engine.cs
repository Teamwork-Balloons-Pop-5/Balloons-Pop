namespace BalloonsPop.Engine
{
    using System;

    using BalloonsPop.Console.ConsoleIO;
    using BalloonsPop.Console.ConsoleUI.Menu;
    using BalloonsPop.Console.ConsoleUI.Playfield;
    using BalloonsPop.Engine.Contracts;
    using BalloonsPop.Game.Logic;
    using Wintellect.PowerCollections;

    public sealed class Engine : IEngine
    {
        private static Engine engineInstance;
        private Playfield playfield;
        private IPopStrategy popLogic;
        private int balloonsLeft;
        private int userMoves;
        private OrderedMultiDictionary<int, string> statistics = new OrderedMultiDictionary<int, string>(true);

        // ConsoleIO
        private ConsoleOutput consoleOutput = new ConsoleOutput();
        private ConsoleInput consoleInput = new ConsoleInput();
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
            var playfield = this.InitializePlayfield();
            var gamePopLogic = new MovingPopStrategy();

            this.InitializeGame(playfield, gamePopLogic);
            Console.Clear();
            this.menu.PrintMenuHeader();
            this.consoleOutput.PrintTable(this.playfield);
            this.PlayGame();
        }

        private void InitializeGame(Playfield gamePlayfield, IPopStrategy gamePopLogic)
        {
            this.playfield = gamePlayfield;
            this.popLogic = gamePopLogic;
            this.balloonsLeft = gamePlayfield.Width * gamePlayfield.Height;
            this.userMoves = 0;
        }

        private Playfield InitializePlayfield()
        {
            int playfieldSize = ConsoleInput.ReadPlayfieldSize();
            Playfield playfield = null;

            bool isPlayfieldSizeIncorrect = true;

            while (isPlayfieldSizeIncorrect)
            {
                PlayfieldFactory playfiledFactory = null;

                switch (playfieldSize)
                {
                    case 1:
                        playfiledFactory = new SmallPlayfieldFactory();
                        playfield = playfiledFactory.CreatePlayfield();
                        isPlayfieldSizeIncorrect = false;
                        break;
                    case 2:
                        playfiledFactory = new MediumPlayfieldFactory();
                        playfield = playfiledFactory.CreatePlayfield();
                        isPlayfieldSizeIncorrect = false;
                        break;
                    case 3:
                        playfiledFactory = new LargePlayfieldFactory();
                        playfield = playfiledFactory.CreatePlayfield();
                        isPlayfieldSizeIncorrect = false;
                        break;
                    default:
                        // Extract to consoleIO
                        Console.WriteLine("You have entered incorrect field size");
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

                string currentInput = this.consoleInput.ReadInput();

                this.ProcessInput(currentInput);

                this.consoleOutput.PrintTable(this.playfield);
            }

            this.AddUserToScoreboard();

            string scoreboard = this.consoleOutput.CreateScoreboardString(this.statistics);
            Console.WriteLine(scoreboard);

            this.ProcessUserDescision();
        }

        private void ProcessInput(string input)
        {
            switch (input)
            {
                case "top":
                    this.consoleOutput.CreateScoreboardString(this.statistics);
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
            this.consoleOutput.PrintExitMessage(this.userMoves, this.balloonsLeft);

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
                    this.consoleOutput.PrintInvalidMoveMessage();
                }
            }
            catch (FormatException)
            {
                // extract to consoleIO or remove
                Console.WriteLine("Row and col are not entered in the valid format.");
                this.consoleOutput.PrintInvalidInputMessage();
            }
            catch (IndexOutOfRangeException)
            {
                // extract to ConsoleIOFacade or remove
                Console.WriteLine("You did not enter two numbers for row and col.");
                this.consoleOutput.PrintInvalidInputMessage();
            }
        }

        private void AddUserToScoreboard()
        {
            this.consoleOutput.PrintWinMessage(this.userMoves);

            string username = this.consoleInput.ReadUserName();

            this.statistics.Add(this.userMoves, username);
        }

        private void ProcessUserDescision()
        {
            // extract to consoleIO
            Console.WriteLine("Do you want to play again: Yes/No");
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

            // Console.WriteLine(this.balloonsLeft);
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

        // public void Run(string temp, byte[,] matrix, int userMoves, string[,] topFive)
        // {
        //     while (temp != "EXIT")
        //     {
        //         Console.WriteLine(GlobalGameMessages.AskingToEnterRowAndColumnMessage);
        //         temp = Console.ReadLine();
        //         temp = temp.ToUpper().Trim();
        // 
        //         switch (temp)
        //         {
        //             case "RESTART":
        //                 ConsoleUI.PrintingMatrixOnConsole(matrix);
        //                 userMoves = 0;
        //                 break;
        // 
        //             case "TOP":
        //                 Chart.SortAndPrintChartFive(userMoves);
        //                 break;
        // 
        //             default:
        //                 if ((temp.Length == 3) &&
        //                     (temp[0] >= '0' && temp[0] <= '9') &&
        //                     (temp[2] >= '0' && temp[2] <= '9') &&
        //                     (temp[1] == ' ' || temp[1] == '.' || temp[1] == ','))
        //                 {
        //                     int userRow, userColumn;
        //                     userRow = int.Parse(temp[0].ToString());
        // 
        //                     if (userRow > 4)
        //                     {
        //                         Console.WriteLine(GlobalGameMessages.WrongInputMessage);
        //                         continue;
        //                     }
        // 
        //                     userColumn = int.Parse(temp[2].ToString());
        // 
        //                     if (Matrix.ChangeMatrix(matrix, userRow, userColumn))
        //                     {
        //                         Console.WriteLine(GlobalGameMessages.TryingToPopMissingBalloonMessage);
        //                         continue;
        //                     }
        // 
        //                     userMoves++;
        // 
        //                     if (Winner.CheckIfWinner(matrix))
        //                     {
        //                         Console.WriteLine(GlobalGameMessages.InTopFiveWinningMessage, userMoves);
        //                         Chart.SortAndPrintChartFive(userMoves);
        // 
        //                         matrix = Generator.GenerateBalloons(5, 10);
        //                         userMoves = 0;
        //                     }
        // 
        //                     ConsoleUI.PrintingMatrixOnConsole(matrix);
        //                     break;
        //                 }
        //                 else
        //                 {
        //                     Console.WriteLine(GlobalGameMessages.WrongInputMessage);
        //                     break;
        //                 }
        //         }
        //     }
        // 
        //     return;
        // }
    }
}
