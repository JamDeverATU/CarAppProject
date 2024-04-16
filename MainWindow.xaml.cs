using System;
using System.Windows;
using System.Windows.Input;

namespace Project
{
    public partial class MainWindow : Window
    {
        public MainWindow()
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

        private void OpenNewWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainMenu newWindow = new MainMenu();
                newWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening the new window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void DragMove()
        {
            try
            {
                base.OnMouseLeftButtonDown(new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left));
                base.DragMove();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while dragging the window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
