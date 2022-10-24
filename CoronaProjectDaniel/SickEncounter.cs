using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaProjectDaniel
{
    public class SickEncounter
    {
        private static int autoEncounterId = 0;

        public SickEncounter(int sourceSickId, string firstName, string lastName, string phone)
        {
            if (SickSystem.System.List.GetPersonById(sourceSickId) == null)
                throw new KeyNotFoundException("There is no sick with ID " + sourceSickId);
            EncounterId = autoEncounterId++;
            SourceSickId = sourceSickId;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;

            DateReported = DateTime.Now;
        }

        public int EncounterId { get; private set; }
        public int SourceSickId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Phone { get; private set; }
        public DateTime DateReported { get; private set; }

        public override string ToString()
        {
            IPerson source = SickSystem.System.List.GetPersonById(SourceSickId);
            return "" + EncounterId + ", " + SourceSickId + ", " +
                source.FirstName + ", " + source.LastName + ", " +
                FirstName + ", " + LastName + ", " + Phone;
        }
    }
}
