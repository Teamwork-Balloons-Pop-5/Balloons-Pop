namespace BalloonsPop.Console.ConsoleIO.Reader.Contracts
{
    public interface IReader
    {
        int ReadPlayfieldSize();

        string ReadUsername();

        string ReadUserInput();
    }
}
