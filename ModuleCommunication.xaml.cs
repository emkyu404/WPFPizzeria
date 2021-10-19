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
                cbi.Content = c.PhoneNumber;
                ClientComboBox.Items.Add(cbi);
            }
        }

        public void NewClientMessage(string phoneNumber, string msg)
        {
            try
            {
                if (phoneNumber == ClientComboBox.Text)
                {
                    ClientTextBlock.Text += msg;
                    ClientTextBlock.Text += Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                ClientTextBlock.Text += "Erreur : " + ex;
                ClientTextBlock.Text += Environment.NewLine;
            }
        }

        public void NewCommisMessage(string empId, string msg)
        {
            try
            {
                if (empId == CommisComboBox.Text)
                {
                    CommisTextBlock.Text += msg;
                    CommisTextBlock.Text += Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                CommisTextBlock.Text += "Erreur : " + ex;
                CommisTextBlock.Text += Environment.NewLine;
            }
        }

        public void NewDeliveryManMessage(string empId, string msg)
        {
            try
            {
                if (empId == DeliveryManComboBox.Text)
                {
                    DeliveryManTextBlock.Text += msg;
                    DeliveryManTextBlock.Text += Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                DeliveryManTextBlock.Text += "Erreur : " + ex;
                DeliveryManTextBlock.Text += Environment.NewLine;
            }
        }

        public void NewKitchenMessage(string msg)
        {
            KitchenTextBlock.Text += msg;
            KitchenTextBlock.Text += Environment.NewLine;
        }

        private void CommisComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommisTextBlock.Text = "";
        }

        private void ClientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClientTextBlock.Text = "";
        }

        private void DeliveryManComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DeliveryManTextBlock.Text = "";
        }
    }
}
