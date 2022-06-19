using System.Security.Cryptography;

namespace Emulator.App;

public static class StringOperations
{
    public static (string,string) ParseMoveToCommand(string command)
    {
        int index = command.IndexOf('-');
        string file_name = command.Substring(0, index);
        string file_name2 = command.Substring(index + 1, command.Length - index - 1);
        return (file_name, file_name2);
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