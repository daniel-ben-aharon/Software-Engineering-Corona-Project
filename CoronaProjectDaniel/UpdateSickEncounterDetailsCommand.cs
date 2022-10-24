namespace CoronaProjectDaniel
{
    internal class UpdateSickEncounterDetailsCommand : Command
    {
        public UpdateSickEncounterDetailsCommand()
        {
            ArgNames = new string[] {"encounterid", "personid", "firstname", "lastname",
            "birthdate", "phone", "mail", "city", "street", "house-number",
                "apartment", "house-residents" };
        }

        public override void Execute(IArgumentIterator args)
        {
            int encounterid = args.NextInt();
            SickEncounter encounter = SickSystem.System.List.GetEncounterById(encounterid);
            if (encounter is null)
                throw new CommandException("Invalid encounter ID");
            EncounteredPerson person = new EncounteredPerson(encounter, new Person(
                args.NextInt(), args.NextString(), args.NextString(), args.NextDate(),
                args.NextString(), args.NextString(), args.NextString(), args.NextString(),
                args.NextInt(), args.NextInt(), args.NextInt()));
            SickSystem.System.List.AddPerson(person);
            SickSystem.System.List.RemoveSickEncounter(encounterid);
        }
    }
}