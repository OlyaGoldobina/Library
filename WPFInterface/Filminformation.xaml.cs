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
    public partial class TariffIformation : Window
    {
        FilmRepositiory _repo = new FilmRepositiory();
        public Film Filming { get;set;}
        public TariffIformation(Film films)
        {
            InitializeComponent();
            if (films != null)
            {
                Name.Text = films.Name;
                StartDate.Text = films.Start.ToString();
                EndDate.Text = films.Finish.ToString();
                MovieRental.Text = films.CostOfMovieRental.ToString();
            }
            Filming = films;
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Films filmswindow = new Films();
            filmswindow.Show();
            this.Close();
        }

        private void ChangeFilmInformation_Click(object sender, RoutedEventArgs e)
        {
            string name;
            DateTime start;
            DateTime end;
            float cost;
            if (Filming == null)
            {
                if(Name.Text != "")
                {
                    name = Name.Text;
                    if (DateTime.TryParse(StartDate.Text,out start))
                    {
                        if(DateTime.TryParse(EndDate.Text, out end))
                        {
                            if(float.TryParse(MovieRental.Text, out cost))
                            {
                                Film films = new Film
                                {
                                    Name = name,
                                    Start = start,
                                    Finish = end,
                                    CostOfMovieRental = cost
                                };
                                _repo.AddItem(films);
                                Films filmswindow = new Films();
                                filmswindow.Show();
                                MessageBox.Show("The film was added");
                                this.Close();
                            }
                            else
                                MessageBox.Show("Cost should the written with comma");
                        }
                        else
                            MessageBox.Show("Finish date should be in the following form - YYYY-MM-DD HH:MM:SS");
                    }
                    else
                        MessageBox.Show("Start date should be in the following form - YYYY-MM-DD HH:MM:SS");
                }
                else
                MessageBox.Show("Enter the name");
            }
            else
            {
                if (Name.Text != "")
                {
                    name = Name.Text;
                    if (DateTime.TryParse(StartDate.Text, out start))
                    {
                        if (DateTime.TryParse(EndDate.Text, out end))
                        {
                            if (float.TryParse(MovieRental.Text, out cost))
                            {
                                if (!(name == Filming.Name & cost == Filming.CostOfMovieRental & start == Filming.Start & end == Filming.Finish))
                                {
                                    Film films = new Film
                                    {
                                        Name = name,
                                        Start = start,
                                        Finish = end,
                                        CostOfMovieRental = cost
                                    };
                                    _repo.UpdateItem(Filming,films);
                                    Films filmswindow = new Films();
                                    filmswindow.Show();
                                    MessageBox.Show("The film was changed");
                                    this.Close();
                                }
                                else
                                    MessageBox.Show("You haven't changed anything");
                            }
                            else
                                MessageBox.Show("Cost should the written with comma");
                        }
                        else
                            MessageBox.Show("Finish date should be in the following form - YYYY-MM-DD HH:MM:SS");
                    }
                    else
                        MessageBox.Show("Start date should be in the following form - YYYY-MM-DD HH:MM:SS");
                }
                else
                    MessageBox.Show("Enter the name");
            }
        }
    }
}
