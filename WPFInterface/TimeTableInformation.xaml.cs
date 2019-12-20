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
                WorkerName.Text = thetable.Worker.Name;
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
            string worker;
            if (Tabling == null)
            {
                if (DateTime.TryParse(Start.Text, out start))
                {
                    if (HallName.Text != "")
                    {
                        hall = HallName.Text;
                        if (FilmName.Text != "")
                        {
                            film = FilmName.Text;
                            if(WorkerName.Text != "")
                            {
                                worker = WorkerName.Text;
                                var Filming = _repo.GetFilm(film);
                                if (Filming != null)
                                {
                                    var Halling = _repo.GetHall(hall);
                                    if (Halling != null)
                                    {
                                        var Working = _repo.GetWorker(worker);
                                        if(Working != null)
                                        {
                                            LibraryOfClasses.TimeTable timeTable = new LibraryOfClasses.TimeTable
                                            {
                                                Datetime = start,
                                                Film = Filming,
                                                FilmID = Filming.FilmID,
                                                Hall = Halling,
                                                HallID = Halling.HallID,
                                                Worker = Working,
                                                WorkerID = Working.WorkerID
                                            };
                                            _repo.AddItem(timeTable);
                                            TimeTable tablewindow = new TimeTable();
                                            tablewindow.Show();
                                            MessageBox.Show("The line was added");
                                            this.Close();
                                        }
                                        else
                                            MessageBox.Show("There is no worker with this name");
                                    }
                                    else
                                        MessageBox.Show("There is no hall with this name");
                                }
                                else
                                    MessageBox.Show("There in no film with this name");
                            }
                            else
                                MessageBox.Show("Enter the worker");
                                }
                                else
                                    MessageBox.Show("Enter the film");
                            }
                            else
                                MessageBox.Show("Enter the hall");
                    }
                    else
                        MessageBox.Show("Enter the date in the fillowing format YYYY-MM-DD HH:MM:SS");
            }
            else
            {
                if (DateTime.TryParse(Start.Text, out start))
                {
                    if (HallName.Text != "")
                    {
                        hall = HallName.Text;
                        if (FilmName.Text != "")
                        {
                            film = FilmName.Text;
                            if (WorkerName.Text != "")
                            {
                                worker = WorkerName.Text;
                                var Filming = _repo.GetFilm(film);
                                if (Filming != null)
                                {
                                    var Halling = _repo.GetHall(hall);
                                    if (hall != null)
                                    {
                                        var Working = _repo.GetWorker(worker);
                                        if (Working != null)
                                        {
                                            if(!(Working.WorkerID == Tabling.WorkerID & Filming.FilmID == Tabling.FilmID & Halling.HallID == Tabling.HallID & start == Tabling.Datetime))
                                            {
                                                LibraryOfClasses.TimeTable timeTable = new LibraryOfClasses.TimeTable
                                                {
                                                    Datetime = start,
                                                    Film = Filming,
                                                    FilmID = Filming.FilmID,
                                                    Hall = Halling,
                                                    HallID = Halling.HallID,
                                                    Worker = Working,
                                                    WorkerID = Working.WorkerID
                                                };
                                                _repo.UpdateItem(Tabling, timeTable);
                                                TimeTable tablewindow = new TimeTable();
                                                tablewindow.Show();
                                                MessageBox.Show("The line was changed");
                                                this.Close();
                                            }
                                            else
                                                MessageBox.Show("You haven't changed anything");
                                        }
                                        else
                                            MessageBox.Show("There is no worker with this name");
                                    }
                                    else
                                        MessageBox.Show("There is no hall with this name");
                                }
                                else
                                    MessageBox.Show("There in no film with this name");
                            }
                            else
                                MessageBox.Show("Enter the worker");
                        }
                        else
                            MessageBox.Show("Enter the film");
                    }
                    else
                        MessageBox.Show("Enter the hall");
                }
                else
                    MessageBox.Show("Enter the date in the fillowing format YYYY-MM-DD HH:MM:SS");
            }
    }
    }
}
