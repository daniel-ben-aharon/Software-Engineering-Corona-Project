using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaProjectDaniel
{
    /// <summary>
    /// Represents a command handler that accepts string parameters.
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Executes the command with given parameters.
        /// </summary>
        /// <param name="args">List of string parameters.</param>
        public abstract void Execute(IArgumentIterator args);
        /// <summary>
        /// Shows the argument list of the command
        /// </summary>
        protected string[] ArgNames { get; set; }
        public void ShowArguments()
        {
            if (ArgNames is null)
                return;
            for(int i = 0; i < ArgNames.Length - 1; i++)
            {
                Console.Write(ArgNames[i] + " ");
            }
            Console.Write(ArgNames[ArgNames.Length - 1]);
        }
    }
}
