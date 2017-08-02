using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace BasicCli
{
    class Program
    {
        public static void Main(string[] args)
        {
            var exit = false;
            while(exit == false)
            {
                Console.WriteLine();
                Console.WriteLine("Enter command (help to display help): "); 
                var command = Parser.Parse(Console.ReadLine());
                exit = command.Execute();
            }
        }
    }

    public interface ICommand
    {
        bool Execute();
    }

    public class ExitCommand : ICommand
    {
        public bool Execute()
        {
            return true;
        }
    }

    public class ParrotCommand : ICommand
    {
        
        public ParrotCommand(List<string> input)
        {
            input.ForEach(x => Console.WriteLine(x));
        }
        
        public bool Execute()
        {
            return false;
        }
    }

    public class nullCommand : ICommand
    {
        public bool Execute()
        {
            return false;
        }
    }

    public static class Parser
    {
        public static ICommand Parse(string commandString) { 
            // Parse your string and create Command object
            var commandParts = commandString.Split(' ').ToList();
            var commandName = commandParts[0];
            var args = commandParts.Skip(1).ToList(); // the arguments is after the command
            switch(commandName)
            {
                // Create command based on CommandName (and maybe arguments)
                case "exit": 
                    return new ExitCommand();
                    break;

                case "parrot": 
                    return new ParrotCommand(args);
                    break;

                default:
                    Console.WriteLine("defaultcase");
                    return new nullCommand();
                    break;

            }
        }  
    }
}
