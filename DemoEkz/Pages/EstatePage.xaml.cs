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
    /// Логика взаимодействия для EstatePage.xaml
    /// </summary>
    public partial class EstatePage : Page
    {
        public readonly DbEntities _db = DbEntities.GetContext();
        public EstatePage()
        {
            InitializeComponent();
            _db.RealEstate.Load();
            datagrid.ItemsSource = _db.RealEstate.Local.ToBindingList();
            _db.Type.Load();
            cmbFiltr.ItemsSource = _db.Type.Local.ToList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddEditEstatePage(new RealEstate()));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите запись для изменения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            RealEstate estate = datagrid.SelectedItem as RealEstate;
            _db.SaveChanges();
            this.NavigationService.Navigate(new AddEditEstatePage(estate));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            RealEstate estate = datagrid.SelectedItem as RealEstate;
            var answer = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Предупреждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (answer != MessageBoxResult.Yes) return;
            _db.RealEstate.Remove(estate);
            _db.SaveChanges();
            MessageBox.Show("Запись удалена!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid.Items.Refresh();
            cmbFiltr_SelectionChanged(null, null);
        }

        private void cmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFiltr.SelectedItem == null) return;
            Data.Type type = cmbFiltr.SelectedItem as Data.Type;
            datagrid.ItemsSource = _db.RealEstate.Local.Where(p => p.Type == type).ToList(); 
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            cmbFiltr.SelectedItem = null;
            datagrid.ItemsSource = _db.RealEstate.Local.ToBindingList();
        }
        private void txtFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            cmbFiltr.SelectedItem = null;
            string find = txtFind.Text;
            if (string.IsNullOrEmpty(find))
            {
                datagrid.ItemsSource = _db.RealEstate.Local.ToBindingList();
                return;
            }

            List<RealEstate> entities = new List<RealEstate>();
            foreach (var item in _db.RealEstate.Local.ToList())
            {
                if (!string.IsNullOrEmpty(item.Address_City) && item.Address_City.Contains(find))
                {
                    entities.Add(item);
                    continue;
                }
                if (!string.IsNullOrEmpty(item.Address_House) && item.Address_House.Contains(find))
                {
                    entities.Add(item);
                    continue;
                }
                if (!string.IsNullOrEmpty(item.Address_Number) && item.Address_Number.Contains(find))
                {
                    entities.Add(item);
                    continue;
                }
                if (!string.IsNullOrEmpty(item.Address_Street) && item.Address_Street.Contains(find))
                {
                    entities.Add(item);
                    continue;
                }
            }

            datagrid.ItemsSource = entities;
        }
    }
}
