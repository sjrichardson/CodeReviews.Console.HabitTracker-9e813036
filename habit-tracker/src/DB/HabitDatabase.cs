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

        public void InsertHabit(string habitName)
        {
            if (RecordExists("SELECT COUNT(1) FROM Habit WHERE habitName = $habitName",
                new Dictionary<string, object> 
                { 
                    { "$habitName", habitName } 
                }))
                return;
            ExecuteNonQuery(
                "INSERT INTO Habit (habitname) VALUES ($habitName)", 
                new Dictionary<string, object>
                {
                    {"$habitName", habitName}
                });
        }

        public void DeleteHabit(int habitId)
        {
            
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