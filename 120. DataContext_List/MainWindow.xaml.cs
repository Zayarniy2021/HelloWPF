using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
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

namespace _120.DataContext_List
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyClass my;
        public MainWindow()
        {
            InitializeComponent();
             my= new MyClass();
            
            this.DataContext = my;
        }

        class MyClass
        {
            public ObservableCollection<string> List { get; set; }
                = new ObservableCollection<string>() { "123", "233", "234" };

            public string[] List2 { get; set; }
                = new string[] { "123", "233", "234" };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            my.List.RemoveAt(0);
            //this.DataContext = null;
            //this.DataContext = my;
        }
    }
}
