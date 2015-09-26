namespace BalloonsPop.GameLogic
{
    using System;

    using Common.Constants;
    using BalloonsPop.Console.ConsoleUI;

    public class Command
    {
        public static void ReadCommands(string temp, byte[,] matrix, int userMoves, string[,] topFive)
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
                        Chart.SortAndPrintChartFive(topFive);
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
                                if (topFive.SignIfSkilled(userMoves))
                                {
                                    Chart.SortAndPrintChartFive(topFive);
                                }
                                else
                                {
                                    Console.WriteLine(GlobalGameMessages.NotInTopFiveWinningMessage);
                                }

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
