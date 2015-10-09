namespace BalloonsPop.Console.ConsoleUI.Playfield
{
    public class SmallPlayfieldFactory : PlayfieldFactory
    {
        private const int Width = 4;
        private const int Height = 4;

        public override Playfield CreatePlayfield()
        {
            return new Playfield(Width, Height);
        }
    }
}
