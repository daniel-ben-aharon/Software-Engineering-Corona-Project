using System;

namespace CoronaProjectDaniel
{
    internal class AddRouteAddressCommand : Command
    {
        public AddRouteAddressCommand()
        {
            this.ArgNames = new string[]
            {
                "id", "date", "time", "sitename",
                "city", "street", "number"
            };
        }
        public override void Execute(IArgumentIterator args)
        {
            int sickid = args.NextInt();
            // create the route site
            DateTime dt = DateTime.Parse(args.NextString() + " " + args.NextString());
            RouteAddress site = new RouteAddress(dt, args.NextString(), 
                args.NextString(), args.NextString(), args.NextInt());
            // add to sick
            SickSystem.System.List.GetPersonById(sickid).AddRouteSite(site);
        }
    }
}