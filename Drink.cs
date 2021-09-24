using System;
namespace Projet_Pizzaria{

<<<<<<< HEAD
namespace Projet_Pizzaria
{
    enum drinkType
    {
=======
    enum drinkType{
>>>>>>> 1adb1b226a6662f0c22306c4198b3e0659296376
        juice,
        coke,
        lemonade,
        beer,
        iceTea
    }

<<<<<<< HEAD
    class Drink : Item
    {
        public drinkType dtype;

        public Drink(drinkType dtype, float price) : base(price)
        {
=======
    public class Drink : Item{
        drinkType dtype;

        public Pizza(drinkType dtype, float price){
>>>>>>> 1adb1b226a6662f0c22306c4198b3e0659296376
            this.dtype = dtype;
            this.price = price;
        }

    }
}