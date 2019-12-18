using LibraryOfClasses;
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

namespace WPFInterface
{
    /// <summary>
    /// Логика взаимодействия для Filminformation.xaml
    /// </summary>
    public partial class Filminformation : Window
    {
        FilmRepositiory _repo = new FilmRepositiory();
        public Filminformation(Film films)
        {
            InitializeComponent();
            if (films != null)
            {
                Name.Text = films.Name;
                StartDate.Text = films.Start.ToString();
                EndDate.Text = films.Finish.ToString();
                MovieRental.Text = films.CostOfMovieRental.ToString();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Films filmswindow = new Films();
            filmswindow.Show();
            this.Close();
        }

        private void ChangeFilmInformation_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
