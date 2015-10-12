// <copyright  file="StartPoint.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Console
{
    using System;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Engine;

    /// <summary>
    /// Balloons Pop-5 Start Point - A game is initialized with its components, ran in a loop and then terminated.
    /// </summary>
    public class StartPoint
    {
        /// <summary>
        /// Entry point for the Balloons Pop-5 game.
        /// </summary>
        public static void Main()
        {
            Game game = new Game();
            game.Start();
        }
    }
}