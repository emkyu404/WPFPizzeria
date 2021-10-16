using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Projet_Pizzaria
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // here you take control
            Init();
        }

        private void Init()
        {
            // initialisation de la liste de clients
            new Client("Antoine", "azdefzgrethr", "0114564367", new Address(66, "Rue Camille Desmoulins", 6454230, "aachan"));
            new Client("dfghlhh", "qsdfsgd", "0616846691", new Address(896, "Rue Camille Desmoulins", 54230, "Cachan"));
            new Client("qsdfgkjhljmk", "sfdghsd", "0547896516846691", new Address(96, "Rue Camille Desmoulins", 14230, "hachan"));

            // initialisation de la liste d'employés
            new Commis("Antoine", "CHENG", new Address(66, "Rue Camille Desmoulins", 6454230, "Cachan"));
            new Commis("aezegtrh", "retgrhyte", new Address(98, "Rue Camille Desmoulins", 6454230, "aachan"));
            new DeliveryMan("thegz", "sfd", new Address(1, "Rue Camille Desmoulins", 6454230, "Bachan"));
        }
    }
}
