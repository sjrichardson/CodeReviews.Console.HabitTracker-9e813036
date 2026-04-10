

using System.Data;
using Microsoft.Data.Sqlite;

namespace habit_tracker.src.DB
{
    public class Database
    {
        private readonly string _connectionString; 
        public Database(string dbFilename)
        {
            _connectionString = $"Data Source=../../{dbFilename}";
            CreateTables();
            GetAllHabitEntries();
        }

        public void CreateTables()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"CREATE TABLE IF NOT EXISTS Habit (
                    habitid INTEGER PRIMARY KEY AUTOINCREMENT,
                    habitname TEXT
                    )";
                    command.ExecuteNonQuery();
                    
                    command.CommandText = @"CREATE TABLE IF NOT EXISTS HabitLog (
                    habitlogid INTEGER PRIMARY KEY AUTOINCREMENT,
                    habitid INTEGER,
                    date TEXT,
                    quantity INTEGER,
                    FOREIGN KEY(habitid) REFERENCES habit(habitid)
                    )";

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        

        public void InsertHabit(string habitName)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Habit (habitname) VALUES ($habitName)";
                    command.Parameters.Add(new SqliteParameter("$habitName", habitName));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public List<HabitEntry> GetAllHabitEntries()
        {
            List<HabitEntry> habitEntries = new();
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT habitid, habitname
                                            FROM Habit;";
                   
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                habitEntries.Add(new HabitEntry
                                {
                                    HabitId = reader.GetInt32(reader.GetOrdinal("habitid")),
                                    HabitName = reader.GetString(reader.GetOrdinal("habitname"))
                                });
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found...");
                        }
                    }
                }
                connection.Close();
            }
            return habitEntries;
        }

        public List<HabitLogEntry> GetAllHabitLogEntries()
        {
            return new();
        }

    }
}