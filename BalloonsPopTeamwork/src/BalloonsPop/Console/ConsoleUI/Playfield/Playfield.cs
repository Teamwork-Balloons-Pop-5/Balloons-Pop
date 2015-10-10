namespace BalloonsPop.Console.ConsoleUI.Playfield
{
    using System;   
    using BalloonsPop.Common;
    using BalloonsPop.Common.Exceptions;
    using BalloonsPop.Common.Generator;

    public class Playfield
    {
        public const int InitialHeight = 10;
        public const int InitialWidth = 5;

        private int height;
        private int width;

        private string[,] field;

        public Playfield()
        {
            this.Height = Playfield.InitialHeight;
            this.Width = Playfield.InitialWidth;
        }

        // TODO: check if needed!
        /*public Playfield(int height)
        {
            this.Height = height;
            this.Width = Playfield.InitialWidth;
        }

        public Playfield(int width)
        {
            this.Height = Playfield.InitialHeight;
            this.Width = width;
        }
        */
        public Playfield(int height, int width)
        {
            this.Height = height;
            this.Width = width;

            this.Field = new string[this.height, this.width];

            this.InitializePlayfield();
        }

        public int Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                // if(Validator.IsNull(value))
                // {
                //     throw new CannotBeNullException(string.Format(BalloonsPop.Common.Constants.GlobalErrorMessages.CannotBeNullFormat, "Playfield.Height"));
                // }
                if (Validator.IsPositiveInteger(value))
                {
                    throw new NotPositiveIntegerException(string.Format(BalloonsPop.Common.Constants.GlobalErrorMessages.MustBeAPositiveInteger, "Playfield.Height"));
                }

                this.height = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                // if (Validator.IsNull(value))
                // {
                //     throw new CannotBeNullException(string.Format(BalloonsPop.Common.Constants.GlobalErrorMessages.CannotBeNullFormat, "Playfield.Width"));
                // }
                if (Validator.IsPositiveInteger(value))
                {
                    throw new NotPositiveIntegerException(string.Format(BalloonsPop.Common.Constants.GlobalErrorMessages.MustBeAPositiveInteger, "Playfield.Width"));
                }

                this.width = value;
            }
        }

        public string[,] Field
        {
            get
            {
                return this.field;
            }

            private set
            {
                // if (Validator.IsNull(value))
                // {
                //     throw new CannotBeNullException(string.Format(BalloonsPop.Common.Constants.GlobalErrorMessages.CannotBeNullFormat, "Playfield"));
                // }
                this.field = value;
            }
        }

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
