using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new Kitchen();
        }

        private void Button_Command_Click(object sender, RoutedEventArgs e)
        {
            OrderManagementSelection oms = new OrderManagementSelection();
            oms.Show();
        }

        private void Button_Client_Effectif_Click(object sender, RoutedEventArgs e)
        {
            Window wce = new MenuClientEmployee();
            wce.Show();
        }

        private void Button_Communication_Click(object sender, RoutedEventArgs e)
        {
            ModuleCommunication mc = new ModuleCommunication();
            mc.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ModuleStatistique ms = new ModuleStatistique();
            ms.Show();
        }
    }
}
