using P01InitialSetup;
using System;
using System.Data.SqlClient;

namespace P09IncreaseAgeStoredProcedure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());

            using(SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string uspGetOlderProc = "EXEC usp_GetOlder @id";

                using(SqlCommand command = new SqlCommand(uspGetOlderProc, connection))
                {
                    command.Parameters.AddWithValue("@Id", minionId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int age = (int)reader[1];

                            Console.WriteLine($"{name} - {age} years old");
                        }
                    }
                }
            }
        }
    }
}
