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
    /// Логика взаимодействия для TimeTable.xaml
    /// </summary>
    public partial class TimeTable : Window
    {
        TimeTableRepository _repo = new TimeTableRepository();
        public TimeTable()
        {
            InitializeComponent();
            UpdateSessions();
        }

        private void UpdateSessions()
        {
            List<LibraryOfClasses.TimeTable> thisses = _repo.SelectItem();
            ShceduleItems.ItemsSource = null;
            ShceduleItems.ItemsSource = thisses;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Choise choisewindow = new Choise();
            choisewindow.Show();
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            TimeTableInformation tablewindow = new TimeTableInformation(null);
            tablewindow.Show();
            this.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var selectedTable = ShceduleItems.SelectedItem as LibraryOfClasses.TimeTable;
            if (selectedTable == null)
            {
                MessageBox.Show("Select the item");
                return;
            }
            else
            {
                TimeTableInformation tablewindow = new TimeTableInformation(selectedTable);
                tablewindow.Show();
                this.Close();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedTable = ShceduleItems.SelectedItem as LibraryOfClasses.TimeTable;
            if (selectedTable == null)
            {
                MessageBox.Show("Select the item");
                return;
            }
            else
            {
                if (_repo.RemoveItem(selectedTable))
                {
                    TimeTable Tablewindow = new TimeTable();
                    Tablewindow.Show();
                    MessageBox.Show("The line was deleted");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There is information about this line in other tables");
                }
            }
        }
    }
}
