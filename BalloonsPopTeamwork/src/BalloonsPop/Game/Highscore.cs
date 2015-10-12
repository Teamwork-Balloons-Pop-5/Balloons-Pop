// <copyright  file="Highscore.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Game
{
    using System;
    using BalloonsPop.Common;
    using BalloonsPop.Common.Exceptions;

    /// <summary>
    /// creates instance of the scoreboard
    /// </summary>
    public class Highscore : IComparable<Highscore>
    {
        /// <summary>
        /// This field holds the points (spent moves from the user)
        /// </summary>
        private int value;

        /// <summary>
        /// This field holds the username
        /// </summary>
        private string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Highscore" /> class.
        /// </summary>
        public Highscore()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Highscore" /> class.
        /// </summary>
        /// /// <param name="name">string that holds the username</param>
        /// <param name="value">An integer that holds the points (spent moves from the user)</param>
        public Highscore(string name, int value)
        {
            this.Value = value;
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets the points;
        /// </summary>
        public int Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (Validator.IsPositiveInteger(value))
                {
                    throw new NotPositiveIntegerException(string.Format(BalloonsPop.Common.Constants.GlobalErrorMessages.MustBeAPositiveInteger, "HighScore.Value"));
                }

                this.value = value;
            }
        }

        /// <summary>
        /// Gets or sets the username;
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (Validator.IsStringLenghtValid(value, Common.Constants.GlobalGameLogicDependencesValues.MinUsernameLength, Common.Constants.GlobalGameLogicDependencesValues.MaxUsernameLength))
                {
                   throw new NotValidLenghtStringException(string.Format(BalloonsPop.Common.Constants.GlobalErrorMessages.StringMustBeOfLenght, Common.Constants.GlobalGameLogicDependencesValues.MinUsernameLength, Common.Constants.GlobalGameLogicDependencesValues.MaxUsernameLength));
                }

                this.name = value;               
            }
        }

        /// <summary>
        /// Compares two highscores
        /// </summary>
        /// <param name="other">takes highscore to compare to</param>
        public int CompareTo(Highscore other)
        {
            return this.Value.CompareTo(other.Value);
        }

        /// <summary>
        /// stringifies a highscore
        /// </summary>
        public override string ToString()
        {
            return this.Name + "-" + this.Value.ToString();
        }
    }
}
