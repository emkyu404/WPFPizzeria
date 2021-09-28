using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Projet_Pizzaria
{
    class Client
    {
        private string name;
        private string surname;
        private string phoneNumber;
        private DateTime firstOrderDate;
        private string address;

        private static List<Client> RegisteredClient = new List<Client>();

        public Client(string n, string sn, string pn, string adr)
        {
            this.name = n;
            this.surname = sn;
            this.phoneNumber = pn;
            this.firstOrderDate = DateTime.Now;
            this.address = adr;

            RegisteredClient.Add(this);
        }

        public string getName()
        {
            return name;
        }

        public string getPhoneNumber()
        {
            return phoneNumber;
        }

        public Client getClientByPhoneNumber(string pn)
        {
            Client c = RegisteredClient.FirstOrDefault(cl => cl.getPhoneNumber() == pn);
            return c;
        }

        public static List<Client> getRegisteredClient()
        {
            return RegisteredClient;
        }
    }
}
