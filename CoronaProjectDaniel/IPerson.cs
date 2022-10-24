using System;

namespace CoronaProjectDaniel
{
    public interface IPerson
    {
        int Apartment { get; }
        DateTime BirthDate { get; }
        string City { get; }
        string Email { get; }
        string FirstName { get; }
        int HouseNumber { get; }
        int HouseResidents { get; }
        int Id { get; }
        string LastName { get; }
        string Phone { get; }
        int SourceSick { get; }
        string Street { get; }

        void AddLabTest(LabTest test);
        void AddRouteSite(RouteSite site);
        LabTest GetLabTestById(int labid, int testid);
        void PrintLabTests();
        void PrintRoute();
        bool IsHealed();
        string ToString();
    }
}