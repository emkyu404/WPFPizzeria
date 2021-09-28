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
    /// Logique d'interaction pour MenuClientEffectif.xaml
    /// </summary>
    public partial class MenuClientEffectif : Window
    {
        public MenuClientEffectif()
        {
            InitializeComponent();
        }

        private void Button_Client_Click(object sender, RoutedEventArgs e)
        {
            WindowClient wc = new WindowClient();
            wc.Show();
        }

        private void Button_Effectif_Click(object sender, RoutedEventArgs e)
        {
            WindowEffectif we = new WindowEffectif();
            we.Show();
        }
    }
}
