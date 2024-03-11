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
    /// Interaction logic for SignupWindow.xaml
    /// </summary>
    public partial class SignupWindow : Window
    {
        IUpdatableWindow updatableWindow;
       
        public SignupWindow(IUpdatableWindow window)
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
            
            SigninWindow signinWindow = new SigninWindow(updatableWindow);
            signinWindow.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (login_box.Text != "" && password_box.Text != "")
            {
                var user = DBConnection.db.Users.Where(z => z.login == login_box.Text).FirstOrDefault();
                if (user == null)
                {
                    Users users = new Users();
                    users.login = login_box.Text;
                    users.password = password_box.Text;
                    users.role = 1;
                    DBConnection.db.Users.Add(users);
                    DBConnection.db.SaveChanges();
                    Session.id = users.id;
                    updatableWindow.UpdateWindow();
                    this.Close();
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
