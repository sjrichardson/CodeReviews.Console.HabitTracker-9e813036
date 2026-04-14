using habit_tracker.src.DB;
using habit_tracker.src.Dialogue;
namespace habit_tracker.src.Service
{
    public class HabitLogService
    {
        private readonly HabitLogDatabase _habitLogDatabase;
        private readonly DialogueService _dialogueService; 

        public HabitLogService(HabitLogDatabase habitLogDatabase, DialogueService dialogueService)
        {
            _habitLogDatabase = habitLogDatabase;
            _dialogueService = dialogueService;
        }
    }
}