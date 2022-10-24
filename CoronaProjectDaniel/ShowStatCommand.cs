using System.Collections.Generic;
using System.Linq;

namespace CoronaProjectDaniel
{
    internal class ShowStatCommand : Command
    {
        public override void Execute(IArgumentIterator args)
        {
            List<string> stats = new List<string>();
            while (args.HasNext())
            {
                string[] splitted = args.NextString().Split(',');
                foreach (string stat in splitted)
                {
                    if (stat.Length > 0)
                        stats.Add(stat);
                }
            }
            SickSystem.System.List.PrintStats(stats.ToArray());

        }
    }
}