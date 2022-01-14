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

namespace DataContext2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Phone MyPhone { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            MyPhone = new Phone
            {
                Name = "Lumia 630",
                Company = new Company { Title = "Microsoft" },
                Price = 1000
            };


            this.DataContext = MyPhone;
        }

        public class Phone
        {
            public string Name { get; set; }
            public Company Company { get; set; }
            public decimal Price { get; set; }
        }

        public class Company
        {
            public string Title { get; set; }
        }

        private void btnChangeProperty_Click(object sender, RoutedEventArgs e)
        {
            MyPhone.Company.Title = "Apple";
        }
    }
}
