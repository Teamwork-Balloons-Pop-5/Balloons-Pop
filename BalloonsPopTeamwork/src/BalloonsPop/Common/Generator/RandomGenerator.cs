namespace BalloonsPop.Common.Generator
{
    using System;

    public static class RandomGenerator
    {
        private static Random randomSymbol = new Random();

        // Finished
        public static string GetRandomBalloonDigit()
        {
            string legalChars = "1234";
            int index = randomSymbol.Next(0, legalChars.Length);

            string balloonDigit = legalChars[index].ToString();

            return balloonDigit;
        }
    }
}
