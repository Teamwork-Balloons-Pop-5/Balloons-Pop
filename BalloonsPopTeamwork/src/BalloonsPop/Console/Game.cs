// <copyright  file="Game.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Console
{
    using BalloonsPop.Console.ConsoleIO.Printer;
    using BalloonsPop.Console.ConsoleIO.Printer.Contracts;
    using BalloonsPop.Console.ConsoleIO.Reader;
    using BalloonsPop.Console.ConsoleIO.Reader.Contracts;
    using BalloonsPop.Console.ConsoleUI.Colors;
    using BalloonsPop.Console.ConsoleUI.Playfield;
    using BalloonsPop.Engine;
    using BalloonsPop.Engine.Contracts;
    using BalloonsPop.Game.Logic;
    using Wintellect.PowerCollections;

    /// <summary>
    /// The facade for the game
    /// </summary>
    public class Game
    {     
        private IEngine engine;
        private Playfield playfield;
        private IPopStrategy gamePopLogic;
        private int balloonsLeft;
        private int userMoves;
        private IPrinter menuPrinter;
        private IPrinter playfieldPrinter;
        private BalloonColor colors;
        private IPrinter messagePrinter;
        private IPrinter scoreboardPrinter;
        private IReader reader;
        private OrderedMultiDictionary<int, string> statistics;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game" /> class.
        /// </summary>
        public Game()
        {
            this.engine = new Engine();
            this.menuPrinter = new MenuPrinter();
            this.playfieldPrinter = new PlayfieldPrinter();
            this.messagePrinter = new MessagePrinter();
            this.scoreboardPrinter = new ScoreboardPrinter();
            this.reader = new Reader();
            this.colors = new BalloonColor();
            this.statistics = new OrderedMultiDictionary<int, string>(true);
        }

        /// <summary>
        /// Starts the game
        /// </summary>
        public void Start()
        {
            this.engine.Run(this.playfield, this.gamePopLogic, this.colors, this.menuPrinter, this.playfieldPrinter);
        }
    }
}
