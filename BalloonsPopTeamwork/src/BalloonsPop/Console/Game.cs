﻿namespace BalloonsPop.Console
{
    using BalloonsPop.Console.ConsoleIO.Printer;
    using BalloonsPop.Console.ConsoleIO.Printer.Contracts;
    using BalloonsPop.Console.ConsoleIO.Reader;
    using BalloonsPop.Console.ConsoleIO.Reader.Contracts;
    using BalloonsPop.Console.ConsoleUI.Colors;
    using BalloonsPop.Console.ConsoleUI.Playfield;
    using BalloonsPop.Engine.Contracts;
    using BalloonsPop.Engine;
    using BalloonsPop.Game.Logic;
    using Wintellect.PowerCollections;

    // Facade
    public class Game
    {
        private IEngine engine;
        private Playfield playfield;
        private IPopStrategy popLogic;

        private int balloonsLeft;
        private int userMoves;

        private IPrinter menuPrinter = new MenuPrinter();
        private IPrinter playfieldPrinter = new PlayfieldPrinter();
        private BalloonColor colors = new BalloonColor();
        private IPrinter messagePrinter = new MessagePrinter();
        private IPrinter scoreboardPrinter = new ScoreboardPrinter();
        private IReader reader = new Reader();
        private OrderedMultiDictionary<int, string> statistics = new OrderedMultiDictionary<int, string>(true);

        public Game()
        {

        }

        public void Start()
        {
            this.engine = new Engine();
        }
    }
}
