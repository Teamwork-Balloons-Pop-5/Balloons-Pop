// <copyright  file="IPrinter.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Console.ConsoleIO.Printer.Contracts
{
    using System.Collections;
    using BalloonsPop.Console.ConsoleUI.Playfield;
    using Wintellect.PowerCollections;

    /// <summary>
    /// interface for the game Printer
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// Prints
        /// </summary>
        /// <param name="objs">takes object array and prints it</param>
        void Print(params object[] objs);
    }
}
