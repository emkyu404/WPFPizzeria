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

        private static List<Employee> RegisteredEmployees = new List<Employee>()
        {
        new Commis(1, "Antoine", "CHENG", new Address(66, "Rue Camille Desmoulins", 6454230, "Cachan")),
        new Commis(2, "aezegtrh", "retgrhyte", new Address(98, "Rue Camille Desmoulins", 6454230, "aachan")),
        new DeliveryMan(1, "thegz", "sfd", new Address(1, "Rue Camille Desmoulins", 6454230, "Bachan"))
        };
        

        public Employee(int number, string name, string surname, Address address)
        {
            this.number = number;
            this.name = name;
            this.surname = surname; 
            this.address = address;
        }

        public string Address => address.Number + " " + address.StreetName;

        public int ZipCode => address.ZipCode;

        public string City => address.City;

        public static List<Employee> getRegisteredEmployees()
        {
            return RegisteredEmployees;
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
