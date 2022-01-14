using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
//https://www.codeproject.com/Articles/30905/WPF-DataGrid-Practical-Examples
namespace Lesson5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database database;
        public MainWindow()
        {
            InitializeComponent();

        }



        private void btnDepartRemove_Click(object sender, RoutedEventArgs e)
        {
            //Задача, как проверить, что происходит попытка удалить пустую строку
            System.Data.DataRowView row = (System.Data.DataRowView)dgDepartments.SelectedItem;
            if (row != null)
            {

                //Пример использование relation для проверки связаных данных
                //Console.WriteLine(row.Row.GetChildRows("relation").Length);
                if (row.Row.GetChildRows("relation").Length>0)
                    if (MessageBox.Show($"С этим департаментом связано{row.Row.GetChildRows("relation").Length} записей. Вы уверены, что хотите удалить департамент?","Внимание!",MessageBoxButton.YesNo)==MessageBoxResult.No)
                            {
                        return;
                }
                row.Row.Delete();
                database.dataAdapter2.Update(database.DataSet.Tables["Departments"]);

            }
        }

        private void btnAddDepart_Click(object sender, RoutedEventArgs e)
        {
            System.Data.DataRow newRow = database.DataSet.Tables["Departments"].NewRow();
            if (tbDepartName.Text != "")
            {
                newRow["strDepartName"] = tbDepartName.Text;
                database.DataSet.Tables["Departments"].Rows.Add(newRow);
                //Если подключен обработчки для DataSet, то не нужно вызывать напрямую
                database.dataAdapter2.Update(database.DataSet.Tables["Departments"]);
                tbDepartName.Text = "";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            database = new Database();
            //DepartmentObj.DepUpdate += DepartmentObj_DepUpdate;
            //DataGrid.ItemsSource = listEmployee;
            DataGrid.ItemsSource = database.DataSet.Tables["Employeers"].DefaultView;
            //ListBox.ItemsSource = listDepart;
            dgDepartments.ItemsSource = database.DataSet.Tables["Departments"].DefaultView; ;
            dgDepartments.DisplayMemberPath = "strDepartName";
            //dataGridComboBox.ItemsSource = listDepart;
            dataGridComboBox.ItemsSource = database.DataSet.Tables["Departments"].DefaultView;
            dataGridComboBox.DisplayMemberPath = "strDepartName";
            dataGridComboBox.SelectedValuePath = "Id";

            //dataAdapter для Departers



            //dataGridComboBox.SelectedValueBinding = "Id";

        }
    }
}
