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

namespace WPFBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Person person = new Person();

        public MainWindow()
        {
            InitializeComponent();
          //  tbText.DataContext = person;
        }

        private void btnButton_Click(object sender, RoutedEventArgs e)
        {
            //person.Name = "Petr";            
        }
    }
}
