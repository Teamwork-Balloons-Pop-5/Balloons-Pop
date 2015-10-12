// <copyright  file="LargePlayfieldCreator.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Console.ConsoleUI.Playfield
{
    /// <summary>
    /// creates the large matrix playfield, where the balloons are stored for the game
    /// </summary>
    public class LargePlayfieldCreator : PlayfieldFactory
    {
        /// <summary>
        /// The constant holds the height of the playfield matrix
        /// </summary>
        private const int Height = 10;

        /// <summary>
        /// The constant holds the width of the playfield matrix
        /// </summary>
        private const int Width = 10;

        /// <summary>
        /// Creates the playfield matrix with the balloons in it
        /// </summary>
        public override Playfield CreatePlayfield()
        {
            var largePlayfield = new Playfield(Width, Height);
            return largePlayfield;
        }
    }
}
