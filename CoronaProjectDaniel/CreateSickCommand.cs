using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CoronaProjectDaniel
{
    class CreateSickCommand : Command
    {
        public CreateSickCommand()
        {
            ArgNames = new string[] {"id", "firstname", "lastname",
            "birthdate", "phone", "mail", "city", "street", "house-number", 
                "apartment", "house-residents" };
        }
        public override void Execute(IArgumentIterator args)
        {
            // create sick
            SickPerson sick = new SickPerson(
                new Person(args.NextInt(), args.NextString(), args.NextString(),
                args.NextDate(), args.NextString(), args.NextString(), args.NextString(),
                args.NextString(), args.NextInt(), args.NextInt(), args.NextInt()));
            // add to system
            SickSystem.System.List.AddPerson(sick);
        }
    }
}
