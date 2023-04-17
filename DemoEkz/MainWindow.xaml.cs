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

namespace DemoEkz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToClientsPage_Click(object sender, RoutedEventArgs e)
        {
            pageContainer.Navigate(new Pages.ClientsPage());
        }

        private void ToAgentPage_Click(object sender, RoutedEventArgs e)
        {
            pageContainer.Navigate(new Pages.AgentsPage());
        }

        private void ToEstatePage_Click(object sender, RoutedEventArgs e)
        {
            pageContainer.Navigate(new Pages.EstatePage());
        }

        private void ToSupplyPage_Click(object sender, RoutedEventArgs e)
        {
            pageContainer.Navigate(new Pages.SuppliesPage());
        }

        private void ToDemandPage_Click(object sender, RoutedEventArgs e)
        {
            pageContainer.Navigate(new Pages.DemandPage());
        }

        private void ToDealPage_Click(object sender, RoutedEventArgs e)
        {
            pageContainer.Navigate(new Pages.DealPage());
        }
    }
}
