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
    /// Логика взаимодействия для AddEditEstatePage.xaml
    /// </summary>
    public partial class AddEditEstatePage : Page
    {
        public readonly DbEntities _db = DbEntities.GetContext();
        public readonly RealEstate _estate;
        public AddEditEstatePage(RealEstate estate)
        {
            InitializeComponent();
            _estate = estate;
            _db.Type.Load();
            cmbType.ItemsSource = _db.Type.Local.ToList();
            cmbType.SelectedItem = _estate.Type;
            txtCity.Text = _estate.Address_City;
            txtStreet.Text = _estate.Address_Street;
            txtHouse.Text = _estate.Address_House;
            txtNumber.Text = _estate.Address_Number;
            txtLatitude.Text = _estate.Coordinate_latitude.ToString();
            txtLongitude.Text = _estate.Coordinate_longitude.ToString();
            txtArea.Text = _estate.TotalArea.ToString();
            txtRoom.Text = _estate.Rooms.ToString();
            txtFloor.Text = _estate.Floor.ToString();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            double latitude = 0;
            double longitude = 0;
            double area = 0;
            int room = 0;
            int floor = 0;
            if (cmbType.SelectedItem == null)
            {
                errors.AppendLine("Выберите тип");
            }
            if (!string.IsNullOrEmpty(txtLatitude.Text) && !double.TryParse(txtLatitude.Text, out latitude))
            {
                errors.AppendLine("Широта введена неверно");
            }
            if(latitude < -90 || latitude > 90)
            {
                errors.AppendLine("Широта введена неверно");
            }
            if (!string.IsNullOrEmpty(txtLongitude.Text) && !double.TryParse(txtLongitude.Text, out longitude))
            {
                errors.AppendLine("Долгота введена неверно");
            }
            if (longitude < -180 || longitude > 180)
            {
                errors.AppendLine("Долгота введена неверно");
            }
            if (!string.IsNullOrEmpty(txtArea.Text) && !double.TryParse(txtArea.Text, out area))
            {
                errors.AppendLine("Площадь введена неверно");
            }
            if (area < 0)
            {
                errors.AppendLine("Площадь введена неверно");
            }
            if (!string.IsNullOrEmpty(txtRoom.Text) && !int.TryParse(txtRoom.Text, out room))
            {
                errors.AppendLine("Номер комнаты введен неверно1");
            }
            if (room < 0)
            {
                errors.AppendLine("Номер комнаты введен неверно");
            }
            if (!string.IsNullOrEmpty(txtFloor.Text) && !int.TryParse(txtFloor.Text, out floor))
            {
                errors.AppendLine("Этаж/Этажность введены неверно");
            }
            if (floor < 0)
            {
                errors.AppendLine("Этаж/Этажность введены неверно");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _estate.Type = cmbType.SelectedItem as Data.Type;
            _estate.Address_City = txtCity.Text;
            _estate.Address_Street = txtStreet.Text;
            _estate.Address_House = txtHouse.Text;
            _estate.Address_Number = txtNumber.Text;
            _estate.Coordinate_latitude = latitude;
            _estate.Coordinate_longitude = longitude;
            _estate.TotalArea = area;
            if (_estate.Type.Title != "Земля")
            {
                _estate.Rooms = room;
                _estate.Floor = floor;
            }
            if (_db.RealEstate.Find(_estate.Id) == null)
            {
                _db.RealEstate.Add(_estate);
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
                txtFloor.IsEnabled= false;
                txtRoom.IsEnabled= false;
                txtFloor.Text = string.Empty;
                txtRoom.Text = string.Empty;
            }
            else
            {
                txtFloor.IsEnabled= true;
                txtRoom.IsEnabled= true;
            }
        }
    }
}
