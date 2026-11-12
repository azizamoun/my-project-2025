using AdminDesktop.ServiceReference1;
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

namespace AdminDesktop
{
    /// <summary>
    /// Interaction logic for AllOrders.xaml
    /// </summary>
    public partial class AllOrders : Page
    {
        Order myOrder;
        public AllOrders()
        {
            InitializeComponent();
            FillGridView();
        }

        private void FillGridView()
        {
            Service1Client service = new Service1Client();
            OrdersList list = service.SelectAllOrders() ?? new OrdersList();

            listViewOrders.ItemsSource = list;
            TextBlockOrdersCount.Text =
                                   $"Available Orders(s): {list.Count}";
            int sum = 0;
            foreach (Order order in list)
            {
                sum += order.TotalPrice;
            }
            totalLabel.Content += sum.ToString();

            //if (list.Count > 0)
            //{
            //    listViewOrders.SelectedIndex = 0;
            //    myUser = listViewUsers.SelectedItem as User;
            //}
        }

        private void listViewOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myOrder = this.listViewOrders.SelectedItem as Order;

        }
    }
}
