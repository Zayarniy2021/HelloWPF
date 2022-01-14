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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _40.HelloWPF_Partial_and_Event
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainGrid.MouseUp += MainGrid_MouseUp1;
        }

        private void MainGrid_MouseUp1(object sender, MouseButtonEventArgs e)
        {
            Title = "Координаты " + e.GetPosition(this).ToString();
        }

        private void MainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Координаты " + e.GetPosition(this).ToString());
        }
    }
}
