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
    /// Logique d'interaction pour Create_Client.xaml
    /// </summary>
    public partial class Create_Client : Window
    {
        public Create_Client()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool InputsNotNull()
        {
            foreach(TextBox tb in TextBoxGrid.Children)
            {
                if(tb.Text == "")
                {
                    return false;
                }
            }

            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (InputsNotNull())
            {
                try
                {
                    new Client(NameTextBox.Text, SurnameTextBox.Text, TelTextBox.Text, new Address(Int32.Parse(StreetNumberTextBox.Text), AddressTextBox.Text, Int32.Parse(StreetNumberTextBox.Text), CityTextBox.Text));
                    MessageBox.Show("Nouveau client créer !");
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Une erreur est survenu, veuillez vérifier chaque champs");
                }
            }
            else
            {
                MessageBox.Show("Un ou plusieurs champs ne sont vides. Veuillez les remplir");
            }
        }
    }
}
