namespace BalloonsPop.Game.Logic
{
    using System;

    using BalloonsPop.Console.ConsoleUI.Playfield;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Console.ConsoleUI;

    public class MovingPopStrategy : IPopStrategy
    {
        public int PopBaloons(int row, int col, Playfield playfield)
        {
            int userMoves = 0;

            while (true)
            {
                Console.Write("Enter row and col: ");
                string input = Console.ReadLine();
                input = input.ToUpper().Trim();

                if ((input.Length == 3) &&
                            (input[0] >= '0' && input[0] <= '9') &&
                            (input[2] >= '0' && input[2] <= '9') &&
                            (input[1] == ' ' || input[1] == '.' || input[1] == ','))
                {
                    int userRow = int.Parse(input[0].ToString());
                    int userColumn = int.Parse(input[2].ToString());

                    if (userRow > playfield.Height)
                    {
                        Console.WriteLine(GlobalGameMessages.WrongInputMessage);
                        continue;
                    }

                    if (Matrix.ChangeMatrix(playfield, userRow, userColumn))
                    {
                        Console.WriteLine(GlobalGameMessages.TryingToPopMissingBalloonMessage);
                        continue;
                    }


                    if (Winner.CheckIfWinner(playfield))
                    {
                        Console.WriteLine(GlobalGameMessages.InTopFiveWinningMessage, userMoves);
                        Chart.SortAndPrintChartFive(userMoves);
                    
                        playfield = Generator.GenerateBalloons(5, 10);

                    }
                    ConsoleUI.PrintingMatrixOnConsole(playfield);
                }
            }
        }
    }
}
