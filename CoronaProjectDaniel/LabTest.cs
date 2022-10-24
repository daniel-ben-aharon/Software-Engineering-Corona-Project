using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaProjectDaniel
{
	public class LabTest
	{
		public int LabId { get; private set; }
		public int TestId { get; private set; }
		public int PatientId { get; private set; }
		public DateTime Date { get; private set; }
		public bool Result { get; private set; }

		public LabTest(int labId, int testId, int patientId, DateTime date, bool result)
		{
			this.LabId = labId;
			this.TestId = testId;
			this.PatientId = patientId;
			this.Date = date;
			this.Result = result;
		}

		public override string ToString()
		{
			return Date.ToString() +
				" " + LabId + " " + TestId + " " + Result;
		}
	}
}
