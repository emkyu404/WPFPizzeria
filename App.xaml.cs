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
            new Client("Antoine", "CHENG", "0101010101", new Address(66, "Rue Camille Desmoulins", 94230, "Cachan"));
            new Client("Minh-Quan", "BUI", "0202020202", new Address(30, "Av. de la République", 94800, "Villejuif"));
            new Client("Aurélie", "ARNAUD", "0303030303", new Address(143, "Av. de Versailles", 75016, "Paris"));

            // initialisation de la liste d'employés
            new Commis("Alex", "HUGO", new Address(89, "Av. Emile Zola", 75015, "Paris"));
            new Commis("Luc", "BESSON", new Address(20, "Rue du Théâtre", 75015, "Paris"));
            new DeliveryMan("Jean", "DUJARDIN", new Address(1, "Av. Victor Hugo", 75116, "Paris"));
        }
    }
}
