namespace CoronaProjectDaniel
{
    internal class ShowIsolatedCommand : Command
    {
        public override void Execute(IArgumentIterator args)
        {
            SickSystem.System.List.PrintIsolated();
        }
    }
}