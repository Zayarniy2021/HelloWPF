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

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Важно
        public List<Man> List { get; private set; } = new List<Man>();
        public MainWindow()
        {
            InitializeComponent();
            List.Add(new Man());
            List.Add(new Man());
            List.Add(new Man());
            peopleDataGrid.ItemsSource = List;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Man man = new Man();
            man = (Man)peopleDataGrid.SelectedItem;
            EditWindow editWindow = new EditWindow(man);
            editWindow.ShowDialog();
            if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value==true)
            {
                //Используем ID для нахождения человека в списке - это тоже не правильно
                //Используется только для демонстрации работы

                List[man.ID] = editWindow.Man;
                peopleDataGrid.ItemsSource = null;
                peopleDataGrid.ItemsSource = List;
            }
        }
    }
}
