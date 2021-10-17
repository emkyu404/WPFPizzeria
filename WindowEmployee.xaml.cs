using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace Projet_Pizzaria
{
    /// <summary>
    /// Logique d'interaction pour WindowEffectif.xaml
    /// </summary>
    public partial class WindowEmployee : Window
    {
        //List<Employee> employees = new List<Employee>();
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

        public WindowEmployee()
        {
            InitializeComponent();

            foreach (Employee emp in Employee.getRegisteredEmployees())
            {
                employees.Add(emp);
            }
            employeesList.ItemsSource = employees;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(employeesList.ItemsSource);
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
                return ((item as Employee).City.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(employeesList.ItemsSource).Refresh();
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
              CollectionViewSource.GetDefaultView(employeesList.ItemsSource);

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
            if(employeesList.SelectedItem != null)
            {
                Employee emp = (Employee)employeesList.SelectedItem;
                employees.Remove(emp);
                Employee.RegisteredEmployees.Remove(emp.Number);
                resetTextBoxes();
                MessageBox.Show("Employé supprimé");
            }
            else
            {
                MessageBox.Show("Sélectionner un employé");
            }
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            if (employeesList.SelectedItem != null)
            {
                if (TextBoxName.Text != "" && TextBoxSurname.Text != "" && TextBoxAddress.Text != "" && TextBoxZipCode.Text != "" && TextBoxCity.Text != "")
                {
                    int index = employeesList.SelectedIndex;

                    Employee selectedEmployee = createEmployee();

                    employees.RemoveAt(index);
                    employees.Insert(index, selectedEmployee);
                    Employee.getRegisteredEmployees().RemoveAt(index);
                    resetTextBoxes();
                }
                else
                {
                    MessageBox.Show("Les champs sont mal remplis");
                }
            }
            else
            {
                MessageBox.Show("Sélectionner un employé");
            }
        }

        private Employee createEmployee()
        {
            string address = TextBoxAddress.Text;

            var firstSpaceIndex = address.IndexOf(" ");
            int number = Int32.Parse(address.Substring(0, firstSpaceIndex));
            string streetName = address.Substring(firstSpaceIndex + 1);
            int zipCode = Int32.Parse(TextBoxZipCode.Text);

            string type = TypeEmployee.Text;

            if (type.Equals("Commis"))
            {
                return new Commis(TextBoxName.Text, TextBoxSurname.Text, new Address(number, streetName, zipCode, TextBoxCity.Text));
            }
            else
            {
                return new DeliveryMan(TextBoxName.Text, TextBoxSurname.Text, new Address(number, streetName, zipCode, TextBoxCity.Text));
            }
        }

        private void resetTextBoxes()
        {
            TextBoxNumber.Clear();
            TextBoxName.Clear();
            TextBoxSurname.Clear();
            TypeEmployee.SelectedIndex = -1;
            TextBoxAddress.Clear();
            TextBoxZipCode.Clear();
            TextBoxCity.Clear();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            if (employeesList.SelectedItem == null)
            {
                if (TextBoxName.Text != "" && TextBoxSurname.Text != "" && TypeEmployee.Text != "" && TextBoxAddress.Text != "" &&
                    TextBoxZipCode.Text != "" && TextBoxCity.Text != "")
                {
                    Employee newEmployee = createEmployee();
                    employees.Add(newEmployee);
                    resetTextBoxes();
                }
                else
                {
                    MessageBox.Show("Les champs sont mal remplis");
                }
            }
        }

        private void employeesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee selectedEmployee = (Employee)employeesList.SelectedItem;
            try { 
                if (selectedEmployee != null)
                {
                    string type = selectedEmployee.getType().ToString();
                    if (type.Equals("Commis"))
                    {
                        type = "Commis";
                    }
                    else
                    {
                        type = "Livreur";
                    }

                    TextBoxNumber.Text = selectedEmployee.Number.ToString();
                    TextBoxName.Text = selectedEmployee.Name;
                    TextBoxSurname.Text = selectedEmployee.Surname;
                    TypeEmployee.Text = type;
                    TextBoxAddress.Text = selectedEmployee.Address;
                    TextBoxZipCode.Text = selectedEmployee.ZipCode.ToString();
                    TextBoxCity.Text = selectedEmployee.City;
                }
            }
            catch { }
        }
    }
}
