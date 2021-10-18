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
        public DateTime FirstOrderDate
        {
            get => firstOrderDate;
        }
        
        private static List<Client> RegisteredClient = new List<Client>();
        /* ça bug si tu fais l'initialisation ici, créer une méthode statique que tu appelle à l'ouverture de mainwindow à la limite
        {
        new Client("Antoine", "azdefzgrethr", "0114564367", new Address(66, "Rue Camille Desmoulins", 6454230, "aachan")),
        new Client("dfghlhh", "qsdfsgd", "0616846691", new Address(896, "Rue Camille Desmoulins", 54230, "Cachan")),
        new Client("qsdfgkjhljmk", "sfdghsd", "0547896516846691", new Address(96, "Rue Camille Desmoulins", 14230, "hachan"))
        };*/

        public Client(string name, string surname, string phoneNumber, Address address)
        {
            this.name = name;
            this.surname = surname;
            this.phoneNumber = phoneNumber;
            firstOrderDate = DateTime.Now;
            this.address = address;
            
            RegisteredClient.Add(this);
        }


        public string Address => address.Number + " " + address.StreetName;

        public int ZipCode => address.ZipCode;

        public string City => address.City;

        public double Total
        {
            get => getTotal(this);
        }
        public double getTotal(Client c)
        {
            List<Order> orders = new List<Order>();
            orders = Order.getAllOrderByClient(c);
            double total = 0;
            foreach(Order o in orders)
            {
                total += o.getTotalPrice();
            }
            return total;
        }

        public static Client getClientByPhoneNumber(string pn)
        {
            Client c = RegisteredClient.FirstOrDefault(cl => cl.PhoneNumber == pn);
            return c;
        }

        public static List<Client> getRegisteredClient()
        {
            return RegisteredClient;
        }
    }
}
