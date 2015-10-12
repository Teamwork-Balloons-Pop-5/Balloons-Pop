// <copyright  file="MediumPlayfieldCreator.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Console.ConsoleUI.Playfield
{
    /// <summary>
    /// creates the small matrix playfield, where the balloons are stored for the game
    /// </summary>
    public class MediumPlayfieldCreator : PlayfieldFactory
    {
        /// <summary>
        /// The constant holds the height of the playfield matrix
        /// </summary>
        private const int Height = 7;

        /// <summary>
        /// The constant holds the width of the playfield matrix
        /// </summary>
        private const int Width = 7;
        
        /// <summary>
        /// Creates the playfield matrix with the balloons in it
        /// </summary>
        // Finished
        public override Playfield CreatePlayfield()
        {
            var mediumPlayfield = new Playfield(Width, Height);
            return mediumPlayfield;
        }
    }
}
