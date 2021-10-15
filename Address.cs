using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Pizzaria
{
    public class Address
    {
        private int number;
        private string streetName;
        private int zipCode;
        private string city;

        public int Number
        {
            get => number;
            set => number = value;
        }
        public string StreetName
        {
            get => streetName;
            set => streetName = value;
        }
        public int ZipCode
        {
            get => zipCode;
            set => zipCode = value;
        }
        public string City
        {
            get => city;
            set => city = value;
        }

        public Address(int number, string streetName, int zipCode, string city)
        {
            this.number = number;
            this.streetName = streetName;
            this.zipCode = zipCode;
            this.city = city;
        }
    }
}
