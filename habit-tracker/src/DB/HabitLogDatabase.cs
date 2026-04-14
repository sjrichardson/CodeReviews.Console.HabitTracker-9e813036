namespace habit_tracker.src.DB
{
    public class HabitLogDatabase : Database
    {
        public HabitLogDatabase(string dbFilename) : base(dbFilename)
        {
        }
        protected override void InitializeTable()
        {
            ExecuteNonQuery(
                @"CREATE TABLE IF NOT EXISTS HabitLog (
                    habitlogid INTEGER PRIMARY KEY AUTOINCREMENT,
                    habitid INTEGER,
                    date TEXT,
                    quantity INTEGER,
                    FOREIGN KEY(habitid) REFERENCES habit(habitid))");
        }
        public List<HabitLogEntry> GetAllHabitLogEntries()
        {
            var query = 
                @"SELECT 
                    hl.habitlogid,
                    h.habitname, 
                    hl.date, 
                    hl.quantity 
                FROM HabitLog hl
                INNER JOIN Habit h on hl.habitid = h.habitid;";
            
            return ExecuteQuery(query, 
                reader => new HabitLogEntry
                {
                    HabitLogId = reader.GetInt32(reader.GetOrdinal("habitlogid")),
                    HabitName = reader.GetString(reader.GetOrdinal("habitname")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
                    Date = DateTime.Parse(reader.GetString(reader.GetOrdinal("date")))
                });

        }
    }
}