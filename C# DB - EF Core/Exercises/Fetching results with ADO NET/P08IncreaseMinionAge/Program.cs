using P01InitialSetup;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace P08IncreaseMinionAge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] inputIds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            using(SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string updateMinionsQuery = @" UPDATE Minions
                                               SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                               WHERE Id = @Id";

                for (int i = 0; i < inputIds.Length; i++)
                {
                    using (SqlCommand command = new SqlCommand(updateMinionsQuery, connection))
                    {
                        
                        command.Parameters.AddWithValue("@Id", inputIds[i]);
                        command.ExecuteNonQuery();
                        
                    }
                }

                string getMinionsQuery = @"SELECT Name, Age FROM Minions";

                using(SqlCommand command = new SqlCommand(getMinionsQuery, connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int age = (int)reader[1];

                            Console.WriteLine($"{name} {age}");
                        }
                    }
                }
            }
        }
    }
}
