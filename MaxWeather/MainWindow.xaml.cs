using LiveCharts;
using LiveCharts.Wpf;
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
using LiveCharts;
using LiveCharts.Wpf;

namespace MaxWeather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public SeriesCollection SeriesCollection { get; set; }
        
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        private List<string> cities = new List<string> { "Москва", "Санкт-Петербург", "Новосибирск", "Екатеринбург", "Казань","Кострома","Киев","Кейптаун","Керчь","Калининград" }; 
        public MainWindow()
        {
            InitializeComponent();
            citySearchTextBox.Text = "Поиск города";
            today.Content = "Сегодня " + $"{DateTime.Now:f}";
            next_day_two_label.Content =  $"{DateTime.Now:f}";
            var temps = new ChartValues<int> { -12, -8, -7, -5, -5, -6, -8, -10, -13 };

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title="Температура",
                    Values = temps,
                    PointGeometrySize= 20,

                    Stroke = (Brush)(new BrushConverter().ConvertFrom("#B7FF5E")),
                    StrokeThickness = 3,
                    Fill = Brushes.Transparent            
        },
            };

            weather.AxisX = new LiveCharts.Wpf.AxesCollection()

{
    new LiveCharts.Wpf.Axis()
    {
        Title= "Время",
        Separator = new LiveCharts.Wpf.Separator()
        {
            Step = 1.0,
            IsEnabled = false

        },
        FontSize=15
        

    }
};         
            Labels = new[] { "0:00", "3:00", "6:00", "9:00", "12:00", "15:00", "18:00", "21:00", "24:00" };
            weather.AxisX.First().Labels = Labels;
           

            YFormatter = value => value + "°";
            DataContext = this;

          


        }
        private void SuggestionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (suggestionsListBox.SelectedItem != null)
            {
                citySearchTextBox.Text = suggestionsListBox.SelectedItem.ToString();
                suggestionsListBox.Visibility = Visibility.Collapsed; 
            }
        }
        private void CitySearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = citySearchTextBox.Text.ToLower();
            List<string> matchedCities = new List<string>();
            foreach (string city in cities)
            {
                if (city.ToLower().StartsWith(searchText))
                {
                    matchedCities.Add(city);
                }
            }
            if (matchedCities.Count > 0 && citySearchTextBox.Text!="")
            {

                suggestionsListBox.ItemsSource = matchedCities;
                suggestionsListBox.Visibility = Visibility.Visible;
            }
            else
            {
                suggestionsListBox.Visibility = Visibility.Collapsed;
         
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void citySearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (citySearchTextBox.Text == "Поиск города")
            {
                citySearchTextBox.Text = string.Empty;
            }
        }

        private void citySearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (citySearchTextBox.Text == string.Empty)
            {
                citySearchTextBox.Text = "Поиск города";
            }
        }

      
    }
    
}
