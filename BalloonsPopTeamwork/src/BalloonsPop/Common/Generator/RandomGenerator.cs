// <copyright  file="RandomGenerator.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Common.Generator
{
    using System;

    /// <summary>
    /// creates instance that generates the balloon numbers
    /// </summary>
    public static class RandomGenerator
    {
        /// <summary>
        /// this field contains the rand
        /// </summary>
        private static Random randomSymbol = new Random();

        /// <summary>
        /// generates the balloon numbers
        /// </summary>
        /// <returns></returns>
        public static string GetRandomBalloonDigit()
        {
            string legalChars = "1234";
            int index = randomSymbol.Next(0, legalChars.Length);

            string balloonDigit = legalChars[index].ToString();

            return balloonDigit;
        }
    }
}
