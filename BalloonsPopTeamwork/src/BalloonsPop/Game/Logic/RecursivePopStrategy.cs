namespace BalloonsPop.Game.Logic
{
    using BalloonsPop.Console.ConsoleUI.Playfield;

    public class RecursivePopStrategy : IPopStrategy
    {
        public int PopBaloons(int row, int col, Playfield playfield)
        {
            bool isRowValid = row >= 0 && row < playfield.Height;
            bool isColValid = col >= 0 && col < playfield.Width;

            if (isRowValid && isColValid)
            {
                string selectedCellValue = playfield.Field[row, col];

                if (selectedCellValue == "0")
                {
                    return 0;
                }
                else
                {
                    return this.PopBaloons(row, col, playfield, selectedCellValue);
                }
            }

            return 0;
        }

        private int PopBaloons(int row, int col, Playfield playfield, string selectedCellValue = null)
        {
            int poppedBaloons = 0;
            bool isRowValid = row >= 0 && row < playfield.Height;
            bool isColValid = col >= 0 && col < playfield.Width;

            if (isRowValid && isColValid)
            {
                if (playfield.Field[row, col] == selectedCellValue)
                {
                    // Pop current cell
                    playfield.Field[row, col] = "0";
                    poppedBaloons += 1;

                    // Up
                    poppedBaloons += this.PopBaloons(row - 1, col, playfield, selectedCellValue);

                    // Down
                    poppedBaloons += this.PopBaloons(row + 1, col, playfield, selectedCellValue);

                    // Left
                    poppedBaloons += this.PopBaloons(row, col + 1, playfield, selectedCellValue);

                    // Right
                    poppedBaloons += this.PopBaloons(row, col - 1, playfield, selectedCellValue);
                }
            }

            return poppedBaloons;
        }
    }
}
