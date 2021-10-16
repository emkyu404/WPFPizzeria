using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Pizzaria
{
    class Commis : Employee
    {
        public Commis(string name, string surname, Address address) : base(name, surname, address)
        {
            Employee.RegisteredEmployees.Add(this.Number, this);
        }
        public string Type
        {
            get => "Commis";
        }
    }
}
