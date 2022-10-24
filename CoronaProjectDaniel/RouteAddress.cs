using System;

namespace CoronaProjectDaniel
{
    public class RouteAddress : RouteSite
    {
        public RouteAddress(DateTime dateVisited, string siteName, string city, string street, int number)
            : base(dateVisited, siteName)
        {
            City = city;
            Street = street;
            Number = number;
        }

        public string City { get; private set; }
        public string Street { get; private set; }
        public int Number { get; private set; }

        public override string ToString()
        {
            return base.ToString() + " at " + Street + " " + Number + ", " + City;
        }
    }
}
