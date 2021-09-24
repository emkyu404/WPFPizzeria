using System;

namespace Projet_Pizzaria
{
    enum pizzaType
    {
        Margharita,
        Napoletana,
        Bufala,
        Vegan,
        Parmegiana,
        Formaggi
    }

    enum pizzaSize
    {
        small,
        medium,
        huge
    }

    class Pizza : Item
    {
        pizzaSize size;
        pizzaType ptype;

        public Pizza(pizzaSize size, pizzaType ptype, float price) : base (price)
        {
            this.size = size;
            this.ptype = ptype;
            this.price = price;
        }

    }
}