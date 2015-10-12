namespace BalloonsPop.Game.Logic
{
    using BalloonsPop.Console.ConsoleUI.Playfield;

    public interface IPopStrategy
    {
        int PopBaloons(int row, int col, Playfield playfield);
    }
}