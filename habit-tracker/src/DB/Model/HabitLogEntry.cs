namespace habit_tracker.src.DB;
public class HabitLogEntry
{
    public int HabitLogId { get; set; }
    public required string HabitName { get; set; }
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
}