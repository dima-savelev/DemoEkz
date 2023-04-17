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
    /// Логика взаимодействия для DemandPage.xaml
    /// </summary>
    public partial class DemandPage : Page
    {
        public readonly DbEntities _db = DbEntities.GetContext();
        public DemandPage()
        {
            InitializeComponent();
            _db.Demand.Load();
            datagrid.ItemsSource = _db.Demand.Local.ToBindingList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddEditDemandPage(new Demand()));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите запись для изменения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Demand demand = datagrid.SelectedItem as Demand;
            _db.SaveChanges();
            this.NavigationService.Navigate(new AddEditDemandPage(demand));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Demand demand = datagrid.SelectedItem as Demand;
            var answer = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Предупреждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (answer != MessageBoxResult.Yes) return;
            _db.Demand.Remove(demand);
            _db.SaveChanges();
            MessageBox.Show("Запись удалена!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid.Items.Refresh();
        }
    }
}
