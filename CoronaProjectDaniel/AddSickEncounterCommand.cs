using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaProjectDaniel
{
    class AddSickEncounterCommand : Command
    {
        public AddSickEncounterCommand()
        {
            this.ArgNames = new string[]
            {
                "sickid", "firstname", "lastname", "phone"
            };
        }
        public override void Execute(IArgumentIterator args)
        {
            SickEncounter encounter = new SickEncounter(
                args.NextInt(), args.NextString(), args.NextString(), args.NextString());
            SickSystem.System.List.AddSickEncounter(encounter);
        }
    }
}
