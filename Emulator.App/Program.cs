﻿using System;

namespace Emulator.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            string? operation;
            while (true)
            {
                Console.WriteLine("Enter a command: ");
                operation = Console.ReadLine();
                var values = CLI.ParseCliCommand(operation);
                while (values.Item1 is null && values.Item2 is null)
                {
                    CLI.PrintToConsole("There is no commanda try again!",ConsoleColor.Red);
                    operation = Console.ReadLine();
                    values = CLI.ParseCliCommand(operation);
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
                                CLI.PrintToConsole($"Unexpected command -{values.Item2}- do yo mean {values.Item1}",ConsoleColor.Red);
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
                                CLI.PrintToConsole("Command is ntt defined try another command",ConsoleColor.Red);
                            }
                            else
                            {
                                File.ChangeCurrentDirtectory(values.Item2);
                                string current_path = File.GetCurrentDirectory();
                                CLI.PrintToConsole(current_path,ConsoleColor.Red);    
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
                            CLI.PrintToConsole("Path is not defined try again: ",ConsoleColor.Red);
                        }
                        else
                        {
                           File.CreateTextFile(values.Item2);    
                        }
                    }break; 
                    default:
                    {
                       CLI.PrintToConsole("There not command like this try another one!",ConsoleColor.Red); 
                    }break;
                }
            }   
        }
      
    }
}