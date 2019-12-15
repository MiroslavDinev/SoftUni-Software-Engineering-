using P01InitialSetup;
using System;
using System.Data.SqlClient;

namespace P06RemoveVillain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            using(SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string villainNameQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";

                string villainName;

                using(SqlCommand command = new SqlCommand(villainNameQuery, connection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);
                    villainName = (string)command.ExecuteScalar();

                    if(villainName == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }
                }

                Console.WriteLine($"{villainName} was deleted.");

                string deleteMinionsQuery = @"DELETE FROM MinionsVillains 
                                              WHERE VillainId = @villainId";

                using(SqlCommand command = new SqlCommand(deleteMinionsQuery, connection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);
                    int deletedMinions = (int)command.ExecuteNonQuery();

                    Console.WriteLine($"{deletedMinions} minions were released.");
                }

                string deleteVillainQuery = @"DELETE FROM Villains
                                              WHERE Id = @villainId";

                using(SqlCommand command = new SqlCommand(deleteMinionsQuery,connection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
