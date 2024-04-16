using System;
using System.Windows;
using System.Windows.Input;

namespace Project
{
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            this.MouseDown += MainMenu_MouseDown;
        }

        private void MainMenu_MouseDown(object sender, MouseButtonEventArgs e)
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
    }
}
