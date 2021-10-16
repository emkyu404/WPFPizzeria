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
    /// Logique d'interaction pour CommandeInfo.xaml
    /// </summary>
    public partial class CommandeInfo : Window
    {
        Order currentOrder;
        public CommandeInfo()
        {
            InitializeComponent();
        }

        private void GetOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentOrder = Order.getOrderByNum(Int32.Parse(OrderNumberInput.Text));
                RefreshAllInfo();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Une erreur est survenue. " + ex.Message);
                OrderNumberInput.Text = "";
                currentOrder = null;
            }
        }

        private void RefreshAllInfo()
        {
            OrderDateLabel.Content = currentOrder.getDate().ToString();
            OrderPriceLabel.Content = currentOrder.getTotalPrice().ToString();
            OrderStateLabel.Content = currentOrder.getState().ToString();

            foreach(Item i in currentOrder.getItems())
            {
                OrderTextBlock.Text += i.ToString();
                OrderTextBlock.Text += Environment.NewLine;
            }
        }
    }
}
