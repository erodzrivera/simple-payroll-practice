using CSP.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Common
{
    public class FileReader
    {
        private string path = "";
        public string Path {
            get {
                return path;
            }
            set {
                path = value;
            }
        }
        public FileReader()
        {

        }

        public FileReader(string newPath)
        {
            Path = newPath;
        }

        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = Path;
            if (String.IsNullOrEmpty(path)) {
                path = "C:\\Users\\Clark Kent\\source\\repos\\CSProject\\CSProject\\staff.txt";
            }
            string[] separator = { ", " };

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while(sr.EndOfStream != true)
                    {
                        string value = sr.ReadLine();
                        result = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        if (!String.IsNullOrEmpty(result[1])) {
                            switch (result[1])
                            {
                                case "Manager":
                                    myStaff.Add(new Manager(result[0]));
                                    break;
                                case "Admin":
                                    myStaff.Add(new Admin(result[0]));
                                    break;
                            }
                        }
                    }

                    sr.Close();
                }
            }
            else
            {
                Console.WriteLine("\nThe file at {0} was not found.", path);
            }

            return myStaff;
        }
    }
}
