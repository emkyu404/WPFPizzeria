using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projet_Pizzaria
{
    /// <summary>
    /// Logique d'interaction pour AjoutItems.xaml
    /// </summary>
    public partial class AjoutItems : Window
    {
        Dictionary<Item, int> ItemsList = new Dictionary<Item, int>(new ItemComparer());
        public AjoutItems()
        {
            InitializeComponent();
        }

        private void AddPizzaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PizzaType type = Pizza.getTypeByString(PizzaTypeComboBox.Text);
                PizzaSize size = Pizza.getSizeByString(PizzaSizeComboBox.Text);
                Pizza pizza = new Pizza(size,type, Pizza.setPizzaPrice(size, type));
                if (ItemsList.ContainsKey(pizza))
                {
                    ItemsList[pizza]++;
                }
                else
                {
                    ItemsList.Add(pizza, 1);
                }
                
                RefreshItemList();

            }catch(Exception ex)
            {
                MessageBox.Show("Erreur");
            }
        }

        private void RefreshItemList()
        {
            ItemListTextBlock.Text = "";
            foreach(KeyValuePair<Item,int> entry in ItemsList)
            {
                ItemListTextBlock.Text += entry.Value.ToString() + "x " + entry.Key.ToString();
                ItemListTextBlock.Text += Environment.NewLine;
            }
        }

        private void AddDrinkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                drinkType type = Drink.getTypeByString(DrinkTypeComboBox.Text);
                Drink drink = new Drink(type, Drink.setDrinkPrice(type));
                if (ItemsList.ContainsKey(drink))
                {
                    ItemsList[drink]++;
                }
                else
                {
                    ItemsList.Add(drink, 1);
                }
                RefreshItemList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur");
            }
        }
    }
}
