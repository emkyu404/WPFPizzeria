using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Pizzaria
{
    class Order
    {
        private int number;
        private DateTime date;
        private string clientName;
        private bool paid;
        private List<Item> items;
        private OrderState orderState;

        /* Listes provisoires en attendant de gérer la communication */
        public static Dictionary<int, Order> OrderList = new Dictionary<int,Order>();

        public static int numberInc = 0;


        public Order(Client c, List<Item> l)
        {
            this.items = l;
            this.number = ++numberInc;
            this.date = DateTime.Now;
            this.clientName = c.Name;
            this.orderState = OrderState.preparing;
            Order.OrderList.Add(this.number,this);
        }

        public static Order getOrderByNum(int n)
        {
            return OrderList[n];
        }

        public List<Item> getItems()
        {
            return items;
        }

        public OrderState getState()
        {
            return orderState;
        }

        public DateTime getDate()
        {
            return date;
        }

        public float getTotalPrice()
        {
            float result = 0;
            foreach(Item i in items)
            {
                result += i.getPrice();
            }
            return result;
        }

        public string getClientName()
        {
            return clientName;
        }

        // faiblesse : Les clients ne peuvent pas porter le même nom
        public List<Order> getallOrderByClient(Client c)
        {
            List<Order> newList = new List<Order>();
            foreach(KeyValuePair<int,Order> order in Order.OrderList)
            {
                if(order.Value.getClientName() == c.Name)
                {
                    newList.Add(order.Value);
                }
            }
            return newList;
        }
    }

    public enum OrderState
    {
        preparing,
        shipping,
        paid
    }
}
