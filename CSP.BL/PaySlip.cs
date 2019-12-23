using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.BL
{
    public class PaySlip
    {
        private int month;
        private int year;
        enum MonthsOfYear { JAN = 1, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DIC };

        public PaySlip(int newMonth, int newYear)
        {
            month = newMonth;
            year = newYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;
            foreach(var f in myStaff)
            {
                var separator = "===================================";
                path = f.NameOfStaff + ".txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("PAYSLIP FOR "+(MonthsOfYear)month+" "+year);
                    sw.WriteLine(separator);
                    sw.WriteLine("Name of Staff: " + f.NameOfStaff);
                    sw.WriteLine("Hours Worked: " + f.HoursWorked+"\n");
                    sw.WriteLine("Basic Pay: " + String.Format("{0:C}" , f.BasicPay));
                    if (f.GetType().ToString() == "Manager")
                    {
                        sw.WriteLine("Allowance: {0}", String.Format("{0:C}", ((Manager)f).Allowance));
                    }
                    if (f.GetType().ToString() == "Admin")
                    {
                        sw.WriteLine("Over Time: {0}", String.Format("{0:C}", ((Admin)f).OverTime));
                    }
                    sw.WriteLine("\n"+separator);
                    
                    sw.WriteLine("Total Pay: {0}", String.Format("{0:C}", f.TotalPay));
                    sw.WriteLine(separator);

                    sw.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            /*var result = from staff in myStaff
                         where staff.HoursWorked < 160
                         orderby staff.NameOfStaff ascending
                         select new { staff.NameOfStaff, staff.HoursWorked };*/
            var result = myStaff.Where(staff => staff.HoursWorked < 10)
                .OrderBy(staff => staff.NameOfStaff)
                .Select(staff => new { staff.NameOfStaff, staff.HoursWorked });

            string path = "summary.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than 10 working hours:\n");
                foreach (var staff in result)
                {
                    sw.WriteLine("Name of Staff: {0}, Hours Worked: {1}", staff.NameOfStaff, staff.HoursWorked);
                }
                sw.Close();
            }
        }

        public override string ToString()
        {
            return "PaySlip for "+(MonthsOfYear)month+" "+year;
        }
    }
}
