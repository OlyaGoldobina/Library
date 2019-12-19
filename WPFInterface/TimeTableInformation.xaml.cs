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
    /// Логика взаимодействия для TimeTableInformation.xaml
    /// </summary>
    public partial class TimeTableInformation : Window
    {
        TimeTableRepository _repo = new TimeTableRepository();
        public LibraryOfClasses.TimeTable Tabling { get;set;}
        public TimeTableInformation(LibraryOfClasses.TimeTable thetable)
        {
            InitializeComponent();
            if (thetable != null)
            {
                Start.Text = thetable.Datetime.ToString();
                HallName.Text = thetable.Hall.HallName;
                FilmName.Text = thetable.Film.Name;
            }
            Tabling = thetable;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            TimeTable tablewindow = new TimeTable();
            tablewindow.Show();
            this.Close();
        }

        private void ChangeFilmInformation_Click(object sender, RoutedEventArgs e)
        {
            DateTime start;
            string hall;
            string film;
            if (Tabling == null)
            {
                if (DateTime.TryParse(Start.Text, out start))
                {
                    if (HallName.Text != null)
                    {
                        hall = HallName.Text;
                        if (Morning.IsChecked != null)
                        {
                            morning = Morning.IsChecked.Value;
                            if (Weekend.IsChecked != null)
                            {
                                weekend = Weekend.IsChecked.Value;
                                if (Name.Text != null)
                                {
                                    name = Name.Text;
                                    Tariff tariff = new Tariff
                                    {
                                        D = d,
                                        Price = price,
                                        Morning = morning,
                                        Weekend = weekend,
                                        Name = name
                                    };
                                    _repo.AddItem(tariff);
                                    Tarrifs filmswindow = new Tarrifs();
                                    filmswindow.Show();
                                    MessageBox.Show("The tariff was added");
                                    this.Close();
                                }
                                else
                                    MessageBox.Show("Enter the name");
                            }
                            else
                                MessageBox.Show("Choose the option for weekend");
                        }
                        else
                            MessageBox.Show("Choose the option for morning");
                    }
                    else
                        MessageBox.Show("Price should the written with comma");
                }
                else
                    MessageBox.Show("Enter the format in int");
            }
            else
            {
                if (int.TryParse(Name.Text, out d))
                {
                    if (double.TryParse(Price.Text, out price))
                    {
                        if (Morning.IsChecked != null)
                        {
                            morning = Morning.IsChecked.Value;
                            if (Weekend.IsChecked != null)
                            {
                                weekend = Weekend.IsChecked.Value;
                                if (Name.Text != null)
                                {
                                    name = Name.Text;
                                    if (!(name == Tariffing.Name & d == Tariffing.D & price == Tariffing.Price & morning == Tariffing.Morning & weekend == Tariffing.Weekend))
                                    {
                                        Tariff tariff = new Tariff
                                        {
                                            D = d,
                                            Price = price,
                                            Morning = morning,
                                            Weekend = weekend,
                                            Name = name
                                        };
                                        _repo.UpdateItem(Tariffing, tariff);
                                        Tarrifs filmswindow = new Tarrifs();
                                        filmswindow.Show();
                                        MessageBox.Show("The tariff was changed");
                                        this.Close();
                                    }
                                    else
                                        MessageBox.Show("You haven't changed anything");
                                }
                                else
                                    MessageBox.Show("Enter the name");
                            }
                            else
                                MessageBox.Show("Choose the option for weekend");
                        }
                        else
                            MessageBox.Show("Choose the option for morning");
                    }
                    else
                        MessageBox.Show("Price should the written with comma");
                }
                else
                    MessageBox.Show("Enter the format in int");
            }
        }
    }
    }
}
