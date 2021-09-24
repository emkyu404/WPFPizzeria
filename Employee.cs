using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Pizzaria
{
    abstract class Employee
    {
        private int number;
        private string name;

        public int getNumber()
        {
            return number;
        }

        public string getName()
        {
            return name;
        }
    }
}
