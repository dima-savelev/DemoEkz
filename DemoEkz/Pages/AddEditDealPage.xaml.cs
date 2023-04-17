using DemoEkz.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для AddEditDealPage.xaml
    /// </summary>
    public partial class AddEditDealPage : Page
    {
        public readonly DbEntities _db = DbEntities.GetContext();
        public readonly Deal _deal;
        public AddEditDealPage(Deal deal)
        {
            InitializeComponent();
            _deal = deal;
            _db.Demand.Load();
            var listDemands = _db.Demand.Where(p => p.Deal.Count == 0).ToList();
            if (deal.Demand != null)
            {
                listDemands.Add(deal.Demand);
            }
            cmbDemand.ItemsSource = listDemands;
            cmbDemand.SelectedItem = _db.Demand.Find(_deal.Demand_Id);

            _db.Supply.Load();
            var listSupplies = _db.Supply.Where(p => p.Deal.Count == 0).ToList();
            if (deal.Supply != null)
            {
                listSupplies.Add(deal.Supply);
            }
            cmbSupply.ItemsSource = listSupplies;
            cmbSupply.SelectedItem = _db.Supply.Find(_deal.Supply_Id);
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (cmbDemand.SelectedItem == null)
            {
                errors.AppendLine("Выберите потребность");
            }
            if (cmbSupply.SelectedItem == null)
            {
                errors.AppendLine("Выберите предложение");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _deal.Demand = cmbDemand.SelectedItem as Demand;
            _deal.Supply = cmbSupply.SelectedItem as Supply;
            if (_db.Deal.Find(_deal.Id) == null)
            {
                _db.Deal.Add(_deal);
            }
            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("Успешно сохранено!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            this.NavigationService.GoBack();
        }
    }
}
