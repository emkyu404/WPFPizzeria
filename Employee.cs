using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Pizzaria
{
    abstract class Employee
    {
        private int number;
        private string name;
        private string surname;
        private Address address;

        public static int numInc = 0;

        private List<Order> orders;

        public int Number
        {
            get => number;
            set => number = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Surname
        {
            get => surname;
            set => surname = value;
        }

        public static Dictionary<int,Employee> RegisteredEmployees = new Dictionary<int,Employee>();
        /*{
        new Commis(1, "Antoine", "CHENG", new Address(66, "Rue Camille Desmoulins", 6454230, "Cachan")),
        new Commis(2, "aezegtrh", "retgrhyte", new Address(98, "Rue Camille Desmoulins", 6454230, "aachan")),
        new DeliveryMan(1, "thegz", "sfd", new Address(1, "Rue Camille Desmoulins", 6454230, "Bachan"))
        };*/
        

        public Employee(string name, string surname, Address address)
        {
            this.number = ++numInc;
            this.name = name;
            this.surname = surname; 
            this.address = address;
            this.orders = new List<Order>();
        }

        public string Address => address.Number + " " + address.StreetName;

        public int ZipCode => address.ZipCode;

        public string City => address.City;

        public static List<Employee> getRegisteredEmployees()
        {
            List<Employee> newList = new List<Employee>();
            foreach(KeyValuePair<int, Employee> emp in RegisteredEmployees)
            {
                newList.Add(emp.Value);
            }
            return newList;
        }

        public int getNumber()
        {
            return number;
        }

        public string getName()
        {
            return name;
        }

        public string getSurname()
        {
            return surname;
        }
    }
}
