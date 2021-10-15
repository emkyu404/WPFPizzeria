using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Pizzaria
{
    class DeliveryMan : Employee
    {
        public DeliveryMan(int number, string name, string surname, Address address) : base(number, name, surname, address)
        {
            
        }

        public string Type
        {
            get => "Livreur";
        }
    }
}
