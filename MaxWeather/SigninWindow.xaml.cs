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
    /// Interaction logic for SigninWindow.xaml
    /// </summary>
    public partial class SigninWindow : Window
    {
        IUpdatableWindow updatableWindow;
        public SigninWindow(IUpdatableWindow window)
        {
            InitializeComponent();
            updatableWindow = window;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           SignupWindow signupWindow = new SignupWindow(updatableWindow);
            signupWindow.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (login_box.Text != "" && password_box.Text != "")
            {
                var user = DBConnection.db.Users.Where(z => z.login == login_box.Text).FirstOrDefault();
                if(user != null)
                {
                    if (password_box.Text == user.password)
                    {
                        Session.id = user.id;
                        updatableWindow.UpdateWindow();
                        this.Close();
                    }
                }
                else
                {
                    error.Visibility = Visibility.Visible;
                }
            }
            else
            {
                error.Visibility = Visibility.Visible;
            }
        }

       
    }
}
