using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public Phone MyPhone { get; set; } = new Phone();

        public MainWindow()
        {
            InitializeComponent();

            MyPhone = new Phone();


            MyPhone.Name = "Lumia 630";
                MyPhone.Company = new Company { Title = "Microsoft" };
                MyPhone.Price = 1000;
            


            this.DataContext = MyPhone;
        }

        public class Phone
        {
            public string Name { get; set; }
            public Company Company { get; set; } = new Company();
            public decimal Price { get; set; }

            //public event PropertyChangedEventHandler PropertyChanged;
        }

        public class Company: INotifyPropertyChanged
        {
            string title;

            public string Title
            {
                get
                {
                    return title;
                }
                set
                {
                    //if (value != title)
                    {
                        title = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }

        private void btnChangeProperty_Click(object sender, RoutedEventArgs e)
        {
            MyPhone.Company.Title = "Apple";
        }
    }
}
