using System;
using System.Collections.Generic;
using System.Data;
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

namespace UsingDataSetForGettingDataFromASMXService
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
        //http://www.cbr.ru/DailyInfoWebServ/DailyInfo.asmx?WSDL
        private void BtnGetData_Click(object sender, RoutedEventArgs e)
        {
            DataSet dataSetInfo = new DataSet();
            var client = new ServiceReference1.DailyInfoSoapClient();
            //dataSetInfo = info.BiCurBacket();
            //dataSetInfo = info.Bauction(new DateTime(2020,4,1), DateTime.Now);
            dataSetInfo = client.BiCurBase(new DateTime(2021, 1, 1), DateTime.Now);
            gridInfo.DataContext = dataSetInfo.Tables[0];

        }
    }
}
