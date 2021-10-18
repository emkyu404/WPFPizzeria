using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Pizzaria
{
    public abstract class Item
    {
        public float price;

        public Item(float price)
        {
            this.price = price;
        }

        public override abstract String ToString();
        public override abstract bool Equals(object obj);

        public abstract String getType();
        public float getPrice()
        {
            return this.price;
        }
    }
}
