// <copyright  file="BalloonColor.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Console.ConsoleUI.Colors
{
    using BalloonsPop.Common.Enum;
    using System;

    /// <summary>
    /// creates the BalloonColor holder for the balloons colours
    /// </summary>
    public class BalloonColor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Playfield" /> class.
        /// </summary>
        /// <param name="currentBalloon">string that holds the value of the current balloon. The value determines the colour of the balloon</param>
        public void PaintBalloon(string currentBalloon)
        {
            switch (currentBalloon)
            {
                case "1":
                    this.SetColor(ConsoleColor.Green, currentBalloon, ConsoleColor.White);
                    break;
                case "2":
                    this.SetColor(ConsoleColor.Blue, currentBalloon, ConsoleColor.White);
                    break;
                case "3":
                    this.SetColor(ConsoleColor.Red, currentBalloon, ConsoleColor.White);
                    break;
                case "4":
                    this.SetColor(ConsoleColor.Yellow, currentBalloon, ConsoleColor.White);
                    break;
            }
        }

        /// <summary>
        /// sets and prints the balloon colour
        /// </summary>
        private void SetColor(ConsoleColor balloonColor, string balloonDigit, ConsoleColor textColor)
        {
            Console.ForegroundColor = balloonColor;
            Console.Write(balloonDigit + " ");
            Console.ForegroundColor = textColor;
        }
    }
}
