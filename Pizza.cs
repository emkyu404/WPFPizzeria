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
            float result;
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

        public static PizzaSize getSizeByString(String text)
        {
            switch (text)
            {
                case "medium": return PizzaSize.medium;
                case "huge": return  PizzaSize.huge; 
                case "small": return PizzaSize.small;
                default: throw new Exception();
            }
        }

        public static PizzaType getTypeByString(String text)
        {
            switch (text)
            {
                case "Bufala": return PizzaType.Bufala;
                case "Formaggi": return PizzaType.Formaggi;
                case "Margharita": return PizzaType.Margharita;
                case "Napoletana": return PizzaType.Napoletana;
                case "Parmegiana": return PizzaType.Parmegiana;
                case "Vegan": return PizzaType.Vegan; break;
                default: throw new Exception();
            }
        }

        public override String ToString()
        {
            return this.ptype.ToString() + " " + this.size.ToString();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Pizza p = (Pizza) obj;
                return (p.ptype == this.ptype) && (p.size == this.size);
            }
        }

        public override string getType()
        {
            return "Pizza";
        }
    }
}
