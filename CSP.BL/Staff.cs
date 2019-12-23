using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.BL
{
    public class Staff
    {
        private float hourlyRate;
        private int hoursWorked;
        public float HourlyRate { get; set; }
        public int HoursWorked {
            get {
                return hoursWorked;
            }

            set {
                if (value > 0)
                {
                    hoursWorked = value;
                }
                else
                {
                    hoursWorked = 0;
                }
            }
        }
        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }

        public Staff(string nameOfStaff, float rate)
        {
            NameOfStaff = nameOfStaff;
            HourlyRate = rate;
        }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            BasicPay = HoursWorked * HourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            StringBuilder staffValues = new StringBuilder();
            staffValues.AppendLine("Name: " + NameOfStaff);
            staffValues.AppendLine("Hourly Rate: "+HourlyRate);
            staffValues.AppendLine("Hours Worked: " + HoursWorked);
            staffValues.AppendLine("Basic Pay: " + BasicPay);
            staffValues.AppendLine("Total Pay: " + TotalPay);
            return staffValues.ToString();
        }
    }
}
