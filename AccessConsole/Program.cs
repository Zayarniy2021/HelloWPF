using System;
using System.Data.OleDb;

namespace AccessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //OleDbConnectionStringBuilder oleDbConnectionStringBuilder = new OleDbConnectionStringBuilder();

            //Строка подключение
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database5.accdb";
            //Объект подключение к базе данных
            OleDbConnection connection = new OleDbConnection(connectionString);
            //connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM Ежедневник", connection);
                OleDbDataReader reader = command.ExecuteReader();
                //OleDbDataReader reader = command.ExecuteScalar();
                while (reader.Read())//Считываем каждую строчку
                    Console.WriteLine("{0}\t{1}\t{2}",(int)reader["Код"], reader.GetDateTime(1), reader.GetString(2));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection?.Close();
            }
            Console.ReadKey();
        }
    }
}
