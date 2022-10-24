namespace CoronaProjectDaniel
{
    internal class ShowNewSickCommand : Command
    {
        public override void Execute(IArgumentIterator args)
        {
            System.Console.WriteLine("New sicks since last run of the command:");
            SickSystem.System.List.PrintNew();
        }
    }
}