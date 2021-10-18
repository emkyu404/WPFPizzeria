﻿using System;
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
    /// Logique d'interaction pour ModuleStatistique.xaml
    /// </summary>
    public partial class ModuleStatistique : Window
    {
        private Commis currentCommis;
        private DeliveryMan currentDM;
        public ModuleStatistique()
        {
            InitializeComponent();
            InitializeComboBox();
            SetAveragePerClient();
            SetAveragePerOrder();
        }

        private void InitializeComboBox()
        {
            foreach (KeyValuePair<int, Employee> e in Employee.RegisteredEmployees)
            {
                if (e.Value.getType() == "Commis")
                {
                    ComboBoxItem cbi = new ComboBoxItem();
                    cbi.Content = e.Value.getNumber();
                    CommisComboBox.Items.Add(cbi);
                }
                else if (e.Value.getType() == "Livreur")
                {
                    ComboBoxItem cbi = new ComboBoxItem();
                    cbi.Content = e.Value.getNumber();
                    DeliveryManComboBox.Items.Add(cbi);
                }
            }
        }

        private void CommisButton_Click(object sender, RoutedEventArgs e)
        {
            currentCommis = (Commis)Employee.RegisteredEmployees[Int32.Parse(CommisComboBox.Text)];
            SetCommisInfo();
        }

        private void SetCommisInfo()
        {
            if(currentCommis != null)
            {
                NbOrderInput.Content = currentCommis.Orders.Count;
            }
            else
            {
                NbOrderInput.Content = 0.ToString();
            }
        }

        private void DeliveryManButton_Click(object sender, RoutedEventArgs e)
        {
            currentDM = (DeliveryMan)Employee.RegisteredEmployees[Int32.Parse(CommisComboBox.Text)];
            SetDeliveryManInfo();
        }

        private void SetDeliveryManInfo()
        {
            if (currentDM != null)
            {
                NbOrderInput.Content = currentDM.Orders.Count;
            }
            else
            {
                NbOrderInput.Content = 0.ToString();
            }
        }

        private void SetAveragePerOrder()
        {
            AveragePriceOrders.Content = Order.getAverageAllOrders() + "€";
        }

        private void SetAveragePerClient()
        {
            AveragePricePerClient.Content = Order.getAveragePerClient() + "€";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetAveragePerClient();
            SetAveragePerOrder();
            SetDeliveryManInfo();
            SetCommisInfo();
        }
    }
}
