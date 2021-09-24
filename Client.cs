using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Pizzaria
{
    class Client
    {
        private string name;
        private string surname;
        private string phoneNumber;
        private DateTime firstOrderDate;

        public Client(string n, string sn, string pn)
        {
            this.name = n;
            this.surname = sn;
            this.phoneNumber = pn;
            this.firstOrderDate = DateTime.Now;
        }

        public string getName()
        {
            return name;
        }
    }
}
