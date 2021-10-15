using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Pizzaria
{
    class Commis : Employee
    {
        public Commis(int number, string name, string surname, Address address) : base(number, name, surname, address)
        {

        }
        public string Type
        {
            get => "Commis";
        }
    }
}
