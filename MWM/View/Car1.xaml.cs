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
using static Project.MWM.ViewModel.MainViewModel;

namespace Project.MWM.View
{
    /// <summary>
    /// Interaction logic for Car1.xaml
    /// </summary>
    public partial class Car1 : UserControl
    {
        public Car1()
        {
            InitializeComponent();

            GTRInformation gtrInfo = new GTRInformation(
                model: "Nissan GT-R",
                year: 2003,
                price: 100000,
                description: "The Nissan GT-R is a high-performance sports car produced by Nissan, known for its exceptional performance and advanced technology.",
                engine: "Twin-Turbocharged 3.8L V6",
                horsepower: 565,
                transmission: "6-speed dual-clutch automatic"
            );

            gtrInfo.ManufacturingDate = new DateTime(2022, 1, 15); 

            this.DataContext = gtrInfo;
        }

        private void ContactButton_Click(object sender, RoutedEventArgs e)
        {
            Message newWindow = new Message();
            newWindow.Show();

        }
    }
}