using DemoEkz.Data;
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

namespace DemoEkz.Pages
{
    /// <summary>
    /// Логика взаимодействия для SuppliesAndDemands.xaml
    /// </summary>
    public partial class SuppliesAndDemands : Page
    {
        public SuppliesAndDemands(Data.Client client)
        {
            InitializeComponent();
            datagrid1.ItemsSource = client.Supply;
            datagrid2.ItemsSource = client.Demand;
        }
        public SuppliesAndDemands(Data.Agent agent)
        {
            InitializeComponent();
            datagrid1.ItemsSource = agent.Supply;
            datagrid2.ItemsSource = agent.Demand;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
