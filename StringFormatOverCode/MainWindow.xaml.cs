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

namespace StringFormatOverCode
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Binding bind = new Binding();
            bind.ElementName = "tbSource";
            bind.Path = new PropertyPath("Text");            
            bind.StringFormat = "Зарплата {0} руб.";            
            tbDistance.SetBinding(TextBlock.TextProperty, bind);
        }
    }
}
