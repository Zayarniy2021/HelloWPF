using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GridView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> items { get; set; } 

        public MainWindow()
        {
            InitializeComponent();
            items = new ObservableCollection<Employee>();
            items.Add(new Employee() { Name = "Петя", Age = 42, Salary = 25000 });
            items.Add(new Employee() { Name = "Коля", Age = 39, Salary = 45000 });
            for(int i=0;i<10;i++)
                items.Add(new Employee() { Name = "Иван", Age = 7, Salary = 33000+i });   
            
            dgEmployee.ItemsSource = items;
        }
    }
    public class Employee:INotifyPropertyChanged
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int Salary { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
