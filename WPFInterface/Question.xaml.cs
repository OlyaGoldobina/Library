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
    /// Логика взаимодействия для Question.xaml
    /// </summary>
    public partial class Question : Window
    {
        public OurCinema user = new OurCinema();
        public Question()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            string answer = TheAnswer.Text;
            string login = user.LoginUser;
            if(login != "")
            {
                if(answer != "")
                {
//                    if(user.)
                }
                else
                    MessageBox.Show("Enter the answer");
            }
            else
                MessageBox.Show("Enter the login");
        }
    }
}
