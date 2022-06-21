using System.Text;

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
        string current_path = $@"{GetCurrentDirectory()}\{path}";
        if (Directory.Exists(current_path))
        {
            fullpath = current_path;
        }
        
        if (path is null)
        {
            CLI.ShowError("path is cant be null!");
            return false;
        }
        if (fullpath.Equals(GetCurrentDirectory()))
        {
            CLI.ShowError("Path cant be same!");
            return false;
        }
        Directory.SetCurrentDirectory(fullpath);
        return true;
    }
    
    public static void CreateTextFile(string? FileName)
    {
        if (FileName is null)
        {
            CLI.ShowError("Filename is cant be null");
            return;
        }
        System.IO.File.Create($@"{GetCurrentDirectory()}\{FileName}");
    }
    
    public static void CreateFolder(string? FolderName)
    {
        if (FolderName is null)
        {
            CLI.ShowError("FolderName is cant be null");
            return;
        }
        System.IO.Directory.CreateDirectory($@"{GetCurrentDirectory()}\{FolderName}");
    }

    
    public static bool MoveTo(string? command,bool overwrite)
    {
        if (command is null)
        {
            CLI.ShowError("Cant be null");
            return false;
        }
        var operations = CommandStringOperations.ParseMoveToCommand(command);
        string file_path1 = $@"{GetCurrentDirectory()}\{operations.Item1}";
        string file_path2 = $@"{GetCurrentDirectory()}\{operations.Item2}";
        if (!System.IO.File.Exists(file_path1))
        {
            CLI.ShowError("there no file named this!!! try another one!");
            return false;
        }

        if (overwrite && !System.IO.File.Exists(file_path2))
        {
            CLI.ShowError("there no file named this!!! try another one!");
            return false;
        }
        System.IO.File.Copy(file_path1,file_path2,overwrite:overwrite);
        return true;
    }

    public static bool Delete(string command)
    {
        if (command is null)
        {
            CLI.ShowError("command cant be null");
            return false;
        }
        string fullpath = $@"{GetCurrentDirectory()}\{command}";

        if (!System.IO.File.Exists(fullpath))
        {
            CLI.ShowError("File Not exists in this path");
            return false;
        }
        System.IO.File.Delete(fullpath);
        return true;
    }
    public static void GetAllFiles()
    {
        DirectoryInfo info = new DirectoryInfo(GetCurrentDirectory());
        CLI.PrintListFiles(info);
    }

    public static void GetTextFromFile(string? command)
    {
        if (command is null)
        {
            CLI.ShowError("command cant be null");
            return;
        }
        string fullpath = $@"{GetCurrentDirectory()}\{command}";
        if (!System.IO.File.Exists(fullpath))
        {
            CLI.ShowError($"There is not that file named {command}");
            return;
        }
        using (FileStream fs = System.IO.File.OpenRead(fullpath))
        {
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);

            while (fs.Read(b,0,b.Length) > 0)
            {
                CLI.PrintToConsole(temp.GetString(b),ConsoleColor.Gray);
            }
        }
        
    }
}