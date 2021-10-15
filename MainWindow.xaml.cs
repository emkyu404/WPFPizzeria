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

            Init();
        }

        private void Init()
        {
            // initialisation de la liste de clients
            new Client("Antoine", "azdefzgrethr", "0114564367", new Address(66, "Rue Camille Desmoulins", 6454230, "aachan"));
            new Client("dfghlhh", "qsdfsgd", "0616846691", new Address(896, "Rue Camille Desmoulins", 54230, "Cachan"));
            new Client("qsdfgkjhljmk", "sfdghsd", "0547896516846691", new Address(96, "Rue Camille Desmoulins", 14230, "hachan"));

            // initialisation de la liste d'employés
            new Commis(1, "Antoine", "CHENG", new Address(66, "Rue Camille Desmoulins", 6454230, "Cachan"));
            new Commis(2, "aezegtrh", "retgrhyte", new Address(98, "Rue Camille Desmoulins", 6454230, "aachan"));
            new DeliveryMan(1, "thegz", "sfd", new Address(1, "Rue Camille Desmoulins", 6454230, "Bachan"));
        }

        private void Button_Command_Click(object sender, RoutedEventArgs e)
        {
            MenuCommande mcmd = new MenuCommande();
            mcmd.Show();
        }

        private void Button_Client_Effectif_Click(object sender, RoutedEventArgs e)
        {
            Window wce = new MenuClientEmployee();
            wce.Show();
        }
    }
}
