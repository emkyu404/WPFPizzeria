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
    /// Logique d'interaction pour OrderManagementSelection.xaml
    /// </summary>
    public partial class OrderManagementSelection : Window
    {
        public OrderManagementSelection()
        {
            InitializeComponent();
        }

        private void OpenCreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            MenuCommande mc = new MenuCommande();
            mc.Show();
            this.Close();
        }

        private void OpenManageOrderButton_Click(object sender, RoutedEventArgs e)
        {
            CommandeInfo ci = new CommandeInfo();
            ci.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
