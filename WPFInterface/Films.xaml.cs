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
    /// Логика взаимодействия для Films.xaml
    /// </summary>
    public partial class Films : Window
    {
        FilmRepositiory _repo = new FilmRepositiory();
        public Films()
        {
            InitializeComponent();
            UpdateSessions();
        }

        private void UpdateSessions()
        {
            List<Film> thisses = _repo.SelectItem();
            FilmItems.ItemsSource = null;
            FilmItems.ItemsSource = thisses;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Choise choisewindow = new Choise();
            choisewindow.Show();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedFilm = FilmItems.SelectedItem as Film;
            if (selectedFilm == null)
            {
                MessageBox.Show("Select the item");
                return;
            }
            else
            {
                    if (_repo.RemoveItem(selectedFilm))
                {
                    Films filmswindow = new Films();
                    filmswindow.Show();
                    this.Close();
                }
                    else
                {
                    MessageBox.Show("There is information about this film in other tables");
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var selectedFilm = FilmItems.SelectedItem as Film;
            if (selectedFilm == null)
            {
                MessageBox.Show("Select the item");
                return;
            }
            else
            {
                Filminformation filmwindow = new Filminformation(selectedFilm);
                filmwindow.Show();
                this.Close();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Filminformation filmwindow = new Filminformation(null);
            filmwindow.Show();
            this.Close();
        }
    }
}
