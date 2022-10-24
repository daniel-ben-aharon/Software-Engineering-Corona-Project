using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace CoronaProjectDaniel
{
    static class Interpreter
    {
        private static Dictionary<string, Command> commands = new Dictionary<string, Command>
        {
            {"Create-sick", new CreateSickCommand() },
            {"Add-route-site", new AddRouteSiteCommand() },
            {"Add-route-address", new AddRouteAddressCommand() },
            {"Add-sick-encounter", new AddSickEncounterCommand() },
            {"Show-sick-encounter", new ShowSickEncounterCommand() },
            {"Update-sick-encounter-details", new UpdateSickEncounterDetailsCommand() },
            {"Update-lab-test", new UpdateLabTestCommand()},
            {"Show-new-sick", new ShowNewSickCommand() },
            {"Show-stat", new ShowStatCommand() },
            {"Show-person", new ShowPersonCommand() },
            {"Show-person-route", new ShowPersonRouteCommand() },
            {"Show-sick", new ShowSickCommand() },
            {"Show-isolated", new ShowIsolatedCommand() },
            {"Show-help", new ShowHelpCommand() }
        };
        /// <summary>
        /// Interprets a stream of commands.
        /// </summary>
        /// <param name="stream">Stream of commands (usually file of memory).</param>
        public static void Interpret(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);

            while(!reader.EndOfStream)
            {
                string line = reader.ReadLine().Trim();
                // ignore blank lines
                if (line.Length == 0)
                    continue;
                // split command & parameters using whitespace
                string[] cmd = line.Split(new char[]{' ', '\t'});
                // get command
                if (!commands.ContainsKey(cmd[0]))
                    throw new CommandException("Command \"" + cmd[0] + " doesn't exist.");
                // execute command
                commands[cmd[0]].Execute(new ArgumentIterator(cmd.Skip(1)));
            }
            reader.Close(); 
        }
        public static void ShowHelp()
        {
            foreach(KeyValuePair<string, Command> cmd in commands)
            {
                Console.Write(cmd.Key + " ");
                cmd.Value.ShowArguments();
                Console.WriteLine();
            }
        }
    }

    class CommandException : Exception
    {
        public CommandException(string message) : base(message) { }
    }
}
