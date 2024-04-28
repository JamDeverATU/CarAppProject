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
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Xml;

namespace Project
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public string Color { get; set; }
    }

    public interface ICarDataService
    {
        ObservableCollection<Car> GetCars();
        void SaveCars(ObservableCollection<Car> cars);
    }

    public class CarDataService : ICarDataService
    {
        private const string JsonFilePath = "C:\\Users\\james\\OneDrive\\Desktop\\random\\test\\cars.json";

        public ObservableCollection<Car> GetCars()
        {
            if (File.Exists(JsonFilePath))
            {
                string json = File.ReadAllText(JsonFilePath);
                return new ObservableCollection<Car>(JsonConvert.DeserializeObject<List<Car>>(json));
            }
            else
            {
                return new ObservableCollection<Car>();
            }
        }

        public void SaveCars(ObservableCollection<Car> cars)
        {
            string json = JsonConvert.SerializeObject(cars, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFilePath, json);
        }
    }

    /// <summary>
    /// Interaction logic for Filter.xaml
    /// </summary>
    public partial class Filter : Window
    {
        private ICarDataService carDataService;
        private ObservableCollection<Car> cars;
        private CollectionViewSource carsViewSource;
        private HashSet<string> uniqueMakes;
        private HashSet<string> uniqueModels;
        private HashSet<string> uniqueYears;
        private HashSet<string> uniqueTransmissions;
        private HashSet<string> uniqueColors;

        public Filter()
        {
            InitializeComponent();
            carDataService = new CarDataService();
            cars = carDataService.GetCars();
            carsViewSource = new CollectionViewSource { Source = cars };
            carsViewSource.View.SortDescriptions.Add(new SortDescription("Make", ListSortDirection.Ascending));
            CarListView.ItemsSource = carsViewSource.View;

            // Populate the filter ComboBoxes
            PopulateFilterComboBoxes();
        }

        private void PopulateFilterComboBoxes()
        {
            uniqueMakes = new HashSet<string>(cars.Select(c => c.Make));
            uniqueModels = new HashSet<string>(cars.Select(c => c.Model));
            uniqueYears = new HashSet<string>(cars.Select(c => c.Year.ToString()));
            uniqueTransmissions = new HashSet<string>(cars.Select(c => c.Transmission));
            uniqueColors = new HashSet<string>(cars.Select(c => c.Color));

            MakeFilterComboBox.Items.Add(new ComboBoxItem { Content = "All" });
            foreach (var make in uniqueMakes.OrderBy(m => m))
            {
                MakeFilterComboBox.Items.Add(new ComboBoxItem { Content = make });
            }

            ModelFilterComboBox.Items.Add(new ComboBoxItem { Content = "All" });
            foreach (var model in uniqueModels.OrderBy(m => m))
            {
                ModelFilterComboBox.Items.Add(new ComboBoxItem { Content = model });
            }

            YearFilterComboBox.Items.Add(new ComboBoxItem { Content = "All" });
            foreach (var year in uniqueYears.OrderByDescending(y => y))
            {
                YearFilterComboBox.Items.Add(new ComboBoxItem { Content = year });
            }

            TransmissionFilterComboBox.Items.Add(new ComboBoxItem { Content = "All" });
            foreach (var transmission in uniqueTransmissions)
            {
                TransmissionFilterComboBox.Items.Add(new ComboBoxItem { Content = transmission });
            }

            ColorFilterComboBox.Items.Add(new ComboBoxItem { Content = "All" });
            foreach (var color in uniqueColors)
            {
                ColorFilterComboBox.Items.Add(new ComboBoxItem { Content = color });
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            carsViewSource.View.Filter = car =>
            {
                var searchText = SearchBox.Text.ToLower();
                return ((Car)car).Make.ToLower().Contains(searchText) ||
                       ((Car)car).Model.ToLower().Contains(searchText) ||
                       ((Car)car).Year.ToString().Contains(searchText) ||
                       ((Car)car).Transmission.ToLower().Contains(searchText) ||
                       ((Car)car).Color.ToLower().Contains(searchText);
            };
        }

        private void MakeFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedMake = (MakeFilterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            carsViewSource.View.Filter = car =>
            {
                if (string.IsNullOrEmpty(selectedMake) || selectedMake == "All")
                    return true;
                return ((Car)car).Make == selectedMake;
            };
        }

        private void ModelFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedModel = (ModelFilterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            carsViewSource.View.Filter = car =>
            {
                if (string.IsNullOrEmpty(selectedModel) || selectedModel == "All")
                    return true;
                return ((Car)car).Model == selectedModel;
            };
        }

        private void YearFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedYear = (YearFilterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            carsViewSource.View.Filter = car =>
            {
                if (string.IsNullOrEmpty(selectedYear) || selectedYear == "All")
                    return true;
                return ((Car)car).Year.ToString() == selectedYear;
            };
        }

        private void TransmissionFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedTransmission = (TransmissionFilterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            carsViewSource.View.Filter = car =>
            {
                if (string.IsNullOrEmpty(selectedTransmission) || selectedTransmission == "All")
                    return true;
                return ((Car)car).Transmission == selectedTransmission;
            };
        }

        private void ColorFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedColor = (ColorFilterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            carsViewSource.View.Filter = car =>
            {
                if (string.IsNullOrEmpty(selectedColor) || selectedColor == "All")
                    return true;
                return ((Car)car).Color == selectedColor;
            };
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            carDataService.SaveCars(cars);
            base.OnClosing(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow newWindow = new MainWindow();
                newWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}