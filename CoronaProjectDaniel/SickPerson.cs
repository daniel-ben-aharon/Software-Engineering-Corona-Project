using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaProjectDaniel
{
    /// <summary>
    /// Decorator for sick person
    /// </summary>
    public class SickPerson : IPerson
    {
        private IPerson _person;
        public int Apartment => _person.Apartment;
        public DateTime BirthDate => _person.BirthDate;
        public string City => _person.City;
        public string Email => _person.Email;
        public string FirstName => _person.FirstName;
        public int HouseNumber => _person.HouseNumber;
        public int HouseResidents => _person.HouseResidents;
        public int Id => _person.Id;
        public string LastName => _person.LastName;
        public string Phone => _person.Phone;
        public int SourceSick => _person.SourceSick;
        public string Street => _person.Street;

        public IPerson BasePerson => _person;

        public SickPerson(IPerson person)
        {
            this._person = person;
        }
        public void AddLabTest(LabTest test)
        {
            _person.AddLabTest(test);
        }

        public void AddRouteSite(RouteSite site)
        {
            _person.AddRouteSite(site);
        }

        public LabTest GetLabTestById(int labid, int testid)
            => _person.GetLabTestById(labid, testid);
        public void PrintLabTests()
        {
            _person.PrintLabTests();
        }

        public void PrintRoute()
        {
            _person.PrintRoute();
        }

        public override string ToString()
        {
            return _person.ToString();
        }

        public bool IsHealed() => _person.IsHealed();
    }
}
