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
    /// Логика взаимодействия для Profit.xaml
    /// </summary>
    public partial class Profit : Window
    {
        public RepoPribill _repo = new RepoPribill();
        public Profit()
        {
            InitializeComponent();
            UpdateData();
        }

        public void UpdateData()
        {
            var totalrevenue = _repo.TotalRevue();
            TR.Text = totalrevenue.ToString();
            var vc = _repo.VariableCost();
            VC.Text = vc.ToString();
            var fc = _repo.FixCost();
            FC.Text = fc.ToString();
            var tc = _repo.TotalCost();
            TC.Text = tc.ToString();
            var prof = _repo.TotalProfit();
            P.Text = prof.ToString();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Choise choisewindow = new Choise();
            choisewindow.Show();
            this.Close();
        }
    }
}
