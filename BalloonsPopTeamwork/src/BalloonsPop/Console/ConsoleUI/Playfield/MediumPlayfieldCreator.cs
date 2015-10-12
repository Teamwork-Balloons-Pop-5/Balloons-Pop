namespace BalloonsPop.Console.ConsoleUI.Playfield
{
    public class MediumPlayfieldCreator : PlayfieldFactory
    {
        private const int Width = 7;
        private const int Height = 7;

        // Finished
        public override Playfield CreatePlayfield()
        {
            var mediumPlayfield = new Playfield(Width, Height);
            return mediumPlayfield;
        }
    }
}
