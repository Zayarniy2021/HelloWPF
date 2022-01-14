using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MSSQL_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Строка подключение
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Accounts.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //Объект подключение к базе данных
            SqlConnection connection = new SqlConnection(connectionString);            
            connection.Open();
            SqlCommand command = new SqlCommand("Select Id,Login,Password from Accounts", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())//Считываем каждую строчку
                Console.WriteLine("{0}\t{1}\t{2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            connection.Close();
            Console.ReadKey();
        }
    }
}
