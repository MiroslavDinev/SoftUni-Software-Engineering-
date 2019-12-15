using P01InitialSetup;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace P04AddMinion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] minionArgs = Console.ReadLine().Split().ToArray();
            string[] villainArgs = Console.ReadLine().Split().ToArray();

            string minionName = minionArgs[1];
            int minionAge = int.Parse(minionArgs[2]);
            string townName = minionArgs[3];

            string villainName = villainArgs[1];

            using(SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                int? townId = GetTownByName(townName, connection);

                if (townId == null)
                {
                    string addTownQuery = @"INSERT INTO Towns (Name) VALUES (@townName)";

                    using (SqlCommand commandForTown = new SqlCommand(addTownQuery, connection))
                    {
                        commandForTown.Parameters.AddWithValue("@townName", townName);
                        commandForTown.ExecuteNonQuery();
                        Console.WriteLine($"Town {townName} was added to the database.");
                    }
                }

                townId = GetTownByName(townName, connection);

                int? villainId = GetVillainByName(villainName, connection);

                if (villainId == null)
                {
                    string addVilainQuery = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

                    using (SqlCommand commandForVillain = new SqlCommand(addVilainQuery, connection))
                    {
                        commandForVillain.Parameters.AddWithValue("@villainName", villainName);
                        commandForVillain.ExecuteNonQuery();
                        Console.WriteLine($"Villain {villainName} was added to the database.");
                    }
                }

                villainId = GetVillainByName(villainName, connection);

                AddMinion(minionName, minionAge, connection, townId);

                int minionId = GetMinionId(minionName, connection);

                string addMinionToVillain = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

                using(SqlCommand commandToAddMinionToVillain = new SqlCommand(addMinionToVillain, connection))
                {
                    commandToAddMinionToVillain.Parameters.AddWithValue("@villainId", villainId);
                    commandToAddMinionToVillain.Parameters.AddWithValue("@minionId", minionId);
                    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
                }
            }
        }

        private static int GetMinionId(string minionName, SqlConnection connection)
        {
            string minionIdQuery = @"SELECT Id FROM Minions WHERE Name = @Name";

            using (SqlCommand commandForMinionId = new SqlCommand(minionIdQuery, connection))
            {
                commandForMinionId.Parameters.AddWithValue("@Name", minionName);
                return (int) commandForMinionId.ExecuteScalar();
            }
        }

        private static void AddMinion(string minionName, int minionAge, SqlConnection connection, int? townId)
        {
            string addMinionQuery = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

            using (SqlCommand commandForMinion = new SqlCommand(addMinionQuery, connection))
            {
                commandForMinion.Parameters.AddWithValue("@name", minionName);
                commandForMinion.Parameters.AddWithValue("@age", minionAge);
                commandForMinion.Parameters.AddWithValue("@townId", townId);
                commandForMinion.ExecuteNonQuery();
            }
        }

        private static int? GetVillainByName(string villainName, SqlConnection connection)
        {
            string villainQuery = @"SELECT Id FROM Villains WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(villainQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", villainName);
                return (int?)command.ExecuteScalar();
            }
        }

        private static int? GetTownByName(string townName, SqlConnection connection)
        {
            string townQuery = @"SELECT Id FROM Towns WHERE Name = @townName";

            using (SqlCommand command = new SqlCommand(townQuery, connection))
            {
                command.Parameters.AddWithValue("@townName", townName);
                int? townId = (int?)command.ExecuteScalar();

                return (int?)command.ExecuteScalar();
            }
        }
    }
}
