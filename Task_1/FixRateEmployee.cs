using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class FixRateEmployee : Employee
    {
        private const int salaryRate = 2;

        public override double Salary() 
        {
            return 20.8 * 8 * salaryRate;
        }
    }
}
