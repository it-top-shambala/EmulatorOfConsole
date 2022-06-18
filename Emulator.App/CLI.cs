namespace Emulator.App;

public static class CLI
{
    public static void PrintToConsole(string text,ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
    
    /// <summary>
    /// For parsing Command Line like (c-pwd Downloads/Some) will return cwp command and Downloads/Some as path
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public static (string,string) ParseCliCommand(string command)
    {
        string[] text = command.Split(' ');
        if (text.Length > 2)
        {
            return (null, null);
        }else if (text.Length == 2)
        {
            return (text[0],text[1]);
        }
        else
        {
            return (text[0],null);
        }
    }
}