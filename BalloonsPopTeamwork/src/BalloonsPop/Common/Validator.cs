namespace BalloonsPop.Common
{
    using System;

    public static class Validator
    {
        public static void ValidateIsNotNull(object argument, string argumentName = Constants.GlobalErrorMessages.ArgumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName, string.Format(Constants.GlobalErrorMessages.CannotBeNullFormat, argumentName));
            }
        }

        public static void ValidateIsPositiveInteger(int argument, string paramName)
        {
            if (argument <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, paramName + Constants.GlobalErrorMessages.MustBeAPositiveInteger);
            }
        }

        public static void ValidateIsEqualOrGreaterThan(int argument, int number, string paramName)
        {
            if (argument < number)
            {
                throw new ArgumentOutOfRangeException(paramName, string.Format(Constants.GlobalErrorMessages.MustBeEqualOrGreaterThanFormat, paramName, number));
            }
        }
    }
}
