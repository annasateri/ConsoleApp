namespace ConsoleApp.Services;
public static class FileService
{
    public static void Save(string filePath, string content)
    {
        using var sw = new StreamWriter(filePath);
        sw.WriteLine(content);
    }

    public static string Read(string filePath)
    {
        try
        {
            using var sr = new StreamReader(filePath);
            return sr.ReadToEnd();
        }
        catch
        { 
            return null!;
        }
    }
}