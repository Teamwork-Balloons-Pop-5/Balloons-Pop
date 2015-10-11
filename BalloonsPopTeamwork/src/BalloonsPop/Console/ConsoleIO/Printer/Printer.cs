namespace BalloonsPop.Console.ConsoleIO.Printer
{
    using BalloonsPop.Console.ConsoleIO.Printer.Contracts;

    public abstract class Printer : IPrinter
    {
        // Finished
        public abstract void PrintText(string text);

        // Finished
        public abstract void PrintTextLine(string text);

        // Finished
        public abstract void Print(params object[] objs);
    }
}
