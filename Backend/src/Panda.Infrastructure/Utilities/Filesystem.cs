namespace Panda.Infrastructure.Utilities;
internal static class Filesystem
{
    public static string ReadFileAsText(string filePath)
    {
        string path = $"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}{filePath}";

        if (!File.Exists(path))
        {
            Console.WriteLine("Could not find file: " + path);
            return "";
        }

        return File.ReadAllText(path);
    }
}
