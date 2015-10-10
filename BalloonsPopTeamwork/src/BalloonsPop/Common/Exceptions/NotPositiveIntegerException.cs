namespace BalloonsPop.Common.Exceptions
{
    using System;

    public class NotPositiveIntegerException : Exception
    {
        public NotPositiveIntegerException(string message)
            : base(message)
        {
        }
    }
}
