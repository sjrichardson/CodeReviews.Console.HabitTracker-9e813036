using habit_tracker.src.DB;
using habit_tracker.src.Dialogue;
using habit_tracker.src.Service;
namespace habit_tracker;
class Program
{
    static void Main(string[] args)
    {
        var dbFile = @"habit-Tracker.db";
        var dialogueService = new DialogueService();
        var habitDatabase = new HabitDatabase(dbFile);
        var habitLogDatabase = new HabitLogDatabase(dbFile);
        var habitService = new HabitService(habitDatabase, dialogueService);
        var habitLogService = new HabitLogService(habitLogDatabase, dialogueService);

        var app = new MainService(habitLogService, habitService, dialogueService);
        app.Run();

    }
}
