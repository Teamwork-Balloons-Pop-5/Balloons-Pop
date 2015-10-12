<<<<<<< HEAD
﻿// <copyright  file="IReader.cs" company="Balloons-Pop-5">
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
=======
﻿namespace BalloonsPop.Console.ConsoleIO.Reader.Contracts
{
    public interface IReader
    {
        int ReadPlayfieldSize();

        string ReadUsername();

>>>>>>> 8e628ea99bb0e0e8829ca0fd021a641b917ec1e8
        string ReadUserInput();
    }
}
