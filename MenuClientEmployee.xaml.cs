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
    /// Logique d'interaction pour MenuClientWorkforce.xaml
    /// </summary>
    public partial class MenuClientEmployee : Window
    {
        public MenuClientEmployee()
        {
            InitializeComponent();
        }

        private void Button_Client_Click(object sender, RoutedEventArgs e)
        {
            Window wc = new WindowClient();
            wc.Show();

            Close();
        }

        private void Button_Employee_Click(object sender, RoutedEventArgs e)
        {
            Window ww = new WindowEmployee();
            ww.Show();

            Close();
        }

        private void Button_Return_Click(object sender, RoutedEventArgs e)
        {
            Window w = new MainWindow();
            w.Show();

            Close();
        }
    }
}
