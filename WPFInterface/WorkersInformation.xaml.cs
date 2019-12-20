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
    /// Логика взаимодействия для WorkersInformation.xaml
    /// </summary>
    public partial class WorkersInformation : Window
    {
        WorkerRepositiory _repo = new WorkerRepositiory();
        public LibraryOfClasses.Worker Working { get; set; }
        public WorkersInformation(LibraryOfClasses.Worker theworker)
        {
            InitializeComponent();
            if (theworker != null)
            {
                Name.Text = theworker.Name;
                BirthDate.Text = theworker.BirthDate.ToString();
                WorkingPosition.Text = theworker.WorkingPosition;
                Salary.Text = theworker.Salary.ToString();
            }
            Working = theworker;
        }

        private void ChangeWorkerInformation_Click(object sender, RoutedEventArgs e)
        {
            {
                string name;
                DateTime birthday;
                string position;
                double salary;
                if (Working == null)
                {
                    if (Name.Text != "")
                    {
                        name = Name.Text;
                        if (DateTime.TryParse(BirthDate.Text, out birthday))
                        {
                            if (WorkingPosition.Text != "")
                            {
                                position = WorkingPosition.Text;
                                if (double.TryParse(Salary.Text, out salary))
                                {
                                    LibraryOfClasses.Worker workers = new LibraryOfClasses.Worker
                                    {
                                        Name = name,
                                        BirthDate = birthday,
                                        WorkingPosition = position,
                                        Salary = salary
                                    };
                                    _repo.AddItem(workers);
                                    Worker workerswindow = new Worker();
                                    workerswindow.Show();
                                    MessageBox.Show("The worker was added");
                                    this.Close();
                                }
                                else
                                    MessageBox.Show("Salary should the written with comma");
                            }
                            else
                                MessageBox.Show("Enter the working position");
                        }
                        else
                            MessageBox.Show("Birthday should be in the following form - YYYY-MM-DD");
                    }
                    else
                        MessageBox.Show("Enter the name");
                }
                else
                {
                    if (Name.Text != "")
                    {
                        name = Name.Text;
                        if (DateTime.TryParse(BirthDate.Text, out birthday))
                        {
                            if (WorkingPosition.Text != "")
                            {
                                position = WorkingPosition.Text;
                                if (double.TryParse(Salary.Text, out salary))
                                {
                                    if(!(name == Working.Name & salary == Working.Salary & birthday == Working.BirthDate & position == Working.WorkingPosition))
                                    {
                                        LibraryOfClasses.Worker workers = new LibraryOfClasses.Worker
                                        {
                                            Name = name,
                                            BirthDate = birthday,
                                            WorkingPosition = position,
                                            Salary = salary
                                        };
                                        _repo.UpdateItem(Working,workers);
                                        Worker workerswindow = new Worker();
                                        workerswindow.Show();
                                        MessageBox.Show("The worker was changed");
                                        this.Close();
                                    }
                                    else
                                        MessageBox.Show("You haven't change anything");
                                }
                                else
                                    MessageBox.Show("Salary should the written with comma");
                            }
                            else
                                MessageBox.Show("Enter the working position");
                        }
                        else
                            MessageBox.Show("Birthday should be in the following form - YYYY-MM-DD");
                    }
                    else
                        MessageBox.Show("Enter the name");
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Worker workerwindow = new Worker();
            workerwindow.Show();
            this.Close();
        }
    }
}
