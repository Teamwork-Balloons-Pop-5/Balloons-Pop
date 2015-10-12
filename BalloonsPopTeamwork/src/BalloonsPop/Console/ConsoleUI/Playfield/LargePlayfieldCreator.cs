namespace BalloonsPop.Console.ConsoleUI.Playfield
{
    public class LargePlayfieldCreator : PlayfieldFactory
    {
        private const int Width = 10;
        private const int Height = 10;

        // Finished
        public override Playfield CreatePlayfield()
        {
            var largePlayfield = new Playfield(Width, Height);
            return largePlayfield;
        }
    }
}
