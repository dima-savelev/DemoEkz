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
    /// Логика взаимодействия для AddEditClientPage.xaml
    /// </summary>
    public partial class AddEditClientPage : Page
    {
        public readonly DbEntities _db = DbEntities.GetContext();
        public readonly Client _client;
        public AddEditClientPage(Client client)
        {
            InitializeComponent();
            _client = client;
            txtFname.Text = _client.FirstName;
            txtMname.Text = _client.MiddleName;
            txtLname.Text = _client.LastName;
            txtPhone.Text = _client.Phone;
            txtEmail.Text = _client.Email;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(txtFname.Text))
            {
                errors.AppendLine("Заполните фамилию");
            }
            if (string.IsNullOrEmpty(txtMname.Text))
            {
                errors.AppendLine("Заполните имя");
            }
            if (string.IsNullOrEmpty(txtLname.Text))
            {
                errors.AppendLine("Заполните отчество");
            }
            if (string.IsNullOrEmpty(txtPhone.Text) && string.IsNullOrEmpty(txtEmail.Text))
            {
                errors.AppendLine("Заполните теелефон или почту");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _client.FirstName = txtFname.Text;
            _client.MiddleName = txtMname.Text;
            _client.LastName = txtLname.Text;
            _client.Email = txtEmail.Text;
            _client.Phone = txtPhone.Text;
            if (_db.Client.Find(_client.Id) == null)
            {
                _db.Client.Add(_client);
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
