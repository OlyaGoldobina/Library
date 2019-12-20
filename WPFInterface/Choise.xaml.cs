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
    /// Логика взаимодействия для Choise.xaml
    /// </summary>
    public partial class Choise : Window
    {
        public Choise()
        {
            InitializeComponent();
        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            if (Options.SelectedItem != null)
            {
                string selectedOption = Options.SelectedItem.ToString();
                if (selectedOption == "System.Windows.Controls.ListBoxItem: Settings")
                {
                    Settings settingswindow = new Settings();
                    settingswindow.Show();
                    this.Close();
                }
                else
                {
                    if(selectedOption == "System.Windows.Controls.ListBoxItem: Workers")
                    {
                        Worker workerwindow = new Worker();
                        workerwindow.Show();
                        this.Close();
                    }
                    else
                    {
                        if(selectedOption == "System.Windows.Controls.ListBoxItem: TimeTable")
                        {
                            TimeTable tablewindow = new TimeTable();
                            tablewindow.Show();
                            this.Close();
                        }
                        else
                        {
                            if(selectedOption == "System.Windows.Controls.ListBoxItem: Films")
                            {
                                Films filmwindow = new Films();
                                filmwindow.Show();
                                this.Close();
                            }
                            else
                            {
                                if(selectedOption == "System.Windows.Controls.ListBoxItem: Profit information")
                                {
                                    Profit profitwindow = new Profit();
                                    profitwindow.Show();
                                    this.Close();
                                }
                                else
                                {
                                    if(selectedOption == "System.Windows.Controls.ListBoxItem: Tariffs")
                                    {
                                        Tarrifs tariffwindow = new Tarrifs();
                                        tariffwindow.Show();
                                        this.Close();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("Choose the option, please");
        }
    }
}
