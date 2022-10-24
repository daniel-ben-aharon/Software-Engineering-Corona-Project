namespace CoronaProjectDaniel
{
    public interface IPersonList
    {
        void AddPerson(IPerson person);
        void AddSickEncounter(SickEncounter encounter);
        SickEncounter GetEncounterById(int encounterId);
        LabTest GetLabTestById(int labid, int testid);
        IPerson GetPersonById(int id);
        void PrintIsolated();
        void PrintNew();
        void PrintSickEncounters();
        void PrintSicks();
        void PrintStats(string[] stats);
        void RemoveSickEncounter(int encounterId);
    }
}