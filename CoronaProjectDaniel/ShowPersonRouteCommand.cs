namespace CoronaProjectDaniel
{
    internal class ShowPersonRouteCommand : Command
    {
        public ShowPersonRouteCommand()
        {
            this.ArgNames = new string[] { "personid" };
        }

        public override void Execute(IArgumentIterator args)
        {
            // get person id
            int sickid = args.NextInt();
            // print route
            SickSystem.System.List.GetPersonById(sickid).PrintRoute();
        }
    }
}