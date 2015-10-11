namespace BalloonsPop.Console.ConsoleUI.Playfield
{
    public class SmallPlayfieldCreator : PlayfieldFactory
    {
        private const int Width = 4;
        private const int Height = 4;

        public override Playfield CreatePlayfield()
        {
            var smallPlayfield = new Playfield(Width, Height);
            return smallPlayfield;
        }
    }
}
