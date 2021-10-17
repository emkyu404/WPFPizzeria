using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task shipOrderAsync(Order od)
        {
            this.Orders.Add(od.getNumber(),od);
            await Task.Run(() => shipOrderOrder(od));
        }

        public void shipOrderOrder(Order od)
        {
            Task.Delay(10000).Wait();
            od.isShipping();
        }
    }
}
