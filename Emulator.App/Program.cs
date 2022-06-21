using System;

namespace Emulator.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            string? operation;
            while (true)
            {
                CLI.ShownConsolePath();
                operation = Console.ReadLine();
                var values = CommandStringOperations.ParseCliCommand(operation);
                while (values.Item1 is null && values.Item2 is null)
                {
                    CLI.ShowError("There is no commanda try again!");
                    operation = Console.ReadLine();
                    values = CommandStringOperations.ParseCliCommand(operation);
                }
                switch (values.Item1)
                {
                    case "PWD":
                    case "pwd":
                    {
                        try
                        {
                            if (values.Item2 is not null)
                            {
                                CLI.ShowError($"Unexpected command -{values.Item2}- do yo mean {values.Item1}");
                            }
                            else
                            {
                                string path = File.GetCurrentDirectory();
                                CLI.PrintToConsole(path,ConsoleColor.Red);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }break;
                    case "C-PWD":
                    case "c-pwd":
                    {
                        try
                        {
                            if (values.Item2 is null)
                            {
                                CLI.ShowError("Command is not defined try another command");
                            }
                            else
                            {
                                if (File.ChangeCurrentDirtectory(values.Item2))
                                {
                                    string current_path = File.GetCurrentDirectory();
                                    CLI.ShowError(current_path);    
                                }
                              
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }break;
                    case "TOUCH":
                    case "Touch":
                    {
                        if (values.Item2 is null)
                        {
                            CLI.ShowError("Path is not defined try again: ");
                        }
                        else
                        {
                           File.CreateTextFile(values.Item2);    
                        }
                    }break;
                    case "Cfol":
                    case "CFOL":
                    {
                        if (values.Item2 is null)
                        {
                            CLI.ShowError("Path is not defined try again: ");
                        }
                        File.CreateFolder(values.Item2);
                    } break;    
                    case "cpto":
                    case "CPTO":
                    {
                        if (values.Item2 is null)
                        {
                            CLI.ShowError("Path is not defined try again: ");
                        }
                        try
                        {
                            File.MoveTo(values.Item2, overwrite: true);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }break;
                    case "cp":
                    case "CP":
                    {
                        if (values.Item2 is null)
                        {
                            CLI.ShowError("Path is not defined try again: ");
                        }
                        try
                        {
                            File.MoveTo(values.Item2, overwrite: false);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }break;
                    case "rmv":
                    case "RMV":
                    {
                        if (values.Item2 is null)
                        {
                            CLI.ShowError("Path is not defined try again: ");
                        }
                        if (File.Delete(values.Item2))
                        {
                            CLI.ShowSuccess("File deleted done");
                        }
                    }break;
                    case "list":
                    case "LIST":
                    {
                        File.GetAllFiles();   
                    }break;
                    case "read":
                    case "READ":
                    {
                        if (values.Item2 is null)
                        {
                            CLI.ShowError("Path is not defined try again: ");
                        }

                        File.GetTextFromFile(values.Item2);
                    }break;     
                    default:
                    {
                       CLI.ShowError("There not command like this try another one!"); 
                    }break;
                }
            }   
        }
      
    }
}