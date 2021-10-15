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
            Employee emp = (Employee)employeesList.SelectedItem;
            employees.Remove(emp);
            Employee.getRegisteredEmployees().Remove(emp);
            MessageBox.Show("Employé supprimé");
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Window wce = new MenuClientEmployee();
            wce.Show();
            Close();
        }
    }
}
