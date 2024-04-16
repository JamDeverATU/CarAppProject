using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Windows.Controls;

namespace Project.MWM.View
{
    public partial class HomeView : UserControl
    {
        public ObservableCollection<object> InfoList { get; set; }

        public HomeView()
        {
            InitializeComponent();

            InfoList = new ObservableCollection<object>();

            InfoList.Add(new CarMeet { Location = "City Park", Date = "2024-05-15", Description = "Monthly car meet at City Park." });
            InfoList.Add(new CarNews { Title = "New Electric Car Released", Date = "2024-04-05", Content = "Company XYZ has launched its latest electric car model." });

            listBox.ItemsSource = InfoList;
        }

        
    }

    public class CarMeet
    {
        public string Location { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }

    public class CarNews
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Content { get; set; }
    }


}
