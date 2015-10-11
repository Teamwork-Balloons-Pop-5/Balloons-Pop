namespace BalloonsPop.Console.ConsoleIO.Printer.Contracts
{
    using BalloonsPop.Console.ConsoleUI.Playfield;
    using System.Collections;
    using Wintellect.PowerCollections;

    public interface IPrinter
    {
        void Print(params object[] objs);
    }
}
