using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaProjectDaniel
{
    public class RouteSite
    {
        public RouteSite(DateTime dateVisited, string siteName)
        {
            DateVisited = dateVisited;
            SiteName = siteName;
        }

        public DateTime DateVisited { get; private set; }
        public string SiteName { get; private set; }
        public override string ToString()
        {
            return DateVisited.ToString() + " - " + SiteName;
        }
    }
}
