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
using AdminDesktop.ServiceReference1;

namespace AdminDesktop
{
    /// <summary>
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public event Action<EditUser> NextUser;
        public event Action<EditUser> PrevUser;

        public User myUser {  get; set; }

        public EditUser()
        {
            InitializeComponent();
            DataContext = myUser;
        }


        private void EditUserMenu_Click(
            object sender, RoutedEventArgs e)
        {
            TextBoxFName.Focus();
            TextBoxFName.SelectAll();
        }

        private void DeleteUserMenu_Click(
            object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to delete this user?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result != MessageBoxResult.Yes)
                return;

            // Database deletion needs to be connected here.
        }

        public void ShowUser(User user)
        {
            myUser = user;
            DataContext = myUser;
            TextBoxFName.Text = myUser.Fname;   
            TextBoxLName.Text = myUser.Lname;
            TextBoxUserName.Text = myUser.UserName;
            TextBoxPassword.Text = myUser.Password;
            TextBoxEmailAddress.Text = myUser.EmailAddress;
            ComboBoxUserType.Text = myUser.UserType;
            Hide();
            ShowDialog();
            
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void ButtonPrev_Click(object sender, RoutedEventArgs e)
        {
            PrevUser.Invoke(this);


        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            NextUser.Invoke(this);
        }


        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the selected user
                User user = this.DataContext as User;

                // Make sure a user was selected
                if (user == null)
                {
                    MessageBox.Show(
                        "No user selected for editing.",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);

                    return;
                }

                // Validate required fields
                if (string.IsNullOrWhiteSpace(TextBoxFName.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxLName.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxUserName.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxEmailAddress.Text))
                {
                    MessageBox.Show(
                        "Please fill in all required fields.",
                        "Missing Information",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);

                    return;
                }

                // Update the User object through existing bindings
                TextBoxFName
                    .GetBindingExpression(TextBox.TextProperty)?
                    .UpdateSource();

                TextBoxLName
                    .GetBindingExpression(TextBox.TextProperty)?
                    .UpdateSource();

                TextBoxUserName
                    .GetBindingExpression(TextBox.TextProperty)?
                    .UpdateSource();

                TextBoxPassword
                    .GetBindingExpression(TextBox.TextProperty)?
                    .UpdateSource();

                TextBoxEmailAddress
                    .GetBindingExpression(TextBox.TextProperty)?
                    .UpdateSource();

                ComboBoxUserType
                    .GetBindingExpression(ComboBox.TextProperty)?
                    .UpdateSource();

                // Save updated user to database via the service
                Service1Client service = new Service1Client();

                service.UpdateUser(user);

                // Show success message
                MessageBox.Show(
                    "User updated successfully!",
                    "Success",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                // Close Edit User window
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating user: " + ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }





    }
}
