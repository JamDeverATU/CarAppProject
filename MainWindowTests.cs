using NUnit.Framework;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using Moq;

namespace Project.Tests
{
    [TestFixture]
    public class MainWindowTests
    {
        [Test]
        public void CanDragWindow()
        {
            // Arrange
            var window = new MainWindow();
            var initialPosition = window.Left;

            // Act
            var grid = new Grid();
            window.Content = grid;
            window.Show();

            // Simulate drag
            grid.RaiseEvent(new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left, null)
            {
                RoutedEvent = UIElement.MouseLeftButtonDownEvent
            });
            grid.RaiseEvent(new MouseEventArgs(Mouse.PrimaryDevice, 0)
            {
                RoutedEvent = UIElement.MouseMoveEvent
            });

            // Assert
            Assert.That(window.Left, Is.Not.EqualTo(initialPosition));
        }

        [Test]
        public void CanOpenNewWindow()
        {
            // Arrange
            var window = new MainWindow();
            var mockWindow = new Mock<Window>();

            // Act
            var button = new Button();
            button.Click += (sender, args) => mockWindow.Object.Show();
            window.Content = button;
            window.Show();

            // Simulate button click
            button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            // Assert
            mockWindow.Verify(w => w.ShowDialog(), Times.Once);
        }

        [Test]
        public void CanOpenFilterWindow()
        {
            // Arrange
            var window = new MainWindow();
            var mockWindow = new Mock<Window>();

            // Act
            var button = new Button();
            button.Click += (sender, args) => mockWindow.Object.Show();
            window.Content = button;
            window.Show();

            // Simulate button click
            button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            // Assert
            mockWindow.Verify(w => w.ShowDialog(), Times.Once);
        }

        // Add more tests for exception handling scenarios if necessary
    }
}
