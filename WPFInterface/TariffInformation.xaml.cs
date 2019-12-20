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
    /// Логика взаимодействия для TariffInformation.xaml
    /// </summary>
    public partial class TariffInformation : Window
    {
        TariffRepositiory _repo = new TariffRepositiory();
        public Tariff Tariffing { get;set;}
        public TariffInformation(Tariff thetariff)
        {
            InitializeComponent();
            if (thetariff != null)
            {
                Name.Text = thetariff.Name;
                Price.Text = thetariff.Price.ToString();
                Morning.IsChecked = thetariff.Morning;
                Weekend.IsChecked = thetariff.Weekend;
                Format.Text = thetariff.D.ToString();
            }
            Tariffing = thetariff;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Tarrifs tariffwindow = new Tarrifs();
            tariffwindow.Show();
            this.Close();
        }


        private void ChangeTariffInformation_Click(object sender, RoutedEventArgs e)
        {
            int d;
            double price;
            bool morning;
            bool weekend;
            string name;
            if (Tariffing == null)
            {
                if (int.TryParse(Format.Text, out d))
                {
                    if (double.TryParse(Price.Text, out price))
                    {
                        if (Morning.IsChecked != null)
                        {
                            morning = Morning.IsChecked.Value;
                            if (Weekend.IsChecked != null)
                            {
                                weekend = Weekend.IsChecked.Value;
                                if(Name.Text != "")
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
                if (int.TryParse(Format.Text, out d))
                {
                    if (double.TryParse(Price.Text, out price))
                    {
                        if (Morning.IsChecked != null)
                        {
                            morning = Morning.IsChecked.Value;
                            if (Weekend.IsChecked != null)
                            {
                                weekend = Weekend.IsChecked.Value;
                                if(Name.Text != "")
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
