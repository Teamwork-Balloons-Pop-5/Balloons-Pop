namespace BalloonsPop.Console.ConsoleIO.Printer
{
    using System;

    using BalloonsPop.Console.ConsoleIO.Printer.Contracts;
    using System.Collections;
    using BalloonsPop.Console.ConsoleUI.Playfield;
    using System.Text;
    using Wintellect.PowerCollections;
    using BalloonsPop.Console.ConsoleUI.Colors;

    public class MessagePrinter : IPrinter
    {
        // Finished
        public void PrintText(string text)
        {
            Console.Write(text);
        }

        // Finished
        public void PrintTextLine(string text)
        {
            Console.WriteLine(text);
        }

        // Finished
        public void Print(params object[] objs)
        {
            string message = objs[0] as string;
            this.PrintTextLine(message);
        }
    }
}