namespace Emulator.App;

public static class CLI
{
    public static void PrintToConsole(string text,ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}