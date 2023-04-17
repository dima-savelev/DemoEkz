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
    /// Логика взаимодействия для AddEditAgentPage.xaml
    /// </summary>
    public partial class AddEditAgentPage : Page
    {
        public readonly DbEntities _db = DbEntities.GetContext();
        public readonly Agent _agent;
        public AddEditAgentPage(Agent agent)
        {
            InitializeComponent();
            _agent = agent;
            txtFname.Text = _agent.FirstName;
            txtMname.Text = _agent.MiddleName;
            txtLname.Text = _agent.LastName;
            txtPercent.Text = _agent.DealShare.ToString();
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
            if (!int.TryParse(txtPercent.Text, out int percent) || percent < 0 || percent > 100)
            {
                errors.AppendLine("Укажите правильно процент от сделки");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _agent.FirstName = txtFname.Text;
            _agent.MiddleName = txtMname.Text;
            _agent.LastName = txtLname.Text;
            _agent.DealShare = percent;
            if (_db.Agent.Find(_agent.Id) == null)
            {
                _db.Agent.Add(_agent);
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
