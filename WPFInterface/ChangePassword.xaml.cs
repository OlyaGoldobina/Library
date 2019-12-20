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
using LibraryOfClasses;

namespace WPFInterface
{
    /// <summary>
    /// Логика взаимодействия для ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public OurCinema user = Factory.Instance.GetOurCinema();
        public string UserLogin { get;set;}
        public ChangePassword(string login)
        {
            InitializeComponent();
            UserLogin = login;
        }

        private void ChangeThePassword_Click(object sender, RoutedEventArgs e)
        {
            string newpassword = EnterNewPassword.Text;
            string repeat = RepeatNewPassword.Text;
            if (newpassword != "" && repeat != "")
            {
                if(newpassword == repeat)
                {
                    user.ChangePasswordByLogin(UserLogin,newpassword);
                    MainWindow mainwindow = new MainWindow();
                    mainwindow.Show();
                    MessageBox.Show("The password was changed");
                    this.Close();
                }
                else
                    MessageBox.Show("The passwords do not match");
            }
            else
                MessageBox.Show("Enter the password");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }
    }
}
