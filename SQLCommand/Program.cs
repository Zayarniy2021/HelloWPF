using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQLCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|SampleDatabase.mdf;Integrated Security=True";
            //ExecuteNonQuery
            string createExpression = @"CREATE TABLE[dbo].[People]  (
                                    [Id] INT IDENTITY(1, 1) NOT NULL,
                                    [FIO] NVARCHAR(MAX),
                                    [Birthday] NVARCHAR(MAX) NULL,
                                    [Email]    NVARCHAR(100) NULL,
                                    [Phone]    NVARCHAR(MAX) NULL,
                                    CONSTRAINT[PK_dbo.People] PRIMARY KEY CLUSTERED([Id] ASC) 
                                );";
            string createStoredProc = @"CREATE PROCEDURE [dbo].[sp_GetPeople] AS SELECT * FROM People;";
            string sqlExpression = @"INSERT INTO People (FIO, Birthday,Email,Phone) VALUES ('Иванов Иван Иванович', '18.10.2001', 'somebody@gmail.com', '89164444444' );
                                     INSERT INTO People(FIO, Birthday, Email, Phone) VALUES('Петров Петр Петрович', '15.01.2001', 'somebody@mail.com', '8916555555')";

            int number = 0;
            #region ExecureNonQuery
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command;
                try
                {
                    command = new SqlCommand(createExpression, connection);
                    Console.WriteLine("Создаем базу данных");//База данных будет создаваться только один раз
                    number = command.ExecuteNonQuery();
                    Console.WriteLine("Результат выполнения команды:{0}", number);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("***Error***");
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
                try
                {
                    Console.WriteLine("Создаем хранимую процедуру");
                    command = new SqlCommand(createStoredProc, connection);
                    number = command.ExecuteNonQuery();
                    Console.WriteLine("Результат выполнения команды:{0}", number);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("***Error***");
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
                try
                {
                    Console.WriteLine("Выполняем вставку данных");
                    command = new SqlCommand(sqlExpression, connection);
                    number = command.ExecuteNonQuery();
                    Console.WriteLine("Результат выполнения команды:{0}", number);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("***Error***");
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
                Console.WriteLine("Удаляем таблицу");
                try
                {
                    //*******************************Закоментриуйте это, для просмотре дальнейших примеров*****************************
                    //command = new SqlCommand("Drop Table [dbo].[People]", connection); number = command.ExecuteNonQuery();
                    Console.WriteLine("Результат выполнения команды:{0}", number);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("***Error***");
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
                Console.ReadKey();
            }
            #endregion
            #region ExecuteScalar
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlExpression = "SELECT COUNT(*) FROM People";
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    Console.WriteLine("Выбираем данные ExecuteScalar");
                    int cnt = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("Результат выполнения команды:{0}", cnt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("***Error***");
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }

            sqlExpression = @"INSERT INTO People (FIO, Birthday,Email,Phone) output INSERTED.ID VALUES ('Сидоров Сидор Сидорович', '16.10.2007', 'somebody@gmail.com', '89164444444' );";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Вставляем данные в базу данных");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    var vId = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("Результат выполнения команды:{0}", vId);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("***Error***");
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }

            #endregion

            #region ExecuteReader

            try
            {
                sqlExpression = "SELECT * FROM People";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    if (reader.HasRows)        // если есть данные
                    {
                        while (reader.Read())  // построчно считываем данные
                        {
                            var vId = Convert.ToInt32(reader.GetValue(0));
                            var vFIO = reader.GetString(1);
                            var vEmail = reader["Email"];
                            var vPhone = reader.GetString(reader.GetOrdinal("Phone"));
                            Console.WriteLine($"{vId,4}{vFIO,20}{vEmail,20}{vPhone,20}");
                        }//0 fio email phone
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("***Error***");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            try
            {
                sqlExpression = "[dbo].[sp_GetPeople]";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    // указываем, что команда представляет хранимую процедуру
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    if (reader.HasRows)       // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            var vId = Convert.ToInt32(reader.GetValue(0));
                            var vFIO = reader.GetString(1);
                            var vEmail = reader["Email"];
                            var vPhone = reader.GetString(reader.GetOrdinal("Phone"));
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("***Error***");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }


            #endregion
            Console.ReadKey();
        }
    }
}
