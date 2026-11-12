
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
    /// Interaction logic for UsersEditorPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        User myUser;
        public UsersPage()
        {
            InitializeComponent();
            FillGridView();
        }

        private void UserRow_RightClick(
            object sender,
            MouseButtonEventArgs e)
        {
            if (sender is DataGridRow row)
            {
                row.IsSelected = true;
                row.Focus();
            }
        }


        private void EditUserMenu_Click(
            object sender, RoutedEventArgs e)
        {
            User selectedUser =
                listViewUsers.SelectedItem as User;

            if (selectedUser == null)
            {
                MessageBox.Show("Please select a user.");
                return;
            }

            EditUser editWindow = new EditUser();

            editWindow.Owner = Window.GetWindow(this);

            // Pass selected user to the editing window
            editWindow.DataContext = selectedUser;

            // Open Edit User
            bool? result = editWindow.ShowDialog();

            // Refresh users after successful update
            if (result == true)
            {
                Service1Client service = new Service1Client();

                listViewUsers.ItemsSource =
                    service.SelectAllUsers();
            }
        }



        private void DeleteUserMenu_Click(
            object sender, RoutedEventArgs e)
        {
            // Get selected user
            User selectedUser =
                listViewUsers.SelectedItem as User;

            if (selectedUser == null)
            {
                MessageBox.Show(
                    "Please select a user first.",
                    "Warning",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            // Confirm deletion
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to delete this user?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            try
            {
                // Connect to database service
                Service1Client service = new Service1Client();

                // Delete selected user from database
                service.DeleteUser(selectedUser);

                // Refresh users list
                listViewUsers.ItemsSource =
                    service.SelectAllUsers();

                // Success message
                MessageBox.Show(
                    "User deleted successfully!",
                    "Success",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting user: " + ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
   // Connect your existing database deletion method here.
       
        private void FillGridView()
        {
            Service1Client service = new Service1Client();
            UsersList list= service.SelectAllUsers();


                        //UserDB db = new UserDB();
                        //UsersList list = db.SelectAll();
            listViewUsers.ItemsSource = list;
            if (list.Count > 0)
            {
                listViewUsers.SelectedIndex = 0;
                myUser = listViewUsers.SelectedItem as User;
            }
        }
        //save new user
        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxFName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("first name is missing!", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxFName.Focus();
                return;
            }
            if (textBoxLName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("last name is missing!", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxLName.Focus();
                return;
            }

            if (textBoxUserName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("user name is missing!", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxUserName.Focus();
                return;
            }

            if (textBoxPassword.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("password is missing!", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxPassword.Focus();
                return;
            }
            if (textBoxEmailAddress.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("email address is missing!", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxEmailAddress.Focus();
                return;
            }
            User user = new User();
            user.Fname = textBoxFName.Text.Trim();
            user.Lname = textBoxLName.Text.Trim();
            user.UserName = textBoxUserName.Text.Trim();
            user.Password = textBoxPassword.Text.Trim();
            user.EmailAddress = textBoxEmailAddress.Text.Trim();
            user.UserType = comboBoxUserType.Text;
            Service1Client service= new Service1Client();
            service.InsertUser(user);

                    //UserDB db = new UserDB();
                    //db.Insert(user);
                    //db.Savechanges();
            FillGridView();


        }

        private void listViewUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myUser = this.listViewUsers.SelectedItem as User;

        }

        private void MenuItem_Update(object sender, RoutedEventArgs e)
        {
            if (myUser == null) return;
            var editUserWindow = new EditUser();
           // editUserWindow.Owner = this;
            editUserWindow.NextUser += editUserWindow_NextUser;
            editUserWindow.PrevUser += editUserWindow_PrevUser;
            editUserWindow.ShowUser(myUser);

        }

        private void editUserWindow_PrevUser(EditUser editUser)
        {
            if (listViewUsers.SelectedIndex > 0)
                listViewUsers.SelectedIndex -= 1;
            var user = listViewUsers.SelectedItem as User;
            editUser.ShowUser(user);

        }

        private void editUserWindow_NextUser(EditUser editUser)
        {
            if (listViewUsers.SelectedIndex + 1 < listViewUsers.Items.Count)
                listViewUsers.SelectedIndex += 1;
            var user = listViewUsers.SelectedItem as User;
            editUser.ShowUser(user);
        }

        private void MenuItem_Delete(object sender, RoutedEventArgs e)
        {
            if (myUser == null)
                return;
            MessageBoxResult res;
            res = MessageBox.Show("Delete user:" + myUser.Id + "?", "Confirmation", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.No)
                return;
            Service1Client service = new Service1Client();
            service.DeleteUser(myUser);

                    //UserDB db = new UserDB();
                    //db.Delete(myUser);
                    //db.Savechanges();
            myUser = null;
            FillGridView();
        }
    }
}
