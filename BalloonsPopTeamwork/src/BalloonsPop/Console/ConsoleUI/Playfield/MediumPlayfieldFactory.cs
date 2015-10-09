namespace BalloonsPop.Console.ConsoleUI.Playfield
{
    public class MediumPlayfieldFactory : PlayfieldFactory
    {
        private const int Width = 7;
        private const int Height = 7;

        public override Playfield CreatePlayfield()
        {
            return new Playfield(Width, Height);
        }
    }
}
