// <copyright  file="IEngine.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Engine.Contracts
{
    using BalloonsPop.Console.ConsoleIO.Printer.Contracts;
    using BalloonsPop.Console.ConsoleUI.Colors;
    using BalloonsPop.Console.ConsoleUI.Playfield;
    using BalloonsPop.Game.Logic;

    /// <summary>
    /// interface for the game engine
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// starts the game
        /// </summary>
        void Run(Playfield playfield, IPopStrategy gamePopLogic, BalloonColor colors, IPrinter menuPrinter, IPrinter playfieldPrinter);
    }
}
