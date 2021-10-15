using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Projet_Pizzaria
{
    public class Client
    {
        private string name;
        private string surname;
        private string phoneNumber;
        private DateTime firstOrderDate;
        private Address address;

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
        public string PhoneNumber
        {
            get => phoneNumber;
            set => phoneNumber = value;
        }
        public DateTime firstorderdate
        {
            get => firstorderdate;
        }
        

        private static List<Client> RegisteredClient = new List<Client>()
        {
        new Client("Antoine", "azdefzgrethr", "0114564367", new Address(66, "Rue Camille Desmoulins", 6454230, "aachan")),
        new Client("dfghlhh", "qsdfsgd", "0616846691", new Address(896, "Rue Camille Desmoulins", 54230, "Cachan")),
        new Client("qsdfgkjhljmk", "sfdghsd", "0547896516846691", new Address(96, "Rue Camille Desmoulins", 14230, "hachan"))
        };

        public Client(string name, string surname, string phoneNumber, Address address)
        {
            this.name = name;
            this.surname = surname;
            this.phoneNumber = phoneNumber;
            this.firstOrderDate = DateTime.Now;
            this.address = address;

            //RegisteredClient.Add(this);
        }


        public string Address => address.Number + " " + address.StreetName;

        public int ZipCode => address.ZipCode;

        public string City => address.City;

        //public Client getClientByPhoneNumber(string pn)
        //{
        //    Client c = RegisteredClient.FirstOrDefault(cl => cl.getPhoneNumber() == pn);
        //    return c;
        //}

        public static List<Client> getRegisteredClient()
        {
            return RegisteredClient;
        }
    }
}
