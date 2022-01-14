using System;
using System.Data;
using System.Data.OleDb;

namespace AccessConsoleDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            //Строка подключение
            string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0;Data Source = Database5.accdb";
            //Объект-промежуточный адаптер между базой данных и набором данных(dataSet)
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter("Select * from Ежедневник order by Дата ASC", connectionString);
            DataSet dataSet = new DataSet();
            //Загружаем данные из базы данных
            dataAdapter.Fill(dataSet);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                Console.WriteLine("{0}\t{1}\t{2}", (int)dataRow[0], (DateTime)dataRow[1], (string)dataRow[2]);
            Console.ReadKey();
        }
    }
}
