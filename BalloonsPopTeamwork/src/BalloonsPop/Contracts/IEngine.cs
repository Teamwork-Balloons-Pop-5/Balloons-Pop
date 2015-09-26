﻿namespace BalloonsPop.Contracts
{
    public interface IEngine
    {
        void Run(string temp, byte[,] matrix, int userMoves, string[,] topFive);
    }
}
