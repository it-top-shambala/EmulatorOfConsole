namespace Emulator.App;

public static class File
{
    public static string GetCurrentDirectory()
    {
        return Directory.GetCurrentDirectory();
    }

    public static bool ChangeCurrentDirtectory(string? path)
    {
        if (path.Contains('/')) //TODO NEED FIXING
        {
            path.Replace("/",@"\");
        }
        //convert to path
        string fullpath = $@"c:\{path}";
       
        if (path is null)
        {
            CLI.PrintToConsole("path is cant be null!",ConsoleColor.Red);
            return false;
        }
        if (fullpath.Equals(GetCurrentDirectory()))
        {
            CLI.PrintToConsole("Path cant be same!",ConsoleColor.Red);
            return false;
        }
        Directory.SetCurrentDirectory(fullpath);
        return true;
    }
    
    public static void CreateTextFile(string? FileName)
    {
        if (FileName is null)
        {
            CLI.PrintToConsole("Filename is cant be null",ConsoleColor.Red);
            return;
        }
        System.IO.File.Create($@"{GetCurrentDirectory()}\{FileName}");
    }
    
    public static bool MoveTo(string? command,bool overwrite)
    {
        if (command is null)
        {
            CLI.PrintToConsole("Cant be null",ConsoleColor.Red);
            return false;
        }
        var operations = StringOperations.ParseMoveToCommand(command);
        string file_path1 = $@"{GetCurrentDirectory()}\{operations.Item1}";
        string file_path2 = $@"{GetCurrentDirectory()}\{operations.Item2}";
        if (!System.IO.File.Exists(file_path1))
        {
            CLI.PrintToConsole("there no file named this!!! try another one!",ConsoleColor.Red);
            return false;
        }

        if (overwrite && !System.IO.File.Exists(file_path2))
        {
            CLI.PrintToConsole("there no file named this!!! try another one!",ConsoleColor.Red);
            return false;
        }
        System.IO.File.Copy(file_path1,file_path2,overwrite:overwrite);
        return true;
    }
}