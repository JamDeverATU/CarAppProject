using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace Project
{
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarsDatabaseEntities DB = new CarsDatabaseEntities();

        }

        private void openHomeWindow()
        {
            var newWindow = new MainWindow();
            newWindow.Show();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            CarsDatabaseEntities DB = new CarsDatabaseEntities();
            var query = from g in DB.Login1
                        select g.email;

            var query2 = from g in DB.Login1
                         select g.password;

            if (query.Contains(EmailBox.Text) && query2.Contains(PasswordBox.Text))
            {
                // Login successful
                System.Windows.MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                openHomeWindow();
                this.Close();
            }
            else
            {
                // Login failed
                System.Windows.MessageBox.Show("Login failed! Please check your email and password.", "Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MainWindow();
            newWindow.Show();
        }
    }
}

