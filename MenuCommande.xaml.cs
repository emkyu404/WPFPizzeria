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
        public MenuCommande()
        {
            InitializeComponent();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AjoutItems ai = new AjoutItems();
            ai.Show();
        }
    }
}
