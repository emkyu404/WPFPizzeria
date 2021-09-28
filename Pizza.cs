using System;

namespace Projet_Pizzaria { 
    enum PizzaType
    {
        Margharita,
        Napoletana,
        Bufala,
        Vegan,
        Parmegiana,
        Formaggi 
    }

    enum PizzaSize
    {
        small,
        medium,
        huge
    }

    class Pizza : Item
    {
        PizzaSize size;
        PizzaType ptype;

        public Pizza(PizzaSize size, PizzaType ptype, float price) : base (price)
        {
            this.size = size;
            this.ptype = ptype;
            this.price = price;
        }

    }
}
