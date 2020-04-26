using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace Task_1
{
    abstract class Employee : IComparable, IEnumerable
    {
        internal string firstName { get; set; }
        internal string lastName { get; set; }
        internal double salary { get; set; }

        internal abstract double Salary();

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator() ;
        }

        public int CompareTo(object worker)
        {
            Employee employee;
            employee = (Employee)worker;

            return salary.CompareTo(employee.salary);
        }
    }

    class DataBase
    {
        internal FixRateEmployee[] InitializeEmployeeFix(string path = @"..\..\EmployeeFix.csv")
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не существует");
                return null;
            }

            StreamReader sr = new StreamReader(path);
            FixRateEmployee worker;
            List<FixRateEmployee> employee = new List<FixRateEmployee>();

            while (!sr.EndOfStream)
            {
                string[] str = sr.ReadLine().Split(';');
                worker = new FixRateEmployee();

                worker.lastName = str[0];
                worker.firstName = str[1];
                worker.salary = Int32.Parse(str[2]);

                employee.Add(worker);
            }
            sr.Close();

            employee.Sort();
            return employee.ToArray();
        }

        internal HourlyRateEmployee[] InitializeEmployeeHourly(string path = @"..\..\EmployeeHourly.csv")
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не существует");
                return null;
            }

            StreamReader sr = new StreamReader(path);
            HourlyRateEmployee worker;
            List<HourlyRateEmployee> employee = new List<HourlyRateEmployee>();

            while (!sr.EndOfStream)
            {
                string[] str = sr.ReadLine().Split(';');
                worker = new HourlyRateEmployee();

                worker.lastName = str[0];
                worker.firstName = str[1];
                worker.salary = Double.Parse(str[2]);

                employee.Add(worker);
            }
            sr.Close();

            employee.Sort();
            return employee.ToArray();
        }

        internal void Show(FixRateEmployee[] employee)
        {
            foreach (FixRateEmployee item in employee)
                Console.WriteLine($"{item.lastName} {item.firstName} {item.Salary()}");
        }
        internal void Show(HourlyRateEmployee[] employee)
        {
            foreach (HourlyRateEmployee item in employee)
                Console.WriteLine($"{item.lastName} {item.firstName} {item.Salary()}");
        }

        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            FixRateEmployee[] workersFix = dataBase.InitializeEmployeeFix();
            HourlyRateEmployee[] workersHourly = dataBase.InitializeEmployeeHourly();

            dataBase.Show(workersFix);
            dataBase.Show(workersHourly);
        }
    }
}
