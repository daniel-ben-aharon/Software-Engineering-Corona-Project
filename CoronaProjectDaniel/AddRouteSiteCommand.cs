using System;

namespace CoronaProjectDaniel
{
    internal class AddRouteSiteCommand : Command
    {
        public AddRouteSiteCommand()
        {
            this.ArgNames = new string[]
            {
                "id", "date", "time", "sitename"
            };
        }

        public override void Execute(IArgumentIterator args)
        {
            int sickid = args.NextInt();
            // create the route site
            DateTime dt = DateTime.Parse(args.NextString() + " " + args.NextString());
            RouteSite site = new RouteSite(dt, args.NextString());
            // add to sick
            SickSystem.System.List.GetPersonById(sickid).AddRouteSite(site);
        }
    }
}