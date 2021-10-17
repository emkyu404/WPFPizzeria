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
    /// Logique d'interaction pour CommandeInfo.xaml
    /// </summary>
    public partial class CommandeInfo : Window
    {
        Order currentOrder;
        DeliveryMan currentDM;
        public CommandeInfo()
        {
            InitializeComponent();
            InitializeDeliveryManComboBox();

            SimReadyButton.IsEnabled = false;
            SimShipping_Button.IsEnabled = false;
            SimPaid_Button.IsEnabled = false;

        }

        private void InitializeDeliveryManComboBox()
        {
            // initialisation des combo box employee
            foreach (KeyValuePair<int, Employee> e in Employee.RegisteredEmployees)
            {
                if (e.Value.getType() == "Livreur")
                {
                    ComboBoxItem cbi = new ComboBoxItem();
                    cbi.Content = e.Value.getNumber();
                    DeliveryManComboBox.Items.Add(cbi);
                }
            }
        }

        private void GetOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentOrder = Order.getOrderByNum(Int32.Parse(OrderNumberInput.Text));
                RefreshAllInfo();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Une erreur est survenue. " + ex.Message);
                OrderNumberInput.Text = "";
                currentOrder = null;
            }
        }

        private void RefreshAllInfo()
        {
            OrderDateLabel.Content = currentOrder.getDate().ToString();
            OrderPriceLabel.Content = currentOrder.getTotalPrice().ToString() + "€";
            OrderStateLabel.Content = currentOrder.getState().ToString();

            foreach(Item i in currentOrder.getItems())
            {
                OrderTextBlock.Text += i.ToString();
                OrderTextBlock.Text += Environment.NewLine;
            }
            HandleButtons();

        }

        private void HandleButtons()
        {
            if(currentOrder.getState() == OrderState.preparing)
            {
                SimReadyButton.IsEnabled = true;
                SimPaid_Button.IsEnabled = false;
                SimShipping_Button.IsEnabled = false;
            }else if (currentOrder.getState() == OrderState.readyToShip)
            {
                SimReadyButton.IsEnabled = false;
                SimPaid_Button.IsEnabled = false;
                SimShipping_Button.IsEnabled = true;
            }else if (currentOrder.getState() == OrderState.shipping)
            {
                SimReadyButton.IsEnabled = false;
                SimPaid_Button.IsEnabled = true;
                SimShipping_Button.IsEnabled = false;
            }
            else
            {
                SimReadyButton.IsEnabled = false;
                SimPaid_Button.IsEnabled = false;
                SimShipping_Button.IsEnabled = false;
            }
        }

        private async void SimReadyButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentOrder == null)
            {
                MessageBox.Show("Veuillez choisir une commande avant de réaliser la simulation");
            }
            else
            {
                NotifyCommunicationModuleTookCharge();
                await Kitchen.getInstance().prepareOrderAsync(currentOrder);
                RefreshAllInfo();
                NotifyCommunicationModuleReady();
            }
        }

        private async void SimShipping_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentDM = (DeliveryMan) Employee.RegisteredEmployees[Int32.Parse(DeliveryManComboBox.Text)];
                NotifyCommunicationModuleShipping();
                await currentDM.shipOrderAsync(currentOrder);
                RefreshAllInfo();
                NotifyCommunicationModuleShipped();
            }catch(Exception ex)
            {
                MessageBox.Show("Veuillez choisir un livreur pour la simulation");
            }
        }

        private void NotifyCommunicationModuleShipping()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.Title == "Module Communication")
                {
                    ModuleCommunication mc = (ModuleCommunication)item;
                    mc.NewClientMessage(currentOrder.getClient().PhoneNumber, "Votre commande (N°" + currentOrder.getNumber() + ") est en cours de livraison...");
                    mc.NewDeliveryManMessage(currentDM.Number.ToString(),"Livraison de la commande n°" + currentOrder.getNumber() + "en cours ...");
                }
            }
        }

        private void NotifyCommunicationModuleShipped()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.Title == "Module Communication")
                {
                    ModuleCommunication mc = (ModuleCommunication)item;
                    mc.NewClientMessage(currentOrder.getClient().PhoneNumber, "Votre commande (N°" + currentOrder.getNumber() + ") est en bas de chez vous !");
                    mc.NewDeliveryManMessage(currentDM.Number.ToString(), "Livraison de la commande n°" + currentOrder.getNumber() + " effectuée.");
                }
            }
        }

        private void NotifyCommunicationModuleTookCharge()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.Title == "Module Communication")
                {
                    ModuleCommunication mc = (ModuleCommunication)item;
                    mc.NewClientMessage(currentOrder.getClient().PhoneNumber, "Votre commande (N°" +currentOrder.getNumber()+") est en cours de préparation...");
                    mc.NewKitchenMessage("Préparation de la commande n°" + currentOrder.getNumber() + " en cours ...");
                }
            }
        }

        private void NotifyCommunicationModuleReady()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.Title == "Module Communication")
                {
                    ModuleCommunication mc = (ModuleCommunication)item;
                    mc.NewClientMessage(currentOrder.getClient().PhoneNumber, "Votre commande (N°" + currentOrder.getNumber() + ") est prête à la livraison !");
                    mc.NewKitchenMessage("Commande n°" + currentOrder.getNumber() + " prête.");
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OrderManagementSelection oms = new OrderManagementSelection();
            oms.Show();
        }

        private void SimPaid_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
