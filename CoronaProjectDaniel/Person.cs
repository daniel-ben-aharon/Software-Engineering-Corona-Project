using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaProjectDaniel
{
    public class Person : IPerson
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public int HouseNumber { get; private set; }
        public int Apartment { get; private set; }
        public int HouseResidents { get; private set; }

        public int SourceSick { get; private set; }

        private List<RouteSite> Route { get; set; }
        private List<LabTest> LabTests { get; set; }

        public Person(int id, string firstName, string lastName, DateTime birthDate, string phone, string email, string city, string street, int houseNumber, int apartment, int houseResidents)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            Apartment = apartment;
            HouseResidents = houseResidents;
            SourceSick = 0;
            Route = new List<RouteSite>();
            LabTests = new List<LabTest>();
        }
        public void AddRouteSite(RouteSite site)
        {
            Route.Add(site);
        }
        public void AddLabTest(LabTest test)
        {
            LabTests.Add(test);
        }
        public void PrintRoute()
        {
            foreach (RouteSite site in Route)
                Console.WriteLine(site.ToString());
        }
        public void PrintLabTests()
        {
            Console.WriteLine("*** LAB RESULT BEGIN ***");
            foreach (LabTest test in LabTests)
                Console.WriteLine(test.ToString());
            Console.WriteLine("*** LAB RESULT END ***");
        }
        public LabTest GetLabTestById(int labid, int testid)
        {
            foreach (LabTest test in LabTests)
            {
                if (test.LabId == labid && test.TestId == testid)
                    return test;
            }
            return null;
        }
        public override string ToString()
        {
            return "" + Id + ", " + FirstName + ", " + LastName +
                ", " + BirthDate + ", " + Phone + ", " + Email +
                ", " + City + ", " + Street + ", " + HouseNumber +
                ", " + Apartment + ", " + HouseResidents + ", " + SourceSick;
        }

        public bool IsHealed()
        {
            // if not yet tested
            if (LabTests.Count == 0)
                return false;
            // init last sickness
            DateTime lastSickDate = new DateTime(0);
            LabTest sickTest = null;
            // check for last sickness
            foreach(LabTest test in LabTests)
            {
                if (test.Result == true)
                {
                    if(test.Date > lastSickDate)
                    {
                        lastSickDate = test.Date;
                        sickTest = test;
                    }
                }
            }
            // if wasn't sick yet
            if (sickTest == null)
                return false;
            // check for last false result
            foreach(LabTest test in LabTests)
            {
                if (test.Result == false && test.Date > lastSickDate)
                    return true;
            }
            // still sick...
            return false;
        }
    }
}
