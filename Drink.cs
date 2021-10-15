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
            this.price = Drink.setDrinkPrice(dtype);
        }

        public override String ToString()
        {
            return this.dtype.ToString();
        }

        public static drinkType getTypeByString(string text)
        {
            switch (text)
            {
                case "juice": return drinkType.juice;
                case "coke": return drinkType.coke;
                case "lemonade": return drinkType.lemonade;
                case "beer": return drinkType.beer;
                case "iceTea": return drinkType.iceTea;
                default: throw new Exception();
            }
        }

        public static float setDrinkPrice(drinkType t)
        {
            switch (t)
            {
                case drinkType.juice: return 1f ;
                case drinkType.coke: return 2f ;
                case drinkType.lemonade: return 1f ;
                case drinkType.beer: return 3f ;
                case drinkType.iceTea: return 2f;
                default: throw new Exception();
            }
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Drink d = (Drink)obj;
                return d.dtype == this.dtype;
            }
        }

    }
}