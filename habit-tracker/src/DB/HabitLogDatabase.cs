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
            return ExecuteQuery(
                @"SELECT 
                    hl.habitlogid,
                    h.habitname, 
                    hl.date, 
                    hl.quantity 
                FROM HabitLog hl
                INNER JOIN Habit h on hl.habitid = h.habitid;", 
                reader => new HabitLogEntry
                {
                    HabitLogId = reader.GetInt32(reader.GetOrdinal("habitlogid")),
                    HabitName = reader.GetString(reader.GetOrdinal("habitname")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
                    Date = DateTime.Parse(reader.GetString(reader.GetOrdinal("date")))
                });

        }

        public bool DeleteHabitLogEntry(int habitLogId)
        {
            var habitLogIdParam = new Dictionary<string, object>
            {
                { "$habitLogId", habitLogId }
            };

            if (!RecordExists("SELECT COUNT(1) FROM HabitLog WHERE habitlogid = $habitLogId", habitLogIdParam))
                return false;

            ExecuteNonQuery(
                "DELETE FROM HabitLog WHERE habitlogid = $habitLogId",
                habitLogIdParam);
            
            return true;
        }
    }
}