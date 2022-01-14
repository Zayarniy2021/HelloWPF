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

namespace _60.AccessToResourcesFromCode
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /*Для поиска ресурсов используется метод FindResource(). В примере выше поиск ресурсов производится сначала в панели, затем на уровне окна, а в конце – на уровне приложения. Если поиск не обнаруживает запрошенные ресурсы на одном из уровней, он продолжается на уровне выше, пока не обнаружит искомое значение  
        */
        /*
        private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            lbResult.Items.Add(pnlMain.FindResource("strPanel").ToString());
            lbResult.Items.Add(this.FindResource("strWindow").ToString());
            lbResult.Items.Add(Application.Current.FindResource("strApp").ToString());
        }
        */
        /*
В принципе, поиск ресурсов в предыдущем примере можно выполнять всегда на уровне панели
*/



private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            lbResult.Items.Add(pnlMain.FindResource("strPanel").ToString());
            lbResult.Items.Add(pnlMain.FindResource("strWindow").ToString());
            lbResult.Items.Add(pnlMain.FindResource("strApp").ToString());
        }

  

    }

}

