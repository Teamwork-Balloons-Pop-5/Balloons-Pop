namespace BalloonsPop.Game
{
    using System;
    using BalloonsPop.Common;
    using BalloonsPop.Common.Exceptions;

    public class Score
    {
        private int points;
        private string name;

        public Score(string name, int points)
        {
            this.Name = name;
            this.Points = points;
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
        public int Points 
        {
            get
            {
                return this.points;
            }

            set
            {
                if (Validator.IsPositiveInteger(value))
                {
                    throw new NotPositiveIntegerException(string.Format(BalloonsPop.Common.Constants.GlobalErrorMessages.MustBeAPositiveInteger, "HighScore.Value"));
                }
                this.points = value;
            }
        }
        
        public string ToString()
        {
            return this.Name + "-" + this.Points.ToString();
        }

    }
}
