using System;

namespace Projet_Pizzaria
{
    enum drinkType
    {
        juice,
        coke,
        lemonade,
        beer,
        iceTea
    }

    class Drink : Item
    {
        public drinkType dtype;

        public Drink(drinkType dtype, float price) : base(price)
        {
            this.dtype = dtype;
            this.price = price;
        }

    }
}