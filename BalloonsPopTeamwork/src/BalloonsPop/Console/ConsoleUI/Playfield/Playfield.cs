// <copyright  file="Playfield.cs" company="Balloons-Pop-5">
// All rights reserved.
// </copyright>
// <author>DimitarSD, alexizvely, fr0wsTyl</author>

namespace BalloonsPop.Console.ConsoleUI.Playfield
{
    using System;   
    using BalloonsPop.Common;
    using BalloonsPop.Common.Exceptions;
    using BalloonsPop.Common.Generator;

    /// <summary>
    /// creates the regular matrix playfield, where the balloons are stored for the game
    /// </summary>
    public class Playfield
    {
        /// <summary>
        /// The constant holds the height of the playfield matrix
        /// </summary>
        public const int InitialHeight = 10;
        /// <summary>
        /// The constant holds the width of the playfield matrix
        /// </summary>
        public const int InitialWidth = 5;

        /// <summary>
        /// This field holds the height of the playfield matrix
        /// </summary>
        private int height;
        /// <summary>
        /// This field holds the width of the playfield matrix
        /// </summary>
        private int width;

        /// <summary>
        /// This string array holds the balloons in the game
        /// </summary>
        private string[,] field;

        /// <summary>
        /// Initializes a new instance of the <see cref="Playfield" /> class.
        /// </summary>
        public Playfield()
        {
            this.Height = Playfield.InitialHeight;
            this.Width = Playfield.InitialWidth;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Playfield" /> class.
        /// </summary>
        /// <param name="height">An integer that holds the height of the playfield matrix</param>
        /// <param name="width">An integer that holds the width of the playfield matrix</param>
        public Playfield(int height, int width)
        {
            this.Height = height;
            this.Width = width;

            this.Field = new string[this.height, this.width];

            this.InitializePlayfield();
        }

        /// <summary>
        /// Gets or sets the height;
        /// </summary>
        public int Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (Validator.IsPositiveInteger(value))
                {
                    throw new NotPositiveIntegerException(string.Format(BalloonsPop.Common.Constants.GlobalErrorMessages.MustBeAPositiveInteger, "Playfield.Height"));
                }

                this.height = value;
            }
        }

        /// <summary>
        /// Gets or sets the width;
        /// </summary>
        public int Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (Validator.IsPositiveInteger(value))
                {
                    throw new NotPositiveIntegerException(string.Format(BalloonsPop.Common.Constants.GlobalErrorMessages.MustBeAPositiveInteger, "Playfield.Width"));
                }

                this.width = value;
            }
        }

        /// <summary>
        /// Gets or sets the playfield;
        /// </summary>
        public string[,] Field
        {
            get
            {
                return this.field;
            }

            private set
            {
                this.field = value;
            }
        }

        /// <summary>
        /// Creates the playfield matrix with the balloons in it
        /// </summary>
        private void InitializePlayfield()
        {
            for (int row = 0; row < this.Height; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    string digit = RandomGenerator.GetRandomInt();

                    this.Field[row, col] = digit;
                }
            }
        }
    }
}
