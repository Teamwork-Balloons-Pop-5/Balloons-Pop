namespace BalloonsPop.Common.Exceptions
{
    using System;

    public class CannotBeNullException : Exception
    {
        public CannotBeNullException(string message)
            : base(message)
        {
        }
    }
}
