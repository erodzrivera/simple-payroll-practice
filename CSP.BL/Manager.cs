using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.BL
{
    public class Manager : Staff
    {
        private const float managerHourlyRate = 50f;
        public int Allowance { get; private set; }

        public Manager(string name) : base(name, managerHourlyRate)
        {
            //Console.WriteLine("Manager Constructor Called.");
        }

        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if (HoursWorked > 160)
            {
                TotalPay += Allowance;
            }
        }

        public override string ToString()
        {
            StringBuilder staffValues = new StringBuilder();
            staffValues.AppendLine("Name: " + NameOfStaff);
            staffValues.AppendLine("Hourly Rate: " + String.Format("{0:C}", HourlyRate));
            staffValues.AppendLine("Hours Worked: " + HoursWorked);
            staffValues.AppendLine("Basic Pay: " + String.Format("{0:C}", BasicPay));
            staffValues.AppendLine("Allowance: " + String.Format("{0:C}", Allowance));
            staffValues.AppendLine("Total Pay: " + String.Format("{0:C}", TotalPay));
            return staffValues.ToString();
        }
    }
}
