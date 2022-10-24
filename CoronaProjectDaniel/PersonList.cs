using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaProjectDaniel
{
    class PersonList : IPersonList
    {
        private Dictionary<int, IPerson> _persons;
        private Dictionary<int, SickEncounter> _encounters;
        private List<SickPerson> usedSicks;
        public PersonList()
        {
            _persons = new Dictionary<int, IPerson>();
            _encounters = new Dictionary<int, SickEncounter>();
            usedSicks = new List<SickPerson>();
        }

        public void AddPerson(IPerson person)
        {
            if (_persons.ContainsKey(person.Id))
                _persons[person.Id] = person;
            else
                _persons.Add(person.Id, person);
        }
        public void AddSickEncounter(SickEncounter encounter)
        {
            _encounters.Add(encounter.EncounterId, encounter);
        }
        public void RemoveSickEncounter(int encounterId)
        {
            _encounters.Remove(encounterId);
        }
        public void PrintSickEncounters()
        {
            foreach(SickEncounter encounter in _encounters.Values)
                Console.WriteLine(encounter.ToString());
        }
        public SickEncounter GetEncounterById(int encounterId)
        {
            if (!_encounters.ContainsKey(encounterId))
                return null;
            return _encounters[encounterId];
        }
        public IPerson GetPersonById(int id)
        {
            if (!_persons.ContainsKey(id))
                return null;
            return _persons[id];
        }

        public LabTest GetLabTestById(int labid, int testid)
        {
            foreach (IPerson person in _persons.Values)
            {
                LabTest test = person.GetLabTestById(labid, testid);
                if (test != null)
                    return test;
            }
            return null;
        }

        public void PrintNew()
        {
            foreach (IPerson sick in _persons.Values)
            {
                if (sick is SickPerson)
                {
                    if (!usedSicks.Contains(sick as SickPerson))
                    {
                        Console.WriteLine(sick.ToString());
                        usedSicks.Add(sick as SickPerson);
                    }
                }
            }
        }

        public void PrintSicks()
        {
            foreach (IPerson sick in _persons.Values)
            {
                if (sick is SickPerson)
                    Console.WriteLine(sick.ToString());
            }
        }
        public void PrintIsolated()
        {
            foreach(IPerson iso in _persons.Values)
            {
                if (IsIsolated(iso))
                    Console.WriteLine(iso.ToString());
            }
        }
        private bool IsIsolated(IPerson person)
        {
            if(person is EncounteredPerson)
            {
                EncounteredPerson ep = person as EncounteredPerson;
                TimeSpan diff = DateTime.Now - ep.IsolationDate;
                if (diff.TotalDays < 14)
                    return true;
            }
            return false;
        }
        public void PrintStats(string[] stats)
        {
            foreach(string stat in stats)
            {
                Console.WriteLine("*** BEGIN " + stat.ToUpper() + " ***");
                switch(stat)
                {
                    case "sick":
                        int sickCount = 0;
                        foreach(IPerson person in _persons.Values)
                            if (person is SickPerson)
                                sickCount++;
                        Console.WriteLine(sickCount);
                        break;
                    case "healed":
                        int healCount = 0;
                        foreach (IPerson person in _persons.Values)
                            if (person.IsHealed())
                                healCount++;
                        Console.WriteLine(healCount);
                        break;
                    case "isolated":
                        int isoCount = 0;
                        foreach (IPerson person in _persons.Values)
                            if (IsIsolated(person))
                                isoCount++;
                        Console.WriteLine(isoCount);
                        break;
                    case "sick-per-city":
                        // calculate sicks per city
                        Dictionary<string, int> citySicks = new Dictionary<string, int>();
                        foreach (IPerson person in _persons.Values)
                        {
                            if (!citySicks.ContainsKey(person.City))
                                citySicks.Add(person.City, 0);
                            if (person is SickPerson)
                            {
                                    citySicks[person.City]++;
                            }
                        }
                        // print sicks per city
                        foreach (KeyValuePair<string, int> city in citySicks)
                            Console.WriteLine(city.Key + " - " + city.Value);
                        break;
                    default:
                        Console.WriteLine("Invalid stat name");
                        break;
                }
                Console.WriteLine("*** END " + stat.ToUpper() + " ***");
            }
        }
    }
}
