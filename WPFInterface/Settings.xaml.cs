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
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {

        public OurCinema user = Factory.Instance.GetOurCinema();
        public Settings()
        {
            InitializeComponent();
            UpdateInformation();
        }

        public void UpdateInformation()
        {
            var sourse = user.ListOfQuest;
            ChangeQuestion.ItemsSource = null;
            ChangeQuestion.ItemsSource = sourse;
        }

        private void ChangeThePassword_Click(object sender, RoutedEventArgs e)
        {
            string password = PastPassword.Text;
            string newpassword = NewPassword.Text;
            if(password != "" && newpassword != "")
            {
                if(user.ChangePassword(password, newpassword))
                {
                    Settings setwindow = new Settings();
                    setwindow.Show();
                    MessageBox.Show("The password was changed");
                    this.Close();
                }
                else
                    MessageBox.Show("Wrong current password");
            }
            else
                MessageBox.Show("Enter current password and new password");
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }

        private void ChangeQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            if(ChangeQuestion.SelectedItem != null)
            {
                string question = ChangeQuestion.SelectedItem.ToString();
                string answer = Answer.Text;
                if(answer != "")
                {
                    user.ChangeQuestionAndAnswer(question,answer);
                    Settings setwindow = new Settings();
                    setwindow.Show();
                    MessageBox.Show("The queation and the answer were changed");
                    this.Close();
                }
                else
                    MessageBox.Show("Enter the answer");
            }
            else
                MessageBox.Show("Select the question");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Choise choisewindow = new Choise();
            choisewindow.Show();
            this.Close();
        }
    }
}
