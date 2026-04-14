namespace habit_tracker.src.DB
{
    public class HabitDatabase : Database
    {
        public HabitDatabase(string dbFilename) : base(dbFilename)
        {
        }

        protected override void InitializeTable()
        {
           ExecuteNonQuery(
                @"CREATE TABLE IF NOT EXISTS Habit (
                habitid INTEGER PRIMARY KEY AUTOINCREMENT,
                habitname TEXT)");
        }

        public bool InsertHabit(string habitName)
        {
            var habitNameParam = new Dictionary<string, object>
            {
                { "$habitName", habitName }
            };

            if (RecordExists("SELECT COUNT(1) FROM Habit WHERE habitName = $habitName", habitNameParam))
                return false;
            
            ExecuteNonQuery("INSERT INTO Habit (habitname) VALUES ($habitName)", habitNameParam);
            
            return true;
        }

        public bool DeleteHabit(int habitId)
        {
            var habitIdParam = new Dictionary<string, object>
            {
                { "$habitId", habitId }
            };
            
            if (!RecordExists("SELECT COUNT(1) FROM Habit WHERE habitName = $habitName", habitIdParam))
                return false;

            ExecuteNonQuery("DELETE FROM HabitLog WHERE habitid = $habitId", habitIdParam);
            ExecuteNonQuery("DELETE FROM Habit WHERE habitid = $habitId", habitIdParam);

            return true;
        }

        public List<HabitEntry> GetAllHabitEntries()
        {
            return ExecuteQuery(
                "SELECT habitid, habitname FROM Habit;", 
                reader => new HabitEntry
                {
                    HabitId = reader.GetInt32(reader.GetOrdinal("habitid")),
                    HabitName = reader.GetString(reader.GetOrdinal("habitname"))
                });
        }

        
    }
}