namespace BalloonsPop.Console.ConsoleUI.Playfield
{
    public class LargePlayfieldFactory : PlayfieldFactory
    {
        private const int Width = 10;
        private const int Height = 10;

        public override Playfield CreatePlayfield()
        {
            return new Playfield(Width, Height);
        }
    }
}
