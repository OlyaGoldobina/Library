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
    /// Логика взаимодействия для WorkersInformation.xaml
    /// </summary>
    public partial class WorkersInformation : Window
    {
        public WorkersInformation()
        {
            InitializeComponent();
        }

        private void ChangeWorkerInformation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Worker workerwindow = new Worker();
            workerwindow.Show();
            this.Close();
        }
    }
}
