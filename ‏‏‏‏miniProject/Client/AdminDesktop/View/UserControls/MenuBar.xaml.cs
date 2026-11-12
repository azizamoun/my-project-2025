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

namespace AdminDesktop.View.UserControls
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : UserControl
    {
        public MenuBar()
        {
            InitializeComponent();
            Refresh();
        }
        public void Refresh()
        {
            if (MainWindow.AdminLoggedIn == true)
            {
                AdminMenu.Visibility = Visibility.Visible;
                ClientMenu.Visibility = Visibility.Collapsed;
                GuestMenu.Visibility = Visibility.Collapsed;
            }
                                   
            
            else if (MainWindow.ClientLoggedIn == true)
            {
                AdminMenu.Visibility = Visibility.Collapsed;
                ClientMenu.Visibility = Visibility.Visible;
                GuestMenu.Visibility = Visibility.Collapsed;
            }
            else 
            {
                AdminMenu.Visibility = Visibility.Collapsed;
                ClientMenu.Visibility = Visibility.Collapsed;
                GuestMenu.Visibility = Visibility.Visible;

            }
           
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MenuItem_About_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = Window.GetWindow(this) as MainWindow;// this equal menuBar
            if (window != null)
            {
                  window.myFrame.Navigate(new AboutPage());
            }
        }



        private void MenuItem_Products_Click(object sender,
                                             RoutedEventArgs e)
        {
            MainWindow window = Window.GetWindow(this) as MainWindow;  //the parameter this=menuBar
            if (window != null)
            {
                window.myFrame.Navigate(new ProductPage());
            }



        }
        private void MenuItem_UsefulLinks_Click(object sender,
                                                RoutedEventArgs e)
        { }
        
        private void MenuItem_Login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = Window.GetWindow(this) as MainWindow;
            if (window != null)
            {
                if (MainWindow.AdminLoggedIn)
                {
                    window.myFrame.Navigate(new ProductPage());

                }
                else if (MainWindow.ClientLoggedIn)
                {
                     window.myFrame.Navigate(new AboutPage());
                }

                else
                {
                    window.myFrame.Navigate(new LogInPage());
                }
               
                    
                     Refresh();
                     
                    
                   
                
            }
        }


        private void MenuItem_Users_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = Window.GetWindow(this) as MainWindow;
            if (window != null)
            {
                window.myFrame.Navigate(new UsersPage());
            }
        }

        private void MenuItem_ExitC_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_ProductsC_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_AboutV_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_SignUpV_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AdminLoggedIn = false;
            MainWindow.ClientLoggedIn = false;

            Refresh();
            MainWindow window = Window.GetWindow(this) as MainWindow;
            window.myFrame.Navigate(new LogInPage());


        }
    }
}
