namespace Emulator.App;

public static class File
{
    public static string GetCurrentDirectory()
    {
        return Directory.GetCurrentDirectory();
    }

    public static void ChangeCurrentDirtectory(string? path)
    {
        //convert to path
        string fullpath = $@"c:\{path}";
        if (path is null)
        {
            throw new NullReferenceException("Path cant be null");
        }
        Directory.SetCurrentDirectory(fullpath);
    }
    
    public static void CreateTextFile(string? FileName)
    {
        if (FileName is null) throw new NullReferenceException();
        System.IO.File.Create($@"{GetCurrentDirectory()}\{FileName}");
    }
}