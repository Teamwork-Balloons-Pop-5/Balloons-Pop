namespace BalloonsPop.Engine
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Engine.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Console.ConsoleUI;
    using BalloonsPop.Game;
    using BalloonsPop.Console.ConsoleUI.Playfield;
    using BalloonsPop.Game.Logic;
    using BalloonsPop.Console.ConsoleIO;

    public sealed class Engine : IEngine
    {
        private static Engine engineInstance;
        private Playfield playfield;
        private PopStrategy popLogic;
        private int balloonsLeft;
        private int userMoves;

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

        public void Start()
        {
            var playfield = this.InitializePlayfield();
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

        public void Run(string temp, byte[,] matrix, int userMoves, string[,] topFive)
        {
            while (temp != "EXIT")
            {
                Console.WriteLine(GlobalGameMessages.AskingToEnterRowAndColumnMessage);
                temp = Console.ReadLine();
                temp = temp.ToUpper().Trim();

                switch (temp)
                {
                    case "RESTART":
                        ConsoleUI.PrintingMatrixOnConsole(matrix);
                        userMoves = 0;
                        break;

                    case "TOP":
                        Chart.SortAndPrintChartFive(userMoves);
                        break;

                    default:
                        if ((temp.Length == 3) &&
                            (temp[0] >= '0' && temp[0] <= '9') &&
                            (temp[2] >= '0' && temp[2] <= '9') &&
                            (temp[1] == ' ' || temp[1] == '.' || temp[1] == ','))
                        {
                            int userRow, userColumn;
                            userRow = int.Parse(temp[0].ToString());

                            if (userRow > 4)
                            {
                                Console.WriteLine(GlobalGameMessages.WrongInputMessage);
                                continue;
                            }

                            userColumn = int.Parse(temp[2].ToString());

                            if (Matrix.ChangeMatrix(matrix, userRow, userColumn))
                            {
                                Console.WriteLine(GlobalGameMessages.TryingToPopMissingBalloonMessage);
                                continue;
                            }

                            userMoves++;

                            if (Winner.CheckIfWinner(matrix))
                            {
                                Console.WriteLine(GlobalGameMessages.InTopFiveWinningMessage, userMoves);
                                Chart.SortAndPrintChartFive(userMoves);

                                matrix = Generator.GenerateBalloons(5, 10);
                                userMoves = 0;
                            }

                            ConsoleUI.PrintingMatrixOnConsole(matrix);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(GlobalGameMessages.WrongInputMessage);
                            break;
                        }
                }
            }

            return;
        }
    }
}
