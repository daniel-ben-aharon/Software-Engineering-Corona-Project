namespace CoronaProjectDaniel
{
    internal class UpdateLabTestCommand : Command
    {
        public UpdateLabTestCommand()
        {
            this.ArgNames = new string[]
            {
                "labid", "testid", "personid", "date", "result"
            };
        }

        public override void Execute(IArgumentIterator args)
        {
            int labid = args.NextInt();
            int testid = args.NextInt();
            LabTest test = new LabTest(labid, testid, args.NextInt(),
                args.NextDate(), args.NextBool());
            if(SickSystem.System.List.GetLabTestById(labid, testid) == null)
            {
                SickSystem.System.List.GetPersonById(test.PatientId).AddLabTest(test);
            }
        }
    }
}