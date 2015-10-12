namespace BalloonsPop.Common.Exceptions
{
    using System;

    public class IntNotEqualOrGreaterThan : Exception
    {
        public IntNotEqualOrGreaterThan(string message)
            : base(message)
        {
        }
    }
}
