using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
using System.Data.Entity;

namespace MaxWeather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IUpdatableWindow
    {
        int current_city = 1;
        public SeriesCollection SeriesCollection { get; set; }
        
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        private List<string> cities = DBConnection.db.Cities.Select(z => z.title).ToList();
        public MainWindow()
        {
            InitializeComponent();
            createDiagram();
            UpdateWindow();
            citySearchTextBox.Text = "Поиск города";
            today.Content = "Сегодня " + $"{DateTime.Now:f}";
            next_day_two_label.Content = DateTime.Now.AddDays(2). ToString("dd.MM.yyyy");
            next_day_three_label.Content = DateTime.Now.AddDays(3). ToString("dd.MM.yyyy");
            next_day_four_label.Content = DateTime.Now.AddDays(4). ToString("dd.MM.yyyy");
            next_day_five_label.Content = DateTime.Now.AddDays(5). ToString("dd.MM.yyyy");
            next_day_six_label.Content = DateTime.Now.AddDays(6). ToString("dd.MM.yyyy");
            next_day_seven_label.Content = DateTime.Now.AddDays(7). ToString("dd.MM.yyyy");
           

          


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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           SignupWindow singupWindow = new SignupWindow(this);
            singupWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SigninWindow singinWindow = new SigninWindow(this);
            singinWindow.Show();
        }

        public void UpdateWindow()
        {
            
            if (Session.id != null && DBConnection.db.Users.Where(z => z.id == Session.id).FirstOrDefault().city!=null)
            {
                current_city = (int)DBConnection.db.Users.Where(z => z.id == Session.id).FirstOrDefault().city;
            }
                var weather = DBConnection.db.Weather.Where(z => z.day== DbFunctions.TruncateTime(DateTime.Today)).Where(y=>y.city==current_city).FirstOrDefault();
            if (weather != null)
            {



                temp_stack.Visibility = Visibility.Visible;

                today_temp.Content = weather.Forecasts.Where(z => z.time == 5).FirstOrDefault().temperature.ToString();
                city.Content = DBConnection.db.Cities.Where(z => z.id == weather.city).FirstOrDefault().title.ToString();
                today_pressure.Content = "Давление " + weather.pressure.ToString();
                today_humidity.Content = "Влажность " + weather.humidity.ToString();
                today_uv.Content = "Ульрафиолетовый индекс " + weather.uv.ToString();
                today_wind.Content = "Ветер " + DBConnection.db.Wind.Where(z => z.id == weather.wind).FirstOrDefault().direction.ToString() + " " + weather.speed.ToString() + " м/с";
                var times = weather.Forecasts.ToList();
                time_zero.Content =times.Where(z=>z.time==1).FirstOrDefault().temperature.ToString();
                time_three.Content =times.Where(z=>z.time==2).FirstOrDefault().temperature.ToString();
                time_six.Content =times.Where(z=>z.time==3).FirstOrDefault().temperature.ToString();
                time_nine.Content =times.Where(z=>z.time==4).FirstOrDefault().temperature.ToString();
                time_twelve.Content =times.Where(z=>z.time==5).FirstOrDefault().temperature.ToString();
                time_fifty.Content =times.Where(z=>z.time==6).FirstOrDefault().temperature.ToString();
                time_eighty.Content =times.Where(z=>z.time==7).FirstOrDefault().temperature.ToString();
                time_twentyone.Content =times.Where(z=>z.time==8).FirstOrDefault().temperature.ToString();
                time_twentyfour.Content =times.Where(z=>z.time==9).FirstOrDefault().temperature.ToString();

                int cond = times.Where(x => x.time == 1).FirstOrDefault().condition;
                var img = DBConnection.db.Conditions.Where(z=>z.id== cond).FirstOrDefault().image;
                time_zero_img.Source  = new BitmapImage(new Uri("pack://application:,,,/MaxWeather;component/Images/Weather/Night/" + img));

                cond = times.Where(x => x.time == 2).FirstOrDefault().condition;
                img = DBConnection.db.Conditions.Where(z => z.id == cond).FirstOrDefault().image;
                time_three_img.Source = new BitmapImage(new Uri("pack://application:,,,/MaxWeather;component/Images/Weather/Night/" + img));

                cond = times.Where(x => x.time == 3).FirstOrDefault().condition;
                img = DBConnection.db.Conditions.Where(z => z.id == cond).FirstOrDefault().image;
                time_six_img.Source = new BitmapImage(new Uri("pack://application:,,,/MaxWeather;component/Images/Weather/Night/" + img));

                cond = times.Where(x => x.time == 4).FirstOrDefault().condition;
                img = DBConnection.db.Conditions.Where(z => z.id == cond).FirstOrDefault().image;
                time_nine_img.Source = new BitmapImage(new Uri("pack://application:,,,/MaxWeather;component/Images/Weather/Day/" + img));


                cond = times.Where(x => x.time == 5).FirstOrDefault().condition;
                img = DBConnection.db.Conditions.Where(z => z.id == cond).FirstOrDefault().image;
                time_twelve_img.Source = new BitmapImage(new Uri("pack://application:,,,/MaxWeather;component/Images/Weather/Day/" + img));
                today_img.Source= new BitmapImage(new Uri("pack://application:,,,/MaxWeather;component/Images/Weather/Day/" + img));

                cond = times.Where(x => x.time == 6).FirstOrDefault().condition;
                img = DBConnection.db.Conditions.Where(z => z.id == cond).FirstOrDefault().image;
                time_fifty_img.Source = new BitmapImage(new Uri("pack://application:,,,/MaxWeather;component/Images/Weather/Day/" + img));

                cond = times.Where(x => x.time == 7).FirstOrDefault().condition;
                img = DBConnection.db.Conditions.Where(z => z.id == cond).FirstOrDefault().image;
                time_eighty_img.Source = new BitmapImage(new Uri("pack://application:,,,/MaxWeather;component/Images/Weather/Day/" + img));

                cond = times.Where(x => x.time == 8).FirstOrDefault().condition;
                img = DBConnection.db.Conditions.Where(z => z.id == cond).FirstOrDefault().image;
                time_twentyone_img.Source = new BitmapImage(new Uri("pack://application:,,,/MaxWeather;component/Images/Weather/Night/" + img));

                cond = times.Where(x => x.time == 9).FirstOrDefault().condition;
                img = DBConnection.db.Conditions.Where(z => z.id == cond).FirstOrDefault().image;
                time_twentyfour_img.Source = new BitmapImage(new Uri("pack://application:,,,/MaxWeather;component/Images/Weather/Night/" + img));

                var temps = new ChartValues<int> { times.Where(z => z.time == 1).FirstOrDefault().temperature, times.Where(z => z.time == 2).FirstOrDefault().temperature,
                    times.Where(z => z.time == 3).FirstOrDefault().temperature, times.Where(z => z.time == 4).FirstOrDefault().temperature, times.Where(z => z.time == 5).FirstOrDefault().temperature, 
                    times.Where(z => z.time == 6).FirstOrDefault().temperature, times.Where(z => z.time == 7).FirstOrDefault().temperature, times.Where(z => z.time == 8).FirstOrDefault().temperature, times.Where(z => z.time ==9).FirstOrDefault().temperature };


                var time =DateTime.Today.AddDays(1);
                weather = DBConnection.db.Weather.Where(z => z.day == DbFunctions.TruncateTime(time)).Where(y => y.city == current_city).FirstOrDefault();
                if (weather != null)
                {
                    next_day_one.Content = weather.Forecasts.Where(z=>z.time==5).FirstOrDefault().temperature;
                    cond = weather.Forecasts.Where(z=>z.time==5).FirstOrDefault().condition;
                    img = DBConnection.db.Conditions.Where(z => z.id == cond).FirstOrDefault().image;
                    next_day_one_img.Source = new BitmapImage(new Uri("pack://application:,,,/MaxWeather;component/Images/Weather/Day/" + img));
                }
                else
                {
                    next_day_one.Content = "Н/Д";
                }

                time = DateTime.Today.AddDays(2);
                weather = DBConnection.db.Weather.Where(z => z.day == DbFunctions.TruncateTime(time)).Where(y => y.city == current_city).FirstOrDefault();
                if (weather != null)
                {
                    next_day_two.Content = weather.Forecasts.Where(z => z.time == 5).FirstOrDefault().temperature;
                    cond = weather.Forecasts.Where(z => z.time == 5).FirstOrDefault().condition;
                    img = DBConnection.db.Conditions.Where(z => z.id == cond).FirstOrDefault().image;
                    next_day_two_img.Source = new BitmapImage(new Uri("pack://application:,,,/MaxWeather;component/Images/Weather/Day/" + img));
                }
                else
                {
                    next_day_two.Content = "Н/Д";
                }
                time = DateTime.Today.AddDays(3);
                weather = DBConnection.db.Weather.Where(z => z.day == DbFunctions.TruncateTime(time)).Where(y => y.city == current_city).FirstOrDefault();
                if (weather != null)
                {
                    next_day_three.Content = weather.Forecasts.Where(z => z.time == 5).FirstOrDefault().temperature;
                    cond = weather.Forecasts.Where(z => z.time == 5).FirstOrDefault().condition;
                    img = DBConnection.db.Conditions.Where(z => z.id == cond).FirstOrDefault().image;
                    next_day_three_img.Source = new BitmapImage(new Uri("pack://application:,,,/MaxWeather;component/Images/Weather/Day/" + img));
                }
                else
                {
                    next_day_three.Content = "Н/Д";
                }


                time = DateTime.Today.AddDays(4);
                weather = DBConnection.db.Weather.Where(z => z.day == DbFunctions.TruncateTime(time)).Where(y => y.city == current_city).FirstOrDefault();
                if (weather != null)
                {
                    next_day_four.Content = weather.Forecasts.Where(z => z.time == 5).FirstOrDefault().temperature;
                    cond = weather.Forecasts.Where(z => z.time == 5).FirstOrDefault().condition;
                    img = DBConnection.db.Conditions.Where(z => z.id == cond).FirstOrDefault().image;
                    next_day_four_img.Source = new BitmapImage(new Uri("pack://application:,,,/MaxWeather;component/Images/Weather/Day/" + img));
                }
                else
                {
                    next_day_four.Content = "Н/Д";
                }

                time = DateTime.Today.AddDays(5);
                weather = DBConnection.db.Weather.Where(z => z.day == DbFunctions.TruncateTime(time)).Where(y => y.city == current_city).FirstOrDefault();
                if (weather != null)
                {
                    next_day_five.Content = weather.Forecasts.Where(z => z.time == 5).FirstOrDefault().temperature;
                    cond = weather.Forecasts.Where(z => z.time == 5).FirstOrDefault().condition;
                    img = DBConnection.db.Conditions.Where(z => z.id == cond).FirstOrDefault().image;
                    next_day_five_img.Source = new BitmapImage(new Uri("pack://application:,,,/MaxWeather;component/Images/Weather/Day/" + img));
                }
                else
                {
                    next_day_five.Content = "Н/Д";
                }

                time = DateTime.Today.AddDays(6);
                weather = DBConnection.db.Weather.Where(z => z.day == DbFunctions.TruncateTime(time)).Where(y => y.city == current_city).FirstOrDefault();
                if (weather != null)
                {
                    next_day_six.Content = weather.Forecasts.Where(z => z.time == 5).FirstOrDefault().temperature;
                    cond = weather.Forecasts.Where(z => z.time == 5).FirstOrDefault().condition;
                    img = DBConnection.db.Conditions.Where(z => z.id == cond).FirstOrDefault().image;
                    next_day_six_img.Source = new BitmapImage(new Uri("pack://application:,,,/MaxWeather;component/Images/Weather/Day/" + img));
                }
                else
                {
                    next_day_six.Content = "Н/Д";
                }

                time = DateTime.Today.AddDays(3);
                weather = DBConnection.db.Weather.Where(z => z.day == DbFunctions.TruncateTime(time)).Where(y => y.city == current_city).FirstOrDefault();
                if (weather != null)
                {
                    next_day_seven.Content = weather.Forecasts.Where(z => z.time == 5).FirstOrDefault().temperature;
                    cond = weather.Forecasts.Where(z => z.time == 5).FirstOrDefault().condition;
                    img = DBConnection.db.Conditions.Where(z => z.id == cond).FirstOrDefault().image;
                    next_day_seven_img.Source = new BitmapImage(new Uri("pack://application:,,,/MaxWeather;component/Images/Weather/Day/" + img));
                }
                else
                {
                    next_day_seven.Content = "Н/Д";
                }





                updateDiagram(temps);
            }
            else
            {
                today_temp.Content = "Н/Д";
                city.Content = "Выберите город";
                today_pressure.Content = "Н/Д";
                today_humidity.Content = "Н/Д";
                today_wind.Content = "Н/Д";
                today_uv.Content = "Н/Д";
                temp_stack.Visibility = Visibility.Hidden;
            }

            if (Session.id != null)
            {
                var user = DBConnection.db.Users.Where(z => z.id == Session.id).FirstOrDefault();
                signin_btn.Visibility = Visibility.Collapsed;
                signup_btn.Visibility = Visibility.Collapsed;
                exit_btn.Visibility = Visibility.Visible;
                if (user.role == 2)
                {
                    add_weather_btn.Visibility = Visibility.Visible;
                    edit_weather_btn.Visibility= Visibility.Visible;
                }

            }
            else
            {
                signin_btn.Visibility = Visibility.Visible;
                signup_btn.Visibility = Visibility.Visible;
                exit_btn.Visibility = Visibility.Collapsed;
                add_weather_btn.Visibility = Visibility.Collapsed;
                edit_weather_btn.Visibility = Visibility.Collapsed;
            }
        }

        private void exit_btn_Click(object sender, object e)
        {
            Session.id = null;
            UpdateWindow();
        }
        private void createDiagram()
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    
                    Values = new ChartValues<int>{},

                },
               
            };
            weather_chart.AxisX = new LiveCharts.Wpf.AxesCollection
{
    new LiveCharts.Wpf.Axis
    {
        Title = "Время",
        Separator = new LiveCharts.Wpf.Separator
        {
            Step = 1.0,
            IsEnabled = false
        },
        FontSize = 15,
        Labels = new[] { "0:00", "3:00", "6:00", "9:00", "12:00", "15:00", "18:00", "21:00", "24:00" }
    }
};

            DataContext = this;
            clearDiagram();

        }
        private void clearDiagram()
        {
            if (weather_chart.Series != null)
            {
                weather_chart.Series.Clear();
            }
        }
        private void updateDiagram(ChartValues<int> temps)
        {


            clearDiagram();
            SeriesCollection.Add(
           
                new LineSeries
                {
                    Title="Температура",
                    Values = temps,
                    PointGeometrySize= 20,

                    Stroke = (Brush)(new BrushConverter().ConvertFrom("#B7FF5E")),
                    StrokeThickness = 3,
                    Fill = Brushes.Transparent
        
            });
            YFormatter = value => value + "°";
                DataContext = this;
        }
        private void add_weather_btn_Click(object sender, RoutedEventArgs e)
        {
            AddWeatherWindow addWeatherWindow = new AddWeatherWindow(this);
            addWeatherWindow.Show();
        }
        private void edit_weather_btn_Click(object sender, RoutedEventArgs e)
        {
            AddWeatherWindow addWeatherWindow = new AddWeatherWindow(this);
            addWeatherWindow.Show();
        }

        private void find_city_btn_Click(object sender, RoutedEventArgs e)
            
        {
            if (citySearchTextBox.Text != "")
            {
                string city = citySearchTextBox.Text;
                var cityid = DBConnection.db.Cities.Where(z => z.title.ToLower() == city.ToLower()).FirstOrDefault();
                if (cityid != null)
                {

                    current_city = cityid.id;
                    UpdateWindow();
                }

            }
        }
    }
    
}
