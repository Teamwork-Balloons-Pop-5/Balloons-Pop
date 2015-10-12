// <copyright  file="IReader.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Console.ConsoleIO.Reader.Contracts
{
    /// <summary>
    /// interface for the game Reader
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Reads the size of the playfield
        /// </summary>
        int ReadPlayfieldSize();

        /// <summary>
        /// Reads the username of the player
        /// </summary>
        string ReadUsername();

        /// <summary>
        /// Reads user input
        /// </summary>
        string ReadUserInput();
    }
}
