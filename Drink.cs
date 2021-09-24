using System;
namespace Projet_Pizzaria{

    enum drinkType{
        juice,
        coke,
        lemonade,
        beer,
        iceTea
    }

    public class Drink : Item{
        drinkType dtype;

        public Pizza(drinkType dtype, float price){
            this.dtype = dtype;
            this.price = price;
        }

    }
}