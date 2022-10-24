using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaProjectDaniel
{
    class ShowSickCommand : Command
    {
        public ShowSickCommand()
        {

        }
        public override void Execute(IArgumentIterator args)
        {
            SickSystem.System.List.PrintSicks();
        }
    }
}
