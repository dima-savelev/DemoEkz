using DemoEkz.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для DealPage.xaml
    /// </summary>
    public partial class DealPage : Page
    {
        public readonly DbEntities _db = DbEntities.GetContext();
        public DealPage()
        {
            InitializeComponent();
            _db.Deal.Load();
            datagrid.ItemsSource = _db.Deal.Local.ToBindingList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddEditDealPage(new Deal()));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите запись для изменения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Deal deal= datagrid.SelectedItem as Deal ;
            _db.SaveChanges();
            this.NavigationService.Navigate(new AddEditDealPage(deal));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Deal deal = datagrid.SelectedItem as Deal;
            var answer = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Предупреждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (answer != MessageBoxResult.Yes) return;
            _db.Deal.Remove(deal);
            _db.SaveChanges();
            MessageBox.Show("Запись удалена!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid.Items.Refresh();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagrid.SelectedItem == null) return;
            var deal = datagrid.SelectedItem as Deal;
            int sellerClientComission = 0;
            int buyerClientComission;
            switch (deal.Supply.RealEstate.Type.Title)
            {
                case "Земля":
                    sellerClientComission = 30000+(int)(0.02*deal.Supply.Price.Value);
                    break;
                case "Дом":
                    sellerClientComission = 30000 + (int)(0.01 * deal.Supply.Price.Value);
                    break;
                case "Квартира":
                    sellerClientComission = 36000 + (int)(0.01 * deal.Supply.Price.Value);
                    break;
            }
            buyerClientComission = (int)(0.03*deal.Supply.Price.Value);
            int sumCommission = buyerClientComission + sellerClientComission;
            int sellerAgentDealShare = deal.Supply.Agent.DealShare == null ? 45 : deal.Supply.Agent.DealShare.Value;
            int buyerAgentDealShare = deal.Demand.Agent.DealShare == null ? 45 : deal.Demand.Agent.DealShare.Value;
            int sellerAgentCommissiom = sumCommission / 100 * sellerAgentDealShare;
            int buyerAgentCommissiom = sumCommission / 100 * buyerAgentDealShare;
            int companyCommision = sumCommission - sellerAgentCommissiom - buyerAgentCommissiom;
            txtDealInfo.Text =
                string.Format("Cтоимость услуг для клиента-продавца - {0} " +
                "\nCтоимость услуг для клиента-покупателя - {1} " +
                "\nРазмер отчислений риэлтору клиента-продавца - {2} " +
                "\nРазмер отчислений риэлтору клиента-покупателя - {3} " +
                "\nРазмер отчислений компании - {4}",
                 buyerClientComission,
                 sellerClientComission,
                 sellerAgentCommissiom,
                 buyerAgentCommissiom,
                 companyCommision);
        }
    }
}
