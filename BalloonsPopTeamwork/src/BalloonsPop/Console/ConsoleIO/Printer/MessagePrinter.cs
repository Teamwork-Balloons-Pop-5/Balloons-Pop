// <copyright  file="MessagePrinter.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Console.ConsoleIO.Printer
{
    using System;
    using System.Collections;
    using System.Text;
    using BalloonsPop.Console.ConsoleIO.Printer.Contracts;
    using BalloonsPop.Console.ConsoleUI.Colors;
    using BalloonsPop.Console.ConsoleUI.Playfield;
    using Wintellect.PowerCollections;

    /// <summary>
    /// creates printer for the messages in the game
    /// </summary>
    public class MessagePrinter : IPrinter
    {
        /// <summary>
        /// Prints
        /// </summary>
        /// <param name="text">takes a string and prints it on the same line</param>
        public void PrintText(string text)
        {
            Console.Write(text);
        }

        /// <summary>
        /// Prints
        /// </summary>
        /// <param name="text">takes a string and prints it on a separate line</param>
        public void PrintTextLine(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Prints messages to the console
        /// </summary>
        /// <param name="objs">takes an object array and prints it</param>
        public void Print(params object[] objs)
        {
            string message = objs[0] as string;
            this.PrintTextLine(message);
        }
    }
}