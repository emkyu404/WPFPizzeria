using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour MenuCommande.xaml
    /// </summary>
    public partial class MenuCommande : Window
    {
        private Client currentClient;
        private List<Item> currentItemList = new List<Item>();
        public MenuCommande()
        {
            InitializeComponent();
            RefreshOrderTotalPrice();
            RefreshItemList();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ClientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Create_Client cc = new Create_Client();
            cc.Show();
        }

        private void TelTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Client c = Client.getClientByPhoneNumber(TelTextBox.Text);
                if (c == null) throw new Exception();

                currentClient = c;
                ClientNameLabel.Content = currentClient.Surname + " " +currentClient.Name;

            }catch(Exception ex)
            {
                MessageBox.Show("Aucun client enregistré ne correspond au numéro de téléphone");
                TelTextBox.Text = "";
            }
        }

        private void ManageItems_Click(object sender, RoutedEventArgs e)
        {
            AjoutItems ai = new AjoutItems(currentItemList, this);

            ai.Show();
        }

        public void SetItemList(List<Item> list)
        {
            currentItemList = list;
            RefreshItemList();
            RefreshOrderTotalPrice();
        }

        private void RefreshItemList()
        {
            ItemListTextBlock.Text = "";
            foreach (Item i in currentItemList)
            {
                ItemListTextBlock.Text += i.ToString();
                ItemListTextBlock.Text += Environment.NewLine;
            }
        }

        private void RefreshOrderTotalPrice()
        {
            float result = 0;
            foreach(Item i in currentItemList)
            {
                result += i.getPrice();
            }
            OrderTotalPriceLabel.Content = result.ToString() + "€";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentClient == null)
                {
                    MessageBox.Show("Une erreur est survenu, vérifier qu'un Client a été affecté à la commande");
                }
                else if (currentItemList.Count <= 0)
                {
                    MessageBox.Show("La commande est vide, veuiller ajouter des items");
                }
                else if (!OrderContainsPizza())
                {
                    MessageBox.Show("La commande ne contient pas de pizza");
                }
                else
                {
                    Order od = new Order(currentClient, currentItemList);
                    MessageBox.Show("Commande créer ! N° de commande : " + Order.numberInc);
                    OrderManagementSelection oms = new OrderManagementSelection();
                    oms.Show();
                    this.Close();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Une erreur est survenu, vérifier qu'un Client a été affecté à la commande");
            }
        }

        private bool OrderContainsPizza()
        {
            foreach(Item i in currentItemList)
            {
                if(i.getType() == "Pizza")
                {
                    return true;
                }
            }
            return false;
        }
        
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            OrderManagementSelection oms = new OrderManagementSelection();
            oms.Show();
            this.Close();
        }
    }
}
