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

namespace MaxWeather
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private List<Cities> citiesList = DBConnection.db.Cities.ToList();
        private List<string> cities = null;
        private IUpdatableWindow updatebleWindow = null;
        public EditWindow(IUpdatableWindow window)
        {
            InitializeComponent();
            updatebleWindow = window;
            cities = citiesList.Select(z => z.title).ToList();
        }
        private void SuggestionsCityListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (suggestionsCityListBox.SelectedItem != null)
            {
                citySearchTextBox.Text = suggestionsCityListBox.SelectedItem.ToString();
                suggestionsCityListBox.Visibility = Visibility.Collapsed;
            }
        }
        private void CitySearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = citySearchTextBox.Text.ToLower();
            List<string> matched = new List<string>();
            foreach (string city in cities)
            {
                if (city.ToLower().StartsWith(searchText))
                {
                    matched.Add(city);
                }
            }
            if (matched.Count > 0 && citySearchTextBox.Text != "")
            {

                suggestionsCityListBox.ItemsSource = matched;
                suggestionsCityListBox.Visibility = Visibility.Visible;
            }
            else
            {
                suggestionsCityListBox.Visibility = Visibility.Collapsed;

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)

        {
            if (citySearchTextBox.Text != ""&& date.SelectedDate!=null)
            {
                var city = citiesList.Where(z => z.title == citySearchTextBox.Text).FirstOrDefault().id;
                var weather = DBConnection.db.Weather.Where(z => z.city == city).Where(x => x.day == date.SelectedDate).FirstOrDefault();
                if (weather != null)
                {
                    EditWeatherWindow editWeatherWindow = new EditWeatherWindow(updatebleWindow, weather);
                    editWeatherWindow.Show();
                    this.Close();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
