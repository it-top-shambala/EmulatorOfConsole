namespace Emulator.App;

public static class CLI
{
    public static void PrintToConsole(string text,ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static void ShowError(string message) => PrintToConsole(message, ConsoleColor.Red); 
    public static void ShowSuccess(string message) => PrintToConsole(message, ConsoleColor.Green);
    public static void ShowInfo(string message) => PrintToConsole(message, ConsoleColor.Blue);
    
    public static void ShownConsolePath()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write($"{File.GetCurrentDirectory()} - {Environment.UserName}:~$ ");
        Console.ResetColor();
    }

    public static void PrintListFiles(DirectoryInfo directoryInfo)
    {
        ShowInfo("Files");
        ShowInfo("===================================================================");
        if (directoryInfo.GetFiles().Length == 0)
        {
            ShowInfo("THERE IS NO FILE");
        }
        else
        {
            foreach (var info in directoryInfo.GetFiles())
            {
                PrintToConsole($"{info.Name} - {info.CreationTime}", ConsoleColor.DarkBlue);
            }
        }
        ShowInfo("===================================================================");
        ShowInfo("Folders");
        if (directoryInfo.GetDirectories().Length == 0)
        {
            ShowInfo("THERE IS NO FOLDER");
        }
        else
        {
            foreach (var info in directoryInfo.GetDirectories())
            {
                PrintToConsole($"{info.Name} - {info.CreationTime}", ConsoleColor.DarkBlue);
            }
        }
    }
}