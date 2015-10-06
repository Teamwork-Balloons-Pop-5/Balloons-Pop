namespace BalloonsPop.Common.Exceptions
{
    using System;

    public class NotValidLenghtStringException : Exception
    {
        public NotValidLenghtStringException(string message)
            :base(message)
        {
            
        }
    }

    public class CannotBeNullException : Exception
    {
        public CannotBeNullException(string message)
            : base(message)
        {

        }
    }

    public class NotPositiveIntegerException : Exception
    {
        public NotPositiveIntegerException(string message)
            : base(message)
        {

        }
    }

    public class IntNotEqualOrGreaterThan : Exception
    {
        public IntNotEqualOrGreaterThan(string message)
            : base(message)
        {

        }
    }
}
