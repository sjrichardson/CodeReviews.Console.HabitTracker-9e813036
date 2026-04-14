using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using habit_tracker.src.DB;
using habit_tracker.src.Dialogue;

namespace habit_tracker.src.Service
{
    public class HabitService
    {
        private readonly HabitDatabase _habitLogDatabase;
        private readonly DialogueService _dialogueService; 

        public HabitService(HabitDatabase habitDatabase, DialogueService dialogueService)
        {
            _habitLogDatabase = habitDatabase;
            _dialogueService = dialogueService;
        }
    }
}