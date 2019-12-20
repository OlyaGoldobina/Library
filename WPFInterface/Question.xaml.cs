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
        public OurCinema user = Factory.Instance.GetOurCinema();
        public string UserLogin { get;set;}
        public Question(string login)
        {
            InitializeComponent();
            NewQuestion.Text = user.ReturnQuestionOnLogin(login);
            UserLogin = login;
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
                if(answer != "")
                {
                    if(user.ReturnPasswordOnSA(answer,UserLogin))
                {
                    ChangePassword changewindow = new ChangePassword(UserLogin);
                    changewindow.Show();
                    this.Close();
                }
                    else
                    MessageBox.Show("Wrong answer");
                }
                else
                    MessageBox.Show("Enter the answer");
        }
    }
}
