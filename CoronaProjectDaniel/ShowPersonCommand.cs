using System;

namespace CoronaProjectDaniel
{
    internal class ShowPersonCommand : Command
    {
        public ShowPersonCommand()
        {
            ArgNames = new string[] { "personid" };
        }
        public override void Execute(IArgumentIterator args)
        {
            // get person id
            int sickid = args.NextInt();
            // print person
            IPerson person = SickSystem.System.List.GetPersonById(sickid);
            Console.WriteLine(person.ToString());
            person.PrintLabTests();
        }
    }
}