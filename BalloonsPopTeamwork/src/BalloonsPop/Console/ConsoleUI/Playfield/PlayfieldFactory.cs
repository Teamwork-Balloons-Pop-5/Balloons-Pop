// <copyright  file="PlayfieldFactory.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Console.ConsoleUI.Playfield
{
    /// <summary>
    ///     Abstract class for Playfield factory
    /// </summary>
    public abstract class PlayfieldFactory
    {
        /// <summary>
        /// Creates the playfield matrix with the balloons in it
        /// </summary>
        public abstract Playfield CreatePlayfield();
    }
}
