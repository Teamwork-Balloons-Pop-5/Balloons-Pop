namespace BalloonsPop.Common.Exceptions
{
    using System;

    public class NotValidLenghtStringException : Exception
    {
        public NotValidLenghtStringException(string message) : base(message)
        {
        }
    }
}