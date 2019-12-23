using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.BL
{
    public class Admin : Staff
    {
        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 30f;
        public float OverTime { get; private set; }
        public Admin(string name) : base(name, adminHourlyRate)
        {
            //Console.WriteLine("Admin Constructor.");
        }

        public override void CalculatePay()
        {
            base.CalculatePay();
            if(HoursWorked > 160)
            {
                OverTime = overtimeRate * (HoursWorked - 160);
                TotalPay += OverTime;
            }
        }

        public override string ToString()
        {
            StringBuilder staffValues = new StringBuilder();
            staffValues.AppendLine("Name: " + NameOfStaff);
            staffValues.AppendLine("Hourly Rate: " + String.Format("{0:C}", HourlyRate));
            staffValues.AppendLine("Hours Worked: " + HoursWorked);
            staffValues.AppendLine("Basic Pay: "+String.Format("{0:C}", BasicPay));
            staffValues.AppendLine("Over Time: " + String.Format("{0:C}", OverTime));
            staffValues.AppendLine("Total Pay: " + String.Format("{0:C}", TotalPay));
            return staffValues.ToString();
        }
    }
}
