// <copyright  file="IPopStrategy.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Game.Logic
{
    using BalloonsPop.Console.ConsoleUI.Playfield;

    /// <summary>
    /// interface for PopStrategy
    /// </summary>
    public interface IPopStrategy
    {
        /// <summary>
        /// count of balloons
        /// </summary>
        /// <param name="row">int for cell position</param>
        /// <param name="col">int for cell position</param>
        /// <param name="playfield">object that contains the playfield matrics form type Playfield</param>
        /// <returns></returns>
        int PopBaloons(int row, int col, Playfield playfield);
    }
}