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
    /// Логика взаимодействия для Loginning.xaml
    /// </summary>
    public partial class Loginning : Window
    {
        public OurCinema user = Factory.Instance.GetOurCinema();
        public Loginning()
        {
            InitializeComponent();
        }

        private void Question_Click(object sender, RoutedEventArgs e)
        {
            var login = TheLogin.Text;
            if(login != "")
            {
                if(user.CheckLogin(login))
                {
                    Question questionwindow = new Question(login);
                    questionwindow.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("There is no user with this login");
            }
            else
                MessageBox.Show("Enter the login");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }
    }
}
