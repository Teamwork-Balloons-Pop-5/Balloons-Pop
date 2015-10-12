namespace BalloonsPop.Game.Commands
{
    using BalloonsPop.Game.Commands.Contracts;

    public abstract class Command : ICommand
    {
        public abstract void Execute();
    }
}
