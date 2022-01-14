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

namespace CodeBehind_BindingData
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Employee employee=new Employee() { FIO = "Иванов Иван Иванович", Age = 30 };
        BindingExpression bindingExpression;

        public MainWindow()
        {

            InitializeComponent();
            Binding binding = new Binding();                        //объект привязки
            binding.Source = employee;                       // элемент-источник привязки
            binding.Path = new PropertyPath("FIO");                // свойство элемента-источника
            binding.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
            binding.Mode = BindingMode.TwoWay;
            //cbBox.SetBinding(ComboBox.DataContextProperty, binding); // установка привязки для элемента-приемника (целевой объект привязки)
            tbText.SetBinding(TextBox.TextProperty, binding);
            //Ручное управление объектом привязки            
            bindingExpression = tbText.GetBindingExpression(TextBox.TextProperty);                      
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            employee.FIO = "Петров Петр Петрович";
            bindingExpression.UpdateTarget();
            //bindingExpression.UpdateSource();
        }
    }
}
