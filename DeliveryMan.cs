using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Pizzaria
{
    class DeliveryMan : Employee
    {
        public DeliveryMan(string name, string surname, Address address) : base(name, surname, address)
        {
            Employee.RegisteredEmployees.Add(this.Number, this);
        }

        public string Type
        {
            get => "Livreur";
        }

        public override string getType()
        {
            return "Livreur";
        }
    }
}
