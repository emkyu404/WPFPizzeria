using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Pizzaria
{
    class Order
    {
        private int number;
        private static int numberInc = 0;
        private DateTime date;
        private string clientName;
        private bool paid;
        public List<Item> items;

        /* Listes provisoires en attendant de gérer la communication */
        public static List<Order> PendingOrder = new List<Order>(); // Commande en cours de traitement (préparation)
        public static List<Order> ReadyToShipOrder = new List<Order>(); // Commande prête à la livraison
        public static List<Order> DeliveredOrder = new List<Order>(); // Commande livré
        public static List<Order> PaidOrder = new List<Order>(); //

        public Order(Client c, List<Item> l)
        {
            this.items = l;
            this.number = numberInc++;
            this.date = DateTime.Now;
            this.clientName = c.Name;
            Order.PendingOrder.Add(this);
        }

    }
}
