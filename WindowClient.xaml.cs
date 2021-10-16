using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Linq;

namespace Projet_Pizzaria
{
    /// <summary>
    /// Logique d'interaction pour Client.xaml
    /// </summary>
    public partial class WindowClient : Window
    {
        //List<Client> clients = new List<Client>();
        ObservableCollection<Client> clients = new ObservableCollection<Client>();

        public WindowClient()
        {
            InitializeComponent();

            foreach (Client c in Client.getRegisteredClient())
            {
                clients.Add(c);
            }
            clientsList.ItemsSource = clients;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(clientsList.ItemsSource);
            view.Filter = UserFilter;
        }

        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;

        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            //MessageBox.Show("closing");
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Client).City.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(clientsList.ItemsSource).Refresh();
        }

        void NameHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    string header = headerClicked.Column.Header as string;
                    Sort(header, direction);

                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(clientsList.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

        private void Button_Return_Click(object sender, RoutedEventArgs e)
        {
            Window wce = new MenuClientEmployee();
            wce.Show();
            Close();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            Client c = (Client)clientsList.SelectedItem;
            clients.Remove(c);
            Client.getRegisteredClient().Remove(c);
            resetTextBox();
            MessageBox.Show("Client supprimé");
        }
        private void Button_Update_Click(object sender, EventArgs e)
        {
            int index = clientsList.SelectedIndex;
            string address = TextBoxAddress.Text;

            var firstSpaceIndex = address.IndexOf(" ");
            int number = Int32.Parse(address.Substring(0, firstSpaceIndex)); 
            string streetName = address.Substring(firstSpaceIndex + 1);
            int zipCode = Int32.Parse(TextBoxZipCode.Text);

            Client selectedClient = new Client(TextBoxName.Text, TextBoxSurname.Text, TextBoxPhoneNumber.Text, new Address(number, streetName, zipCode, TextBoxCity.Text));
            clients.RemoveAt(index);
            clients.Insert(index, selectedClient);
            Client.getRegisteredClient().RemoveAt(index);

            resetTextBox();
        }

        private void resetTextBox()
        {
            TextBoxName.Clear();
            TextBoxSurname.Clear();
            TextBoxPhoneNumber.Clear();
            TextBoxAddress.Clear();
            TextBoxZipCode.Clear();
            TextBoxCity.Clear();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Window wce = new Create_Client();
            wce.Show();
            Close();
        }

        private void clientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Client selectedClient = (Client)clientsList.SelectedItem;
                if (selectedClient != null)
                {
                    TextBoxName.Text = selectedClient.Name.ToString();
                    TextBoxSurname.Text = selectedClient.Surname.ToString();
                    TextBoxPhoneNumber.Text = selectedClient.PhoneNumber.ToString();
                    TextBoxAddress.Text = selectedClient.Address.ToString();
                    TextBoxZipCode.Text = selectedClient.ZipCode.ToString();
                    TextBoxCity.Text = selectedClient.City.ToString();
                }
                
            }
            catch { }
        }
    }
}
