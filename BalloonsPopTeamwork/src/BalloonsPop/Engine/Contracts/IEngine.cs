namespace BalloonsPop.Engine.Contracts
{
    using BalloonsPop.Console.ConsoleIO.Printer.Contracts;
    using BalloonsPop.Console.ConsoleUI.Colors;
    using BalloonsPop.Console.ConsoleUI.Playfield;
    using BalloonsPop.Game.Logic;

    public interface IEngine
    {
        void Run(Playfield playfield, IPopStrategy gamePopLogic, BalloonColor colors, IPrinter menuPrinter, IPrinter playfieldPrinter);
    }
}
