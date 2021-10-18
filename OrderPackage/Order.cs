using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Pizzaria
{
    public class Order
    {
        private int number;
        private DateTime date;
        private string clientName;
        private Client client;
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
            this.client = c;
            this.clientName = c.Name;
            this.orderState = OrderState.preparing;
            Order.OrderList.Add(this.number,this);
        }

        public static Order getOrderByNum(int n)
        {
            return OrderList[n];
        }

        public int getNumber()
        {
            return this.number;
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

        public Client getClient()
        {
            return client;
        }

        public static List<Order> getAllOrderByClient(Client c)
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

        public void isReady()
        {
            this.orderState = OrderState.readyToShip;
        }

        public void isShipping()
        {
            this.orderState = OrderState.shipping;
        }

        public void isPaid()
        {
            this.orderState = OrderState.paid;
        }

        public static float getAverageAllOrders()
        {
            if (Order.OrderList.Count <= 0)
            {
                return 0;
            }
            else
            {
                float result = 0;
                foreach (KeyValuePair<int, Order> e in OrderList)
                {
                    result += e.Value.getTotalPrice();
                }
                return result / OrderList.Count;
            }
        }

        public static float getAveragePerClient()
        {
            if (Order.OrderList.Count <= 0)
            {
                return 0;
            }
            else
            {
                Dictionary<Client, List<Order>> cl = new Dictionary<Client, List<Order>>();
                float result = 0;
                foreach (KeyValuePair<int, Order> e in OrderList)
                {
                    if (!cl.ContainsKey(e.Value.getClient()))
                    {
                        cl.Add(e.Value.getClient(), new List<Order>());
                        cl[e.Value.getClient()].Add(e.Value);
                    }
                    else
                    {
                        cl[e.Value.getClient()].Add(e.Value);
                    }
                }

                foreach(KeyValuePair<Client, List<Order>> e in cl)
                {
                    foreach(Order o in e.Value)
                    {
                        result += o.getTotalPrice();
                    }
                }
                return result / cl.Count;
            }
            
        }
    }

    public enum OrderState
    {
        preparing,
        readyToShip,
        shipping,
        paid
    }
}
