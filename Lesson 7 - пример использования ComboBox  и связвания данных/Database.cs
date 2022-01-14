using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Database
    {
        public DataSet DataSet { get; private set; } = new DataSet();
        public SqlDataAdapter dataAdapter1  { get; private set;}  = new SqlDataAdapter();//For Employeers
        public SqlDataAdapter dataAdapter2 { get; private set; } = new SqlDataAdapter();//For Departments
        public Database()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Employeers.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            //Объект-промежуточный адаптер между базой данных и набором данных(dataSet)
            dataAdapter1.SelectCommand = new SqlCommand("Select * from Employeers", sqlConnection);// order by код");
            //Загружаем данные из базы данных таблицы Employeers. В DataSet так же задаем название таблице Employeers
            dataAdapter1.Fill(DataSet, "Employeers");
            dataAdapter2.SelectCommand = new SqlCommand("Select * from Departments", sqlConnection);// order by код");
            //Загружаем данные из базы данных таблицы Departments. В DataSet так же задаем название таблице Deparments
            dataAdapter2.Fill(DataSet, "Departments");
            //Связи позволяют связать данные различных таблиц для дальнейшей работы с ними
            //Но в данном примере можно обойтись без связей
            //Подбробней 
            DataRelation rel;
            DataColumn table1_col;
            DataColumn table2_col;
            table1_col = DataSet.Tables["Employeers"].Columns["intDepartment"];
            table2_col = DataSet.Tables["Departments"].Columns["Id"];
            rel = new DataRelation("relation", table2_col, table1_col);
            //DataSet.Relations.Add(rel);//Если установлена связь и будет запись с элементом, которого нет, то будет страшная ошибка!
            //Подробней про использование связанных данных можно почитать например Sceppa D. Программирование на ADO.NET 2.0. стр. 294
            //*******************************************
            SqlCommand command;
            command = new SqlCommand(@"INSERT INTO Departments (strDepartName) VALUES (@DepartName); SET @ID = @@IDENTITY;", sqlConnection);
            command.Parameters.Add("@DepartName", SqlDbType.NVarChar, -1, "strDepartName");
            SqlParameter param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            param.Direction = ParameterDirection.Output;
            dataAdapter2.InsertCommand = command;            
            //delete
            command = new SqlCommand("DELETE FROM Departments WHERE Id = @ID", sqlConnection);
            param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            dataAdapter2.DeleteCommand = command;

            // update
            command = new SqlCommand(@"UPDATE Departments SET strDepartName = @DepartName WHERE ID = @ID", sqlConnection);
            command.Parameters.Add("@DepartName", SqlDbType.NVarChar, -1, "strDepartName");
            param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            param.SourceVersion = DataRowVersion.Original;
            dataAdapter2.UpdateCommand = command;

            //DataTable dt = new DataTable();
            //dataAdapter.Fill(dt);
            //dt.DefaultView.RowFilter = "FIO='My'";//Позволяет настроить DefaultView
            //dt.DefaultView.Sort = "FIO DESC, Email ASC";
            //peopleDataGrid.DataContext = dt.DefaultView;

            //insert
            command = new SqlCommand(@"INSERT INTO Employeers (strFirstName, intSalary, intDepartment, strLastName,dtBirthDay) VALUES (@FName,@Salary,@Department,@LName, @Birthday); SET @ID = @@IDENTITY;", sqlConnection);
            command.Parameters.Add("@FName", SqlDbType.NVarChar, 50, "strFirstName");
            command.Parameters.Add("@Birthday", SqlDbType.DateTime2, -1, "dtBirthDay");
            command.Parameters.Add("@LName", SqlDbType.NVarChar, 50, "strLastName");
            command.Parameters.Add("@Department", SqlDbType.Int, -1, "intDepartment");
            command.Parameters.Add("@Salary", SqlDbType.Int, -1, "intSalary");
            param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            param.Direction = ParameterDirection.Output;
            dataAdapter1.InsertCommand = command;
            //Update
            command = new SqlCommand(@"UPDATE Employeers SET strFirstName=@FName, intSalary=@Salary, intDepartment=@Department, strLastName=@LName,dtBirthDay=@Birthday WHERE ID=@ID", sqlConnection);
            command.Parameters.Add("@FName", SqlDbType.NVarChar, 50, "strFirstName");
            command.Parameters.Add("@Birthday", SqlDbType.DateTime2, -1, "dtBirthDay");
            command.Parameters.Add("@LName", SqlDbType.NVarChar, 50, "strLastName");
            command.Parameters.Add("@Department", SqlDbType.Int, -1, "intDepartment");
            command.Parameters.Add("@Salary", SqlDbType.Int, -1, "intSalary");
            param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            param.SourceVersion = DataRowVersion.Original;//К какой версии строк преминять (подбромнее Seppe. ADO.NET 2.0)
            dataAdapter1.UpdateCommand = command;
            //Обновление данных непосредственно в DataGrid (если это подключать, то не нужно вызывать Update в обработчике нажатия кнопки
            DataSet.Tables["Departments"].RowChanged += Database_RowChanged;
            DataSet.Tables["Employeers"].RowChanged += Database_RowChanged2;
            //DataSet.Tables["Departments"].TableNewRow += Database_TableNewRow;
        }


        //Методы для обновление данных непосредственно в DataGrid
        private void Database_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
               //dataAdapter.Update(DataSet.Tables["Departments"]);
            Console.WriteLine("Data have been inserted");//Почему вызывается три раза?
        }

        private void Database_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            try
            {
               // dataAdapter1.Update(DataSet.Tables["Departments"]);
                Console.WriteLine("Departments data have been updated");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void Database_RowChanged2(object sender, DataRowChangeEventArgs e)
        {
           // dataAdapter1.Update(DataSet.Tables["Employeers"]);
            Console.WriteLine("Employeers data have been updated");
        }
    }

}
