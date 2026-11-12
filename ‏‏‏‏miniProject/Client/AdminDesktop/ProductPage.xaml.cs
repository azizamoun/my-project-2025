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
using AdminDesktop.ServiceReference1;





namespace AdminDesktop
{
    /// <summary>
    /// Interaction logic for ProductsEditorPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            FillDataGrid();
        }
        public void FillDataGrid()
        {
            Service1Client service = new Service1Client();
            ProductsList list = service.SelectAllProducts();
                       
                    //ProductDB db = new ProductDB();
                    //ProductsList list = db.SelectAll();

            TextBlockProductsCount.Text =
                                   $"Available Product(s): {list.Count}";

            DataGridProducts.ItemsSource = list;
        }


        private void ButtonNewProduct_Click(object sender,
                                            RoutedEventArgs e)
        {
            var win = new EditProduct();
            win.ShowProduct(null);
            FillDataGrid();   // must add this to view the new product in the dataGrid
        }



        private void DataGridRow_MouseDoubleClick(object sender,
                                                  MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            var product = row.DataContext as Product;
            var win = new EditProduct();
            win.ShowProduct(product);
            FillDataGrid();     //must add this
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res;
            res = MessageBox.Show("Delete: Are you sure?",
                                  "Confirmation",
                                  MessageBoxButton.YesNo);
            if (res == MessageBoxResult.No)
                return;

           
            Product product = ((FrameworkElement)sender).DataContext
                              as Product;
           
            Service1Client service= new Service1Client();
            service.DeleteProduct(product);
            
                    // ProductDB db = new ProductDB();
                    // db.Delete(product);
                    // db.Savechanges();
            FillDataGrid();
        }
    }
}


