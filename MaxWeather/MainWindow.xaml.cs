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

namespace MaxWeather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<string> cities = new List<string> { "Москва", "Санкт-Петербург", "Новосибирск", "Екатеринбург", "Казань","Кострома","Киев","Кейптаун","Керчь","Калининград" }; 
        public MainWindow()
        {
            InitializeComponent();
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
    }
    
}
