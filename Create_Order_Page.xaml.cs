using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projet_Pizzaria
{
    /// <summary>
    /// Logique d'interaction pour Create_Order_Page.xaml
    /// </summary>
    public partial class Create_Order_Page : Page
    {
        private Client currentClient;
        public Create_Order_Page()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            registerClientPnl.Visibility = Visibility.Collapsed;
            findClientPnl.Visibility = Visibility.Collapsed;
        }

        private void alreadyRegisteredClientClick(object sender, RoutedEventArgs e)
        {
            findClientPnl.Visibility = Visibility.Visible;
            registerClientPnl.Visibility = Visibility.Collapsed;
            QuestionBoxPnl.Visibility = Visibility.Collapsed;
        }

        private void firstClientClick(object sender, RoutedEventArgs e)
        {
            registerClientPnl.Visibility = Visibility.Visible;
            findClientPnl.Visibility = Visibility.Collapsed;
            QuestionBoxPnl.Visibility = Visibility.Collapsed;
        }

        private void confirmRegisterClick(object sender, RoutedEventArgs e)
        {
            currentClient = new Client(tbName.Text, tbSurname.Text, tbPhoneNumber.Text, tbAddress.Text);
            tbName.Text = "";
            tbSurname.Text = "";
            tbPhoneNumber.Text = "";
            tbAddress.Text = "";

            updateClientInfo();
        }

        private void updateClientInfo()
        {
            ClientAddress.Text = currentClient.getAddress();
            ClientName.Text = currentClient.getName();
            ClientPN.Text = currentClient.getPhoneNumber();
        }
    }
}
