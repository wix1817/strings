using static System.Runtime.InteropServices.JavaScript.JSType;

namespace strings;

public class DataProvider
{
    private string Path;

    public string CheckPath(string path)
    {
        if (File.Exists(path))
        {
            try
            {
                Path = path;
                return Path;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        return "Error: FileNotExist";
    }

    public static string[] OutputOfExistingFiles()
    {
        string[] files = Directory.GetFiles(@"..\..\..\", "*.txt");

        return files;
    }

    public string GetData(string path)
    {
        try
        {
            return File.ReadAllText(CheckPath(path));
        }
        catch (Exception e)
        {
            return e.ToString();
        }
    }
}