namespace BalloonsPop.Common
{
    using System;
    using BalloonsPop.Common.Exceptions;

    public static class Validator
    {
        public static bool IsNull(object argument)
        {
            if (argument == null)
            {
                return false;
            }

            return true;
        }

        public static bool IsPositiveInteger(int argument)
        {
            if (argument <= 0)
            {
                return true;
            }

            return false;
        }

        public static bool ValidateIntIsEqualOrGreaterThan(int argument, int number)
        {
            if (argument < number)
            {
                return false;
            }

            return true;
        }

        public static bool IsStringLenghtValid(string argument, int minLenght, int maxLenght)
        {
            if (argument.Length >= minLenght && argument.Length <= maxLenght)
            {
                return true;
            }

            return false;
        }
    }
}
