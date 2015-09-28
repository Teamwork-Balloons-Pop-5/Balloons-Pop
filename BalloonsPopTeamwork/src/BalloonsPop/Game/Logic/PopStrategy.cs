namespace BalloonsPop.Game.Logic
{
    using BalloonsPop.Console.ConsoleUI.Playfield;

    public abstract class PopStrategy
    {
        public abstract int PopBaloons(int row, int col, Playfield playfield);
    }
}
