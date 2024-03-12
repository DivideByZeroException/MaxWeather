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
    /// Логика взаимодействия для AddWeatherWindow.xaml
    /// </summary>
    public partial class AddWeatherWindow : Window
    {
        private List<Wind> windList = DBConnection.db.Wind.ToList();
        private List<string> winds = null;
        private List<Conditions> weatherList = DBConnection.db.Conditions.ToList();
        private List<string> weathers = null;
        private List<Cities> citiesList = DBConnection.db.Cities.ToList();
        private List<string> cities = null;
        public AddWeatherWindow()
        {
            InitializeComponent();
            weathers = weatherList.Select(z => z.title).ToList();
            cities = citiesList.Select(z => z.title).ToList();
            winds = windList.Select(z => z.direction).ToList();
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





        private void SuggestionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (suggestionsListBox.SelectedItem != null)
            {
                windSearchTextBox.Text = suggestionsListBox.SelectedItem.ToString();
                suggestionsListBox.Visibility = Visibility.Collapsed;
            }
        }
        private void WindSearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = windSearchTextBox.Text.ToLower();
            List<string> matched = new List<string>();
            foreach (string wind in winds)
            {
                if (wind.ToLower().StartsWith(searchText))
                {
                    matched.Add(wind);
                }
            }
            if (matched.Count > 0 && windSearchTextBox.Text != "")
            {

                suggestionsListBox.ItemsSource = matched;
                suggestionsListBox.Visibility = Visibility.Visible;
            }
            else
            {
                suggestionsListBox.Visibility = Visibility.Collapsed;

            }
        }

        private void Suggestions0ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (weather0ListBox.SelectedItem != null)
            {
                weather0.Text = weather0ListBox.SelectedItem.ToString();
                weather0ListBox.Visibility = Visibility.Collapsed;
            }
        }
        private void Weather0SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = weather0.Text.ToLower();
            List<string> matched = new List<string>();
            foreach (string weather in weathers)
            {
                if (weather.ToLower().StartsWith(searchText))
                {
                    matched.Add(weather);
                }
            }
            if (matched.Count > 0 && weather0.Text != "")
            {

                weather0ListBox.ItemsSource = matched;
                weather0ListBox.Visibility = Visibility.Visible;
            }
            else
            {
                weather0ListBox.Visibility = Visibility.Collapsed;

            }
        }


        private void Suggestions3ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (weather3ListBox.SelectedItem != null)
            {
                weather3.Text = weather3ListBox.SelectedItem.ToString();
                weather3ListBox.Visibility = Visibility.Collapsed;
            }
        }
        private void Weather3SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = weather3.Text.ToLower();
            List<string> matched = new List<string>();
            foreach (string weather in weathers)
            {
                if (weather.ToLower().StartsWith(searchText))
                {
                    matched.Add(weather);
                }
            }
            if (matched.Count > 0 && weather3.Text != "")
            {

                weather3ListBox.ItemsSource = matched;
                weather3ListBox.Visibility = Visibility.Visible;
            }
            else
            {
                weather3ListBox.Visibility = Visibility.Collapsed;

            }
        }

        private void Suggestions6ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (weather6ListBox.SelectedItem != null)
            {
                weather6.Text = weather6ListBox.SelectedItem.ToString();
                weather6ListBox.Visibility = Visibility.Collapsed;
            }
        }
        private void Weather6SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = weather6.Text.ToLower();
            List<string> matched = new List<string>();
            foreach (string weather in weathers)
            {
                if (weather.ToLower().StartsWith(searchText))
                {
                    matched.Add(weather);
                }
            }
            if (matched.Count > 0 && weather6.Text != "")
            {

                weather6ListBox.ItemsSource = matched;
                weather6ListBox.Visibility = Visibility.Visible;
            }
            else
            {
                weather6ListBox.Visibility = Visibility.Collapsed;

            }
        }

        private void Suggestions9ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (weather9ListBox.SelectedItem != null)
            {
                weather9.Text = weather9ListBox.SelectedItem.ToString();
                weather9ListBox.Visibility = Visibility.Collapsed;
            }
        }
        private void Weather9SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = weather9.Text.ToLower();
            List<string> matched = new List<string>();
            foreach (string weather in weathers)
            {
                if (weather.ToLower().StartsWith(searchText))
                {
                    matched.Add(weather);
                }
            }
            if (matched.Count > 0 && weather9.Text != "")
            {

                weather9ListBox.ItemsSource = matched;
                weather9ListBox.Visibility = Visibility.Visible;
            }
            else
            {
                weather9ListBox.Visibility = Visibility.Collapsed;

            }
        }

        private void Suggestions12ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (weather12ListBox.SelectedItem != null)
            {
                weather12.Text = weather12ListBox.SelectedItem.ToString();
                weather12ListBox.Visibility = Visibility.Collapsed;
            }
        }
        private void Weather12SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = weather12.Text.ToLower();
            List<string> matched = new List<string>();
            foreach (string weather in weathers)
            {
                if (weather.ToLower().StartsWith(searchText))
                {
                    matched.Add(weather);
                }
            }
            if (matched.Count > 0 && weather12.Text != "")
            {

                weather12ListBox.ItemsSource = matched;
                weather12ListBox.Visibility = Visibility.Visible;
            }
            else
            {
                weather12ListBox.Visibility = Visibility.Collapsed;

            }
        }

        private void Suggestions15ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (weather15ListBox.SelectedItem != null)
            {
                weather15.Text = weather15ListBox.SelectedItem.ToString();
                weather15ListBox.Visibility = Visibility.Collapsed;
            }
        }
        private void Weather15SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = weather15.Text.ToLower();
            List<string> matched = new List<string>();
            foreach (string weather in weathers)
            {
                if (weather.ToLower().StartsWith(searchText))
                {
                    matched.Add(weather);
                }
            }
            if (matched.Count > 0 && weather15.Text != "")
            {

                weather15ListBox.ItemsSource = matched;
                weather15ListBox.Visibility = Visibility.Visible;
            }
            else
            {
                weather15ListBox.Visibility = Visibility.Collapsed;

            }
        }

        private void Suggestions18ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (weather18ListBox.SelectedItem != null)
            {
                weather18.Text = weather18ListBox.SelectedItem.ToString();
                weather18ListBox.Visibility = Visibility.Collapsed;
            }
        }
        private void Weather18SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = weather18.Text.ToLower();
            List<string> matched = new List<string>();
            foreach (string weather in weathers)
            {
                if (weather.ToLower().StartsWith(searchText))
                {
                    matched.Add(weather);
                }
            }
            if (matched.Count > 0 && weather6.Text != "")
            {

                weather18ListBox.ItemsSource = matched;
                weather18ListBox.Visibility = Visibility.Visible;
            }
            else
            {
                weather18ListBox.Visibility = Visibility.Collapsed;

            }
        }

        private void Suggestions21ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (weather21ListBox.SelectedItem != null)
            {
                weather21.Text = weather21ListBox.SelectedItem.ToString();
                weather21ListBox.Visibility = Visibility.Collapsed;
            }
        }
        private void Weather21SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = weather21.Text.ToLower();
            List<string> matched = new List<string>();
            foreach (string weather in weathers)
            {
                if (weather.ToLower().StartsWith(searchText))
                {
                    matched.Add(weather);
                }
            }
            if (matched.Count > 0 && weather21.Text != "")
            {

                weather21ListBox.ItemsSource = matched;
                weather21ListBox.Visibility = Visibility.Visible;
            }
            else
            {
                weather21ListBox.Visibility = Visibility.Collapsed;

            }
        }

        private void Suggestions24ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (weather24ListBox.SelectedItem != null)
            {
                weather24.Text = weather24ListBox.SelectedItem.ToString();
                weather24ListBox.Visibility = Visibility.Collapsed;
            }
        }
        private void Weather24SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = weather24.Text.ToLower();
            List<string> matched = new List<string>();
            foreach (string weather in weathers)
            {
                if (weather.ToLower().StartsWith(searchText))
                {
                    matched.Add(weather);
                }
            }
            if (matched.Count > 0 && weather24.Text != "")
            {

                weather24ListBox.ItemsSource = matched;
                weather24ListBox.Visibility = Visibility.Visible;
            }
            else
            {
                weather24ListBox.Visibility = Visibility.Collapsed;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (date.Text != null && citySearchTextBox.Text!="" && pressure_box.Text!="" && humidity_box.Text!=""&& wind_box.Text!="" && windSearchTextBox.Text!="" && uv_box.Text!="" && weather0_box.Text!="" && weather0.Text!=""
                && weather3_box.Text != "" && weather3.Text != "" && weather6_box.Text != "" && weather6.Text != "" && weather9_box.Text != "" && weather9.Text != "" && weather12_box.Text != "" && weather12.Text != ""
                && weather15_box.Text != "" && weather15.Text != "" && weather18_box.Text != "" && weather18.Text != "" && weather21_box.Text != "" && weather21.Text != "" && weather24_box.Text != "" && weather24.Text != "")
            {
                Forecasts[] forecasts = new Forecasts[9] {

                    new Forecasts(){
                    time = 1,
                    temperature=Int32.Parse(weather0_box.Text),
                    condition = weatherList.Where(z=>z.title==weather0.Text).FirstOrDefault().id
                    },
                    new Forecasts(){
                    time = 2,
                    temperature=Int32.Parse(weather3_box.Text),
                    condition = weatherList.Where(z=>z.title==weather3.Text).FirstOrDefault().id
                    },
                    new Forecasts(){
                    time = 3,
                    temperature=Int32.Parse(weather6_box.Text),
                    condition = weatherList.Where(z=>z.title==weather6.Text).FirstOrDefault().id
                    },
                    new Forecasts(){
                    time = 4,
                    temperature=Int32.Parse(weather9_box.Text),
                    condition = weatherList.Where(z=>z.title==weather9.Text).FirstOrDefault().id
                    },
                    new Forecasts(){
                    time = 5,
                    temperature=Int32.Parse(weather12_box.Text),
                    condition = weatherList.Where(z=>z.title==weather12.Text).FirstOrDefault().id
                    },
                    new Forecasts(){
                    time = 6,
                    temperature=Int32.Parse(weather15_box.Text),
                    condition = weatherList.Where(z=>z.title==weather15.Text).FirstOrDefault().id
                    },
                    new Forecasts(){
                    time = 7,
                    temperature=Int32.Parse(weather18_box.Text),
                    condition = weatherList.Where(z=>z.title==weather18.Text).FirstOrDefault().id
                    },
                    new Forecasts(){
                    time = 8,
                    temperature=Int32.Parse(weather21_box.Text),
                    condition = weatherList.Where(z=>z.title==weather21.Text).FirstOrDefault().id
                    },
                    new Forecasts(){
                    time = 9,
                    temperature=Int32.Parse(weather24_box.Text),
                    condition = weatherList.Where(z=>z.title==weather24.Text).FirstOrDefault().id
                    }
                };
                Weather weather = new Weather();
                weather.pressure = Int32.Parse(pressure_box.Text);
                weather.humidity = Int32.Parse(humidity_box.Text);
                weather.city = citiesList.Where(z => z.title == citySearchTextBox.Text).FirstOrDefault().id;
                weather.day = (DateTime) date.SelectedDate;
                weather.wind = windList.Where(z => z.direction == windSearchTextBox.Text).FirstOrDefault().id;
                weather.speed = Int32.Parse(wind_box.Text);
                weather.uv = Int32.Parse(uv_box.Text);
                weather.Forecasts = forecasts;
                DBConnection.db.Weather.Add(weather);
                DBConnection.db.SaveChanges();
            }
            else
            {
                error.Visibility = Visibility.Visible;
            }
        }
    }
}
