using P01InitialSetup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace P05ChangeTownsNameCasing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            using(SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string changeQuery = @"UPDATE Towns
                                     SET Name = UPPER(Name)
                                     WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

                using (SqlCommand command = new SqlCommand(changeQuery,connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);

                    int affectedRows = command.ExecuteNonQuery();

                    if(affectedRows==0)
                    {
                        Console.WriteLine("No town names were affected.");
                        return;
                    }

                    Console.WriteLine($"{affectedRows} town names were affected.");

                }

                string townsQuery = @" SELECT t.Name 
                                       FROM Towns as t
                                       JOIN Countries AS c ON c.Id = t.CountryCode
                                       WHERE c.Name = @countryName";

                using (SqlCommand command = new SqlCommand(townsQuery, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);

                    List<string> towns = new List<string>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string townName = (string)reader[0];
                            towns.Add(townName);
                        }
                    }

                    Console.WriteLine($"[{string.Join(", ", towns)}]");
                }
            }
        }
    }
}
