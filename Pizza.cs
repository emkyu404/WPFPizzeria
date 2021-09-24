using System;

<<<<<<< HEAD
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
=======
namespace Projet_Pizzaria{

    enum pizzaType{
        Margharita,
        Napoletana,
        Bufala,
        Vegan,
        Parmegiana,
        Formaggi 
    }

    enum pizzaSize{
        small,
        medium,
        huge
    }

    public class Pizza : Item{
        pizzaSize size;
        pizzaType ptype;

        public Pizza(pizzaSize size, pizzaType ptype, float price){
>>>>>>> 1adb1b226a6662f0c22306c4198b3e0659296376
            this.size = size;
            this.ptype = ptype;
            this.price = price;
        }

    }
}