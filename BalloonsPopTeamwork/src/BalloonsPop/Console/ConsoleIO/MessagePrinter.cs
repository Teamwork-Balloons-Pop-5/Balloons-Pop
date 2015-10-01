namespace BalloonsPop.Console.ConsoleIO
{
    using System;

    public class MessagePrinter
    {
        public MessagePrinter()
        {
        }

        public void Print(string message)
        {
            Console.Write(message);
        }

        public void PrintLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
