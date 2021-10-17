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
    /// Logique d'interaction pour ModuleCommunication.xaml
    /// </summary>
    public partial class ModuleCommunication : Window
    {

        public ModuleCommunication()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            // initialisation des combo box employee
            foreach (KeyValuePair<int, Employee> e in Employee.RegisteredEmployees)
            {
                if (e.Value.getType() == "Commis")
                {
                    ComboBoxItem cbi = new ComboBoxItem();
                    cbi.Content = e.Value.getNumber();
                    CommisComboBox.Items.Add(cbi);
                }
                else if(e.Value.getType() == "Livreur")
                {
                    ComboBoxItem cbi = new ComboBoxItem();
                    cbi.Content = e.Value.getNumber();
                    DeliveryManComboBox.Items.Add(cbi);
                }
            }

            // initialisation des combo box client
            foreach(Client c in Client.getRegisteredClient())
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = c.Address;
                ClientComboBox.Items.Add(cbi);
            }
        }
    }
}
