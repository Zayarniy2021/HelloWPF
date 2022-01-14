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

namespace CheckBoxValueConverterOverCode2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Binding bind1 = new Binding();
            bind1.ElementName = "tblockOne";
            bind1.Path = new PropertyPath("Text");
            bind1.Converter = new YesNoToBooleanConverter();

            Binding bind2 = new Binding();
            bind2.ElementName = "txtValue";
            bind2.Path = new PropertyPath("Text");
            bind2.Converter = new YesNoToBooleanConverter2();

            //Привязка будет работать с последним элементом!
            cboxOne.SetBinding(CheckBox.IsCheckedProperty, bind1);
            cboxOne.SetBinding(CheckBox.IsCheckedProperty, bind2);
            tblockOne.SetBinding(TextBlock.TextProperty, bind2);
            //txtValue.SetBinding(TextBox.TextProperty, bind);
        }
    }
}
