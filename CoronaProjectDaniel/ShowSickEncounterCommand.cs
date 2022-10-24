namespace CoronaProjectDaniel
{
    internal class ShowSickEncounterCommand : Command
    {
        public override void Execute(IArgumentIterator args)
        {
            SickSystem.System.List.PrintSickEncounters();
        }
    }
}