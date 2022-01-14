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

namespace CheckBoxValueConverterOverCode
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Нужно попробовать перевернуть логику
            Binding bind = new Binding();
            bind.ElementName = "cboxOne";
            bind.Path = new PropertyPath("IsChecked");
            bind.Converter = new YesNoToBooleanConverter();
            tblockOne.SetBinding(TextBlock.TextProperty, bind);
            txtValue.SetBinding(TextBox.TextProperty, bind);
        }
    }
}
