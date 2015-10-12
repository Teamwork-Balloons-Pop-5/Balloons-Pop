// <copyright  file="Printer.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Console.ConsoleIO.Printer
{
    using BalloonsPop.Console.ConsoleIO.Printer.Contracts;

    /// <summary>
    /// abstraction for the game Printer
    /// </summary>
    public abstract class Printer : IPrinter
    {
        /// <summary>
        /// Prints text on the same line
        /// </summary>
        /// <param name="text">takes a string and prints it on the same line</param>
        public abstract void PrintText(string text);

        /// <summary>
        /// Prints a line
        /// </summary>
        /// <param name="text">takes a string and prints it on a separate line</param>
        public abstract void PrintTextLine(string text);

        /// <summary>
        /// Prints an object array
        /// </summary>
        /// <param name="objs">takes object array and prints it</param>
        public abstract void Print(params object[] objs);
    }
}
