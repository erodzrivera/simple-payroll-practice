using CSP.BL;
using CSP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff = new List<Staff>();
            FileReader fileReader = new FileReader();
            int month = 0;
            int year = 0;

            Console.WriteLine("\nSimple Payroll Application");
            Console.WriteLine("==========================");

            while (year == 0)
            {
                Console.Write("\nPlease enter a year: ");
                try
                {
                    string input = Console.ReadLine();
                    if (input.Length == 4) {
                        Int32.TryParse(input, out year);
                        if (year < 2019)
                        {
                            year = 0;
                            Console.WriteLine("\nYour year value is too small.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nYour input does not have enough digits or is in the wrong format.");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("\nAn error occured. "+e.Message);
                    Console.WriteLine("Please provide a valid year number greater than 2019.\n");
                }
            }

            while(month == 0)
            {
                Console.Write("\nPlease enter a month between 1 and 12: ");
                try
                {
                    Int32.TryParse(Console.ReadLine(), out month);
                    if (month < 1 || month > 12)
                    {
                        month = 0;
                        Console.WriteLine("\nPlease provide a valid month number between 1 and 12.\n");
                    }
                }
                catch(FormatException e)
                {
                    Console.WriteLine("An error occured. " + e.Message);
                    Console.WriteLine("\nPlease provide a valid month number between 1 and 12. Error: "+e.Message+"\n");
                }
            }

            myStaff = fileReader.ReadFile();

            for (int i = 0; i < myStaff.Count(); i++)
            {
                try
                {
                    int hoursWorked = -1;
                    while (hoursWorked < 0)
                    {
                        Console.Write("\nEnter hours worked by " + myStaff[i].NameOfStaff+": ");
                        bool success = Int32.TryParse(Console.ReadLine(), out hoursWorked);
                        if (success)
                        {
                            myStaff[i].HoursWorked = hoursWorked;
                        }
                        Console.WriteLine("");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("\nProvide a valid number greater or equal to 0. Error: "+e.Message);
                    i--;
                }

                myStaff[i].CalculatePay();

                Console.WriteLine(myStaff[i].ToString());
            }

            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);

            Console.WriteLine("\nEnd of Application");

            // Prevent Auto Closing
            Console.Read();
        }
    }
}
