namespace BalloonsPop.Console.ConsoleIO.Printer
{
    using System;
    using System.Collections;
    using System.Text;
    using BalloonsPop.Console.ConsoleIO.Printer.Contracts;
    using BalloonsPop.Console.ConsoleUI.Colors;
    using BalloonsPop.Console.ConsoleUI.Playfield;
    using Wintellect.PowerCollections;

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