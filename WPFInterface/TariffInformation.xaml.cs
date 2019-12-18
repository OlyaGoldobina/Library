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
    /// Логика взаимодействия для TariffInformation.xaml
    /// </summary>
    public partial class TariffInformation : Window
    {
        public TariffInformation()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Tarrifs tariffwindow = new Tarrifs();
            tariffwindow.Show();
            this.Close();
        }


        private void ChangeTariffInformation_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
