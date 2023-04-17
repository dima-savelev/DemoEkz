using DemoEkz.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public readonly DbEntities _db = DbEntities.GetContext();
        public ClientsPage()
        {
            InitializeComponent();
            _db.Client.Load();
            datagrid.ItemsSource = _db.Client.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddEditClientPage(new Client()));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите запись для изменения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Client client = datagrid.SelectedItem as Client;
            _db.SaveChanges();
            this.NavigationService.Navigate(new AddEditClientPage(client));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Client client = datagrid.SelectedItem as Client;
            if (client.Demand.Count != 0 || client.Supply.Count != 0)
            {
                MessageBox.Show("Нельзя удалить, потому что он связан с потребностью или предложением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var answer = MessageBox.Show("Вы действительно хотите удалить эту запись?","Предупреждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (answer != MessageBoxResult.Yes) return;
            _db.Client.Remove(client);
            _db.SaveChanges();
            MessageBox.Show("Запись удалена!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid.Items.Refresh();
            txtFind_TextChanged(null, null);
        }

        private void txtFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            string find = txtFind.Text;
            if (string.IsNullOrEmpty(find))
            {
                datagrid.ItemsSource = _db.Client.Local.ToBindingList();
                return;
            }
            List<Client> entities = new List<Client>(); 
            foreach (var item in _db.Client.Local.ToList())
            {
                if (item.FirstName.Contains(find) || item.Phone.Contains(find) || item.Email.Contains(find))
                {
                    entities.Add(item);
                }
            }
            datagrid.ItemsSource = entities;
        }

        private void ToLinks_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem == null)
            {
                return;
            }
            var entity = datagrid.SelectedItem as Client;
            this.NavigationService.Navigate(new SuppliesAndDemands(entity));
        }
    }
}
