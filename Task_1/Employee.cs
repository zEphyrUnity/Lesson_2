using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task_1
{
    abstract class Employee
    {
        internal string firstName { get; set; }
        internal string lastName { get; set; }
        internal int salary { get; set; }

        public abstract double Salary();
    }

    class DataBase
    {
        internal Employee[] InitializeEmployeeBase(string path = @"..\..\EmployeeFix.csv")
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не существует");
                return null;
            }

            StreamReader sr = new StreamReader(path);
            List<FixRateEmployee> employee = new List<FixRateEmployee>();

            while (!sr.EndOfStream)
            {
                string[] str = sr.ReadLine().Split(';');
                FixRateEmployee worker = new FixRateEmployee();

                worker.lastName = str[0];
                worker.firstName = str[1];
                worker.salary = Int32.Parse(str[2]);

                employee.Add(worker);
            }

            sr.Close();
            return employee.ToArray();
        }

        internal void Show(Employee[] employee) 
        {
            for(int i = 0; i < employee.Length; i++)
                Console.WriteLine($"{employee[i].lastName} {employee[i].firstName} {employee[i].salary}");
        }

        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            Employee[] workers = dataBase.InitializeEmployeeBase();

            dataBase.Show(workers);
        }
    }
}
