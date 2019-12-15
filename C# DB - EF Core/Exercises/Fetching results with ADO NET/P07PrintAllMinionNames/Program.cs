using P01InitialSetup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace P07PrintAllMinionNames
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> allMinionNames = new List<string>();

            using(SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string minionNamesQuery = @"SELECT Name FROM Minions";

                using(SqlCommand command = new SqlCommand(minionNamesQuery,connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string minionName = (string)reader[0];
                            allMinionNames.Add(minionName);
                        }
                    }
                }
            }

            for (int i = 0; i < allMinionNames.Count/2; i++)
            {
                Console.WriteLine(allMinionNames[i]);
                Console.WriteLine(allMinionNames[allMinionNames.Count-1-i]);
            }

            if(allMinionNames.Count/2 !=0)
            {
                Console.WriteLine(allMinionNames[allMinionNames.Count/2]);
            }
        }
    }
}
