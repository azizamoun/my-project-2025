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
    public partial class MainWindow : Window
    {
        private bool isLoggedIn = false;
        public static bool AdminLoggedIn = false;
        public static bool ClientLoggedIn = false;

        public MainWindow()
        {
            InitializeComponent();

            // Show the MenuBar
            myMenuBar.Visibility = Visibility.Visible;

            // Set MenuBar height
            MainGrid.RowDefinitions[0].Height = new GridLength(30);

            // Show the main Home background
            myFrame.Content = null;
        }

        // UPDATE USER PERMISSIONS
        private void UpdateNavigation()
        {
            // Protected Pages
            ProductButton.IsEnabled = isLoggedIn;
            UsersButton.IsEnabled = isLoggedIn;
            OrderByDateButton.IsEnabled = isLoggedIn;
            AllOrdersButton.IsEnabled = isLoggedIn;

            // Public Pages
            HomeButton.IsEnabled = true;
            AboutButton.IsEnabled = true;
            LoginButton.IsEnabled = true;

            // Show or Hide Lock Icons
            ProductButton.Content =
                isLoggedIn ? "PRODUCTS" : "🔒 PRODUCTS";

            UsersButton.Content =
                isLoggedIn ? "USERS" : "🔒 USERS";

            OrderByDateButton.Content =
                isLoggedIn ? "ORDER BY DATE" : "🔒 ORDER BY DATE";

            AllOrdersButton.Content =
                isLoggedIn ? "ALL ORDERS" : "🔒 ALL ORDERS";

            // Login / Logout
            LoginButton.Content =
                isLoggedIn ? "LOG OUT" : "LOGIN";
        }

        // OPEN LOGIN PAGE
        private void OpenLoginPage()
        {
            LogInPage login = new LogInPage();

            login.LoginSucceeded +=
                Login_LoginSucceeded;

            myFrame.Navigate(login);
        }

        // AFTER SUCCESSFUL LOGIN
        private void Login_LoginSucceeded(
            object sender, EventArgs e)
        {
            isLoggedIn = true;

            // User successfully logged in
            isLoggedIn = true;

            // Set client login status
            MainWindow.ClientLoggedIn = true;
            MainWindow.AdminLoggedIn = false;

            // Update navigation permissions
            UpdateNavigation();

            // Refresh the old MenuBar
            myMenuBar.Refresh();

            UpdateNavigation();

            // Show existing MenuBar
            myMenuBar.Visibility = Visibility.Visible;

            MainGrid.RowDefinitions[0].Height =
                new GridLength(30);

            // Open Product Page
            myFrame.Navigate(new ProductPage());
        }

        // PROTECTED NAVIGATION
        private void NavigateProtected(Page page)
        {
            if (!isLoggedIn)
            {
                MessageBox.Show(
                    "Please sign in to access this page.",
                    "Access Denied",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            myFrame.Navigate(page);
        }

        // HOME
        private void Home_Click(
            object sender, RoutedEventArgs e)
        {
            myFrame.Content = null;
        }

        // ABOUT
        private void About_Click(
            object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new AboutPage());
        }

        // PRODUCTS
        private void Product_Click(
            object sender, RoutedEventArgs e)
        {
            NavigateProtected(new ProductPage());
        }

        // USERS
        private void Users_Click(
    object sender, RoutedEventArgs e)
        {
            if (!isLoggedIn)
            {
                MessageBox.Show(
                    "Please login first.");
                return;
            }

            myFrame.Navigate(new UsersPage());
        }

        // ORDER BY DATE
        private void OrderByDate_Click(
            object sender, RoutedEventArgs e)
        {
            NavigateProtected(new OrderByDate());
        }

        // ALL ORDERS
        private void AllOrders_Click(
            object sender, RoutedEventArgs e)
        {
            NavigateProtected(new AllOrders());
        }

        // LOGIN / LOGOUT
        private void Login_Click(
            object sender, RoutedEventArgs e)
        {
            if (isLoggedIn)
            {
                // Logout user
                isLoggedIn = false;
                MainWindow.AdminLoggedIn = false;
                MainWindow.ClientLoggedIn = false;

                myMenuBar.Visibility =
                    Visibility.Collapsed;

                MainGrid.RowDefinitions[0].Height =
                    new GridLength(0);

                UpdateNavigation();
            }

            OpenLoginPage();
        }

        private void myMenuBar_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}