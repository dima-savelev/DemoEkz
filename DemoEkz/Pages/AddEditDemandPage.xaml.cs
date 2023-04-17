using DemoEkz.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для AddEditDemandPage.xaml
    /// </summary>
    public partial class AddEditDemandPage : Page
    {
        public readonly DbEntities _db = DbEntities.GetContext();
        public readonly Demand _demand;
        public AddEditDemandPage(Demand demand)
        {
            InitializeComponent();
            _demand = demand;
            txtCity.Text = _demand.Address_City;
            txtStreet.Text = _demand.Address_Street;
            txtHouse.Text = _demand.Address_House;
            txtNumber.Text = _demand.Address_Number;
            txtMinPrice.Text = _demand.MinPrice.ToString();
            txtMaxPrice.Text = _demand.MaxPrice.ToString();
            _db.Agent.Load();
            cmbAgent.ItemsSource = _db.Agent.Local.ToList();
            cmbAgent.SelectedItem = _demand.Agent;
            _db.Client.Load();
            cmbClient.ItemsSource = _db.Client.Local.ToList();
            cmbClient.SelectedItem = _demand.Client;
            txtMinArea.Text = _demand.MinArea.ToString();
            txtMaxArea.Text = _demand.MaxArea.ToString();
            txtMinRoom.Text = _demand.MinRooms.ToString();
            txtMaxRoom.Text = _demand.MaxRooms.ToString();
            txtMinFloor.Text = _demand.MinFloor.ToString();
            txtMaxFloor.Text = _demand.MaxFloor.ToString();
            _db.Type.Load();
            cmbType.ItemsSource = _db.Type.Local.ToList();
            cmbType.SelectedItem = _demand.Type;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            int minprice = 0;
            int maxprice = 0;
            double minarea = 0;
            double maxarea = 0;
            int minroom = 0;
            int maxroom = 0;
            int minfloor = 0;
            int maxfloor = 0;
            if (cmbType.SelectedItem == null)
            {
                errors.AppendLine("Выберите тип");
            }
            if (cmbAgent.SelectedItem == null)
            {
                errors.AppendLine("Выберите агента");
            }
            if (cmbClient.SelectedItem == null)
            {
                errors.AppendLine("Выберите клиента");
            }
            if (!string.IsNullOrEmpty(txtMinPrice.Text) && !int.TryParse(txtMinPrice.Text, out minprice))
            {
                errors.AppendLine("Минимальная цена введена неверно");
            }
            if (minprice < 0)
            {
                errors.AppendLine("Мин. цена не может быть меньше нуля");
            }
            if (!string.IsNullOrEmpty(txtMaxPrice.Text) && !int.TryParse(txtMaxPrice.Text, out maxprice))
            {
                errors.AppendLine("Максимальная цена введена неверно");
            }
            if (maxprice < 0)
            {
                errors.AppendLine("Макс. цена не может быть меньше нуля");
            }
            if (maxprice < minprice)
            {
                errors.AppendLine("Максимальная цена не может быть меньше минимальной");
            }
            if (!string.IsNullOrEmpty(txtMinArea.Text) && !double.TryParse(txtMinArea.Text, out minarea))
            {
                errors.AppendLine("Мин. площадь введена неверно");
            }
            if (minarea < 0)
            {
                errors.AppendLine("Мин. площадь не можеть быть меньше нуля");
            }
            if (!string.IsNullOrEmpty(txtMaxArea.Text) && !double.TryParse(txtMaxArea.Text, out maxarea))
            {
                errors.AppendLine("Макс. площадь введена неверно");
            }
            if (maxarea < 0)
            {
                errors.AppendLine("Макс. площадь не можеть быть меньше нуля");
            }
            if (maxarea < minarea)
            {
                errors.AppendLine("Максимальная площадь не может быть меньше минимальной");
            }
            if (!string.IsNullOrEmpty(txtMinRoom.Text) && !int.TryParse(txtMinRoom.Text, out minroom))
            {
                errors.AppendLine("Мин. кол. комнат введено неверно");
            }
            if (minroom < 0)
            {
                errors.AppendLine("Мин. кол. комнат не может быть меньше нуля");
            }
            if (!string.IsNullOrEmpty(txtMaxRoom.Text) && !int.TryParse(txtMaxRoom.Text, out maxroom))
            {
                errors.AppendLine("Макс. кол. комнат введено неверно");
            }
            if (maxroom < 0)
            {
                errors.AppendLine("Макс. кол. комнат не может быть меньше нуля");
            }
            if (maxroom < minroom)
            {
                errors.AppendLine("Максимальное кол-во комнат не может быть меньше минимального");
            }
            if (!string.IsNullOrEmpty(txtMinFloor.Text) && !int.TryParse(txtMinFloor.Text, out minfloor))
            {
                errors.AppendLine("Минимальное кол-во этажей введено неверно");
            }
            if (minfloor < 0)
            {
                errors.AppendLine("Мин. кол. этажей не может быть меньше нуля");
            }
            if (!string.IsNullOrEmpty(txtMaxFloor.Text) && !int.TryParse(txtMaxFloor.Text, out maxfloor))
            {
                errors.AppendLine("Максимальное кол-во этажей введено неверно");
            }
            if (maxfloor < 0)
            {
                errors.AppendLine("Макс. кол. этажей не может быть меньше нуля");
            }
            if (maxfloor < minfloor)
            {
                errors.AppendLine("Максимальное кол-во этажей не может быть меньше минимального");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _demand.Address_City = txtCity.Text;
            _demand.Address_Street = txtStreet.Text;
            _demand.Address_House = txtHouse.Text;
            _demand.Address_Number = txtNumber.Text;
            _demand.MinPrice = minprice;
            _demand.MaxPrice = maxprice;
            _demand.Agent = cmbAgent.SelectedItem as Agent;
            _demand.Client = cmbClient.SelectedItem as Client;
            _demand.MinArea = minarea;
            _demand.MaxArea = maxarea;
            _demand.Type = cmbType.SelectedItem as Data.Type;
            if (_demand.Type.Title != "Земля")
            {
                _demand.MinRooms = minroom;
                _demand.MaxRooms = maxroom;
                _demand.MinFloor = minfloor;
                _demand.MaxFloor = maxfloor;
            }
            if (_db.Demand.Find(_demand.Id) == null)
            {
                _db.Demand.Add(_demand);
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
        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbType.SelectedItem == null) return;
            var type = cmbType.SelectedItem as Data.Type;
            if (type.Title == "Земля")
            {
                txtMinFloor.IsEnabled = false;
                txtMinRoom.IsEnabled = false;
                txtMaxFloor.IsEnabled = false;
                txtMaxRoom.IsEnabled = false;
                txtMinFloor.Text = string.Empty;
                txtMinRoom.Text = string.Empty;
                txtMaxFloor.Text = string.Empty;
                txtMaxRoom.Text = string.Empty;
            }
            else
            {
                txtMinFloor.IsEnabled = true;
                txtMinRoom.IsEnabled = true;
                txtMaxFloor.IsEnabled = true;
                txtMaxRoom.IsEnabled = true;
            }
        }
    }
}
