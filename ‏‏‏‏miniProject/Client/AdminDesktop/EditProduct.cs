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
using System.Windows.Shapes;
using Microsoft.Win32;
using AdminDesktop.ServiceReference1;

namespace AdminDesktop
{
    /// <summary>
    /// Interaction logic for EditProductPage.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        public Product myProduct { get; set; }
        public bool bNew = false;
        public EditProduct()
        {
            InitializeComponent();
            myProduct = new Product();
            DataContext = myProduct;
        }

        public void ShowProduct(Product product)
        {
            if (product != null)
            {
                bNew = false;
               // DataContext = null;
                myProduct = product;
                DataContext = myProduct;
            }
            else
                bNew = true;
            Hide();
            ShowDialog();
        }
        private void ButtonBrowse_Click(object sender, RoutedEventArgs e)
        {
            TextBoxPath.Text = string.Empty;

            // Create OpenFileDialog 
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.tiff;*.png;*.bmp | All files | *.* ";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = ofd.ShowDialog();

            // Get the selected image name
            if (result == true)
            {
                string filename = ofd.FileName;

                // Display the name in a TextBlock
                TextBoxPath.Text = filename;

                byte[] imageArray =
                       System.IO.File.ReadAllBytes(filename);
                if (myProduct == null)
                    myProduct = new Product();
                myProduct.ImageStr = Convert.ToBase64String(imageArray);
                myProduct.ImageName = filename;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

            bool hasImage = myProduct != null && !string.IsNullOrWhiteSpace(myProduct.ImageStr);
            bool pickedFile = !string.IsNullOrWhiteSpace(TextBoxPath.Text);
            if (!hasImage && !pickedFile)
            {
                MessageBox.Show("Error: No image is selected!", "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return;
            }
            Service1Client service= new Service1Client();
           // ProductDB db = new ProductDB();
            if (bNew)
                     service.InsertProduct(myProduct);
                    // db.Insert(myProduct);
            else
                  service.UpdateProduct(myProduct);
                // db.Update(myProduct);
                //db.Savechanges();
                Close();
        }


        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

