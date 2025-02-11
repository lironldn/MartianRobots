namespace MartianRobots;

public class FileParser : IParser, IDisposable
{
    private StreamReader? File;
    public FileParser(string path)
    {
        File = new StreamReader(path);
    }

    public void Dispose()
    {
        if (File != null)
        {
            File.Dispose();
            File = null;
        }
    }

    public string? ReadLine() => File?.ReadLine();
}
