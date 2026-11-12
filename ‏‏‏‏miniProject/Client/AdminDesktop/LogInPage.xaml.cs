using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace AdminDesktop
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {

        public LogInPage()
        {
            InitializeComponent();
        }
        public event EventHandler LoginSucceeded;

        // SHOW PASSWORD
        private void ShowPasswordCheckBox_Checked(
            object sender, RoutedEventArgs e)
        {
            VisiblePasswordTextBox.Text =
                PasswordInputBox.Password;

            PasswordInputBox.Visibility =
                Visibility.Collapsed;

            VisiblePasswordTextBox.Visibility =
                Visibility.Visible;

            VisiblePasswordTextBox.Focus();

            VisiblePasswordTextBox.CaretIndex =
                VisiblePasswordTextBox.Text.Length;
        }

        // HIDE PASSWORD
        private void ShowPasswordCheckBox_Unchecked(
            object sender, RoutedEventArgs e)
        {
            PasswordInputBox.Password =
                VisiblePasswordTextBox.Text;

            VisiblePasswordTextBox.Clear();

            VisiblePasswordTextBox.Visibility =
                Visibility.Collapsed;

            PasswordInputBox.Visibility =
                Visibility.Visible;

            PasswordInputBox.Focus();
        }

        // SIGN IN BUTTON
        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            // Get Username
            string username = UsernameTextBox.Text.Trim();

            // Get Password
            string password =
                ShowPasswordCheckBox.IsChecked == true
                ? VisiblePasswordTextBox.Text
                : PasswordInputBox.Password;

            // Check if fields are empty
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                StatusText.Text =
                    "Please enter username and password.";
                return;
            }

            // Find MainWindow
            AdminDesktop.MainWindow mainWindow =
                Window.GetWindow(this) as AdminDesktop.MainWindow;

            if (mainWindow != null)
            {
                // Remove Login Page
                mainWindow.myFrame.Content = null;

                // Show MenuBar
                mainWindow.myMenuBar.Visibility =
                    Visibility.Visible;

                // Show MenuBar Row
                mainWindow.MainGrid.RowDefinitions[0].Height =
                    new GridLength(30);

                // Clear error message
                StatusText.Text = "";
            }
            else
            {
                StatusText.Text =
                    "Login page must be opened inside MainWindow.";
            }

            LoginSucceeded?.Invoke(this, EventArgs.Empty);
        }
    }
}
       // public LogInPage()
       // {
       //     InitializeComponent();
       // }

       // private void LoginBtn_Click(object sender, RoutedEventArgs e)
       // {
          //  MainWindow window = Window.GetWindow(this) as MainWindow;// this equal loginInPage
          //  Service1Client service = new Service1Client();
          //  if (service.GetUser(userNameTxt.Text, passwordBox.Password) != null)
         //   {
                
            //    if (window != null)
           //     {
           //         if (service.GetUser(userNameTxt.Text, passwordBox.Password).UserType.Equals("Admin"))
           //         {
                     //   MainWindow.AdminLoggedIn = true;
                      //  MainWindow.ClientLoggedIn = false;

                      //  window.Refresh();
                      // window.myFrame.Navigate(new ProductPage());
           //         }
             //       else if(service.GetUser(userNameTxt.Text, passwordBox.Password).UserType.Equals("Client"))
            //        {
             //           MainWindow.AdminLoggedIn = false;
              //          MainWindow.ClientLoggedIn = true;
             //           window.Refresh();
               //         window.myFrame.Navigate(new AboutPage());
               //     }
                    
                   
              //  }
           // }
           // else

             //   window.myFrame.Navigate(new AboutPage());
        

        //private void ShowPasswordCheckBox_Checked(object sender, RoutedEventArgs e)
        //{
        //    passwordTextBox.Text = passwordBox.Password;
        //    passwordBox.Visibility = Visibility.Collapsed;
        //    passwordTextBox.Visibility = Visibility.Visible;
        //}

        //private void ShowPasswordCheckBox_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    passwordBox.Password = passwordTextBox.Text;
        //    passwordTextBox.Visibility = Visibility.Collapsed;
        //    passwordBox.Visibility = Visibility.Visible;
        //}



