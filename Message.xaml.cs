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

namespace Project
{
    /// <summary>
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        public Message()
        {
            InitializeComponent();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    DragMove();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while dragging the window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }



        private void WindowStateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Buttonhome_Click(object sender, RoutedEventArgs e)
        {
            MainMenu newWindow = new MainMenu();
            newWindow.Show();
        }
    }
}
