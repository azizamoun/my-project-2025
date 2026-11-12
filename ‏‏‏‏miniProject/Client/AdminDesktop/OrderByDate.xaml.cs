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
    /// Interaction logic for OrderByDate.xaml
    /// </summary>
    public partial class OrderByDate : Page
    {
        Order myOrder;
        public OrderByDate()
        {
            InitializeComponent();


        }

        private void FillGridView(string myDate)
        {
            Service1Client service = new Service1Client();
            OrdersList list = service.SelectOrderByDate(myDate) ?? new OrdersList();

            listViewOrders.ItemsSource = list;
            TextBlockOrdersCount.Text =
                                   $"Available Orders(s): {list.Count}";
            int sum = 0;
            foreach (Order order in list)
            {
                sum += order.TotalPrice;
            }
            TextBlockOrdersCount.Text = list.Count.ToString();




        }

        private void listViewOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myOrder = this.listViewOrders.SelectedItem as Order;

        }





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (datePicker.SelectedDate == null)
            {
                MessageBox.Show("Please select a date.");
                return;
            }

            string stringDate = datePicker.SelectedDate.Value.ToString("yyyy/MM/dd");
            FillGridView(stringDate);

        }
    }
}
