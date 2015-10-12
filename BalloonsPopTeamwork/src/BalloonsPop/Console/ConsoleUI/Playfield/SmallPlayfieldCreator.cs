// <copyright  file="SmallPlayfieldCreator.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Console.ConsoleUI.Playfield
{
    /// <summary>
    /// creates the small matrix playfield, where the balloons are stored for the game
    /// </summary>
    public class SmallPlayfieldCreator : PlayfieldFactory
    {
        /// <summary>
        /// The constant holds the height of the playfield matrix
        /// </summary>
        private const int Height = 4;
        /// <summary>
        /// The constant holds the width of the playfield matrix
        /// </summary>
        private const int Width = 4;

        /// <summary>
        /// Creates the playfield matrix with the balloons in it
        /// </summary>
        public override Playfield CreatePlayfield()
        {
            var smallPlayfield = new Playfield(Width, Height);
            return smallPlayfield;
        }
    }
}
