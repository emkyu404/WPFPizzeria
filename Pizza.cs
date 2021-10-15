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
        const float basePizzaPrice = 5f;

        public Pizza(PizzaSize size, PizzaType ptype, float price) : base(price)
        {
            this.size = size;
            this.ptype = ptype;
            this.price = price;
        }

        public static float setPizzaPrice(PizzaSize s, PizzaType t)
        {
            float sizePrice, typePrice, result;
            result = basePizzaPrice;
            switch (s)
            {
                case PizzaSize.huge: result += 3f;break;
                case PizzaSize.medium: result += 2f; break;
                case PizzaSize.small: break;
            }

            switch (t)
            {
                case PizzaType.Bufala: result += 1f; break;
                case PizzaType.Parmegiana: result += 1f; break;
                default: break;
            }

            return result;
        }

    }
}
