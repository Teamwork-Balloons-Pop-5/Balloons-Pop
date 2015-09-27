namespace BalloonsPop.Console.ConsoleIO
{
    using System;

    public static class MessagePrinter
    {
        public static void Print(string message)
        {
            Console.Write(message);
        }

        public static void PrintLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
