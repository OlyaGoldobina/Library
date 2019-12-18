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
    /// Логика взаимодействия для Tarrifs.xaml
    /// </summary>
    public partial class Tarrifs : Window
    {
        TariffRepositiory _repo = new TariffRepositiory();
        public Tarrifs()
        {
            InitializeComponent();
            UpdateSessions();
        }

        private void UpdateSessions()
        {
            List<Tariff> thisses = _repo.SelectItem();
            TarrifItems.ItemsSource = null;
            TarrifItems.ItemsSource = thisses;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Choise choisewindow = new Choise();
            choisewindow.Show();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedTariff = TarrifItems.SelectedItem as Tariff;
            if (selectedTariff == null)
            {
                MessageBox.Show("Select the item");
                return;
            }
            else
            {
                if (_repo.RemoveItem(selectedTariff))
                {
                    Tarrifs filmswindow = new Tarrifs();
                    filmswindow.Show();
                    MessageBox.Show("The tariff was deleted");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There is information about this tariff in other tables");
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var selectedTariff = TarrifItems.SelectedItem as Tariff;
            if (selectedTariff == null)
            {
                MessageBox.Show("Select the item");
                return;
            }
            else
            {
                TariffInformation filmwindow = new TariffInformation(selectedTariff);
                filmwindow.Show();
                this.Close();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            TariffInformation tariffwindow = new TariffInformation(null);
            tariffwindow.Show();
            this.Close();
        }
    }
}
