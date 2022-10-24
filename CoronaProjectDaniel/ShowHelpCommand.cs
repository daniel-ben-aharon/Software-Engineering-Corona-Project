using System.Collections.Generic;
using System.Linq;

namespace CoronaProjectDaniel
{
    public class ShowHelpCommand : Command
    {
        public override void Execute(IArgumentIterator args)
        {
            Interpreter.ShowHelp();
        }
    }
}