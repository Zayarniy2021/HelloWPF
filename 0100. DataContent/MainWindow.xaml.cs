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

namespace _0100.DataContent
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        

        public MainWindow()
        {
            InitializeComponent();
            
        }

        class Data
        {
            //Привязываемое свойство
            public int? RandomValue { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Data data = null;
            Data data = new Data();
            //data.RandomValue = random.Next(1, 10000);
            data.RandomValue = null;
            this.DataContext = data;
        }
    }
}
