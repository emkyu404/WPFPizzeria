using System;

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
        this.size = size;
        this.ptype = ptype;
        this.price = price;
    }

}