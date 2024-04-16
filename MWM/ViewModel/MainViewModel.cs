using Project.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project.MWM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand Car1ViewCommand { get; set; }
        public HomeViewModel HomeVM { get; set; }
        public Car1Viewmodel car1VM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            car1VM = new Car1Viewmodel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            Car1ViewCommand = new RelayCommand(o =>
            {
                CurrentView = car1VM;
            });
        }

        public class GTRInformation
        {
            public string Model { get; set; }
            public int Year { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public string Engine { get; set; }
            public int Horsepower { get; set; }
            public string Transmission { get; set; }
            public DateTime ManufacturingDate { get; set; } 

            public GTRInformation(string model, int year, decimal price, string description, string engine, int horsepower, string transmission)
            {
                Model = model;
                Year = year;
                Price = price;
                Description = description;
                Engine = engine;
                Horsepower = horsepower;
                Transmission = transmission;
            }
        }

    }
}
