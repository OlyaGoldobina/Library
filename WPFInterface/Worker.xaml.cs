using LibraryOfClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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


namespace WPFInterface
{
    /// <summary>
    /// Логика взаимодействия для Worker.xaml
    /// </summary>
    public partial class Worker : Window
    {
        WorkerRepositiory _repo = new WorkerRepositiory();
        public Worker()
        {
            InitializeComponent();
            UpdateSessions();
        }

        private void UpdateSessions()
        {
            List<LibraryOfClasses.Worker> thisses = _repo.SelectItem();
            WorkersItem.ItemsSource = null;
            WorkersItem.ItemsSource = thisses;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Choise choisewindow = new Choise();
            choisewindow.Show();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedWorker = WorkersItem.SelectedItem as LibraryOfClasses.Worker;
            if (selectedWorker == null)
            {
                MessageBox.Show("Select the item");
                return;
            }
            else
            {
                if (_repo.RemoveItem(selectedWorker))
                {
                    Worker filmswindow = new Worker();
                    filmswindow.Show();
                    MessageBox.Show("The worker was deleted");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There is information about this worker in other tables");
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var selectedWorker = WorkersItem.SelectedItem as LibraryOfClasses.Worker;
            if (selectedWorker == null)
            {
                MessageBox.Show("Select the item");
                return;
            }
            else
            {
                WorkersInformation filmwindow = new WorkersInformation(selectedWorker);
                filmwindow.Show();
                this.Close();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            WorkersInformation workerwindow = new WorkersInformation(null);
            workerwindow.Show();
            this.Close();
        }
    }
}
