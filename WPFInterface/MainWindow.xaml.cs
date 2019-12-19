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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public OurCinema user = new OurCinema();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ForgetPas_Click(object sender, RoutedEventArgs e)
        {
            Question questionwindow = new Question();
            questionwindow.Show();
            this.Close();
        }

        private void EnterTheApp_Click(object sender, RoutedEventArgs e)
        {
            string login = EnterLogin.Text;
            string password = EnterPassword.Password;
            if(login != "")
            {
                if(password != "")
                {
                    if(user.CheckLog(login,password))
                    {
                        Choise choisewindow = new Choise();
                        choisewindow.Show();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Wrong login or password");
                }
                else
                    MessageBox.Show("Enter the password");
            }
            else
            MessageBox.Show("Enter the login");
        }
    }
}
