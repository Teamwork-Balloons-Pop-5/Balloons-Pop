namespace BalloonsPop.Game
{
    using System;
    using BalloonsPop.Common;
    using BalloonsPop.Common.Exceptions;

    public class Highscore : IComparable<Highscore>
    {
        private int value;
        private string name;

        public Highscore(string name, int value)
        {
            this.Value = value;
            this.Name = name;
        }

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

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (Validator.IsStringLenghtValid(value, Common.Constants.GlobalGameLogicDependencesValues.MINUSERNAMELENGHT, Common.Constants.GlobalGameLogicDependencesValues.MAXUSERNAMELENGHT))
                {
                   throw new NotValidLenghtStringException(string.Format(BalloonsPop.Common.Constants.GlobalErrorMessages.StringMustBeOfLenght, Common.Constants.GlobalGameLogicDependencesValues.MINUSERNAMELENGHT, Common.Constants.GlobalGameLogicDependencesValues.MAXUSERNAMELENGHT));
                }

                this.name = value;               
            }
        }

        public int CompareTo(Highscore other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public string ToString()
        {
            return this.Name + "-" + this.Value.ToString();
        }
    }
}
