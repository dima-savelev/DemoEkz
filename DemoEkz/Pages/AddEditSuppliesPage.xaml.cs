using DemoEkz.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
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
    /// Логика взаимодействия для AddEditSuppliesPage.xaml
    /// </summary>
    public partial class AddEditSuppliesPage : Page
    {
        public readonly DbEntities _db = DbEntities.GetContext();
        public readonly Supply _supply;
        public AddEditSuppliesPage(Supply supply)
        {
            InitializeComponent();
            _supply = supply;
            txtPrice.Text = _supply.Price.ToString();
            _db.Agent.Load();
            cmbAgent.ItemsSource = _db.Agent.Local.ToList();
            cmbAgent.SelectedItem = _supply.Agent;
            _db.Client.Load();
            cmbClient.ItemsSource = _db.Client.Local.ToList();
            cmbClient.SelectedItem = _supply.Client;
            _db.RealEstate.Load();
            cmbRealEstate.ItemsSource = _db.RealEstate.Local.ToList();
            cmbRealEstate.SelectedItem = _supply.RealEstate;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (!int.TryParse(txtPrice.Text, out int price) || price <= 0)
            {
                errors.AppendLine("Цена введена неверно");
            }
            if (cmbAgent.SelectedItem == null)
            {
                errors.AppendLine("Выберите агента");
            }
            if (cmbClient.SelectedItem == null)
            {
                errors.AppendLine("Выберите клиента");
            }
            if (cmbRealEstate.SelectedItem == null)
            {
                errors.AppendLine("Выберите объект недвижимости");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _supply.Price = price;
            _supply.Agent = cmbAgent.SelectedItem as Agent;
            _supply.Client = cmbClient.SelectedItem as Client;
            _supply.RealEstate= cmbRealEstate.SelectedItem as RealEstate;
            if (_db.Supply.Find(_supply.Id) == null)
            {
                _db.Supply.Add(_supply);
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
