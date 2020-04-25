using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class FixRateEmployee : Employee
    {
        internal override double Salary() 
        {
            return salary;
        }
    }
}
