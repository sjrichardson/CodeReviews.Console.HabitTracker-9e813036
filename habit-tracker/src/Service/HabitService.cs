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
        private readonly HabitDatabase _habitDatabase;
        private readonly DialogueService _dialogueService; 

        public HabitService(HabitDatabase habitDatabase, DialogueService dialogueService)
        {
            _habitDatabase = habitDatabase;
            _dialogueService = dialogueService;
        }

        public void DisplayHabits()
        {
            _dialogueService.PrintLineDivider();
            _dialogueService.FormatOutput("Habits", OutputType.Header);
            var habitEntries = _habitDatabase.GetAllHabitEntries();

            foreach (var habit in habitEntries)
            {
                _dialogueService.FormatOutput($"Habit Id: {habit.HabitId} Habit Name: {habit.HabitName}");
            }

        }

        public void GetUserInput()
        {
            _dialogueService.PrintLineDivider();
            _dialogueService.FormatOutput("HABIT MENU", OutputType.Header);
            _dialogueService.FormatOutput("Type 0 to return to Main Menu", OutputType.Subheader);
            _dialogueService.FormatOutput("Type 1 to View All Habits");
            _dialogueService.FormatOutput("Type 2 to Insert Habit");
            _dialogueService.FormatOutput("Type 3 to Delete Habit");
            _dialogueService.FormatOutput("Type 4 to Update Habit");
            _dialogueService.PrintLineDivider();

            string? command = Console.ReadLine();

            switch (command)
            {
                case "0":
                    return;
                case "1":
                    InsertHabit();
                    break;
                    
            }
        }


        public void InsertHabit()
        {
            _dialogueService.PrintLineDivider();
            _dialogueService.FormatOutput("Please provide the name of the habit or type 0 to cancel.", OutputType.Header);
            string? name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                _dialogueService.FormatOutput("Habit name cannot be empty. Please provide a name or type 0 to cancel.", OutputType.Header);
                name = Console.ReadLine();
            }

            if (name == "0")
                return;

            var insertStatus = _habitDatabase.InsertHabit(name);

            if (!insertStatus)
                _dialogueService.FormatOutput($"The habit name {name} already exists!");
            else _dialogueService.FormatOutput($"{name} added successfully!");
        }

        public void DeleteHabit()
        {
            _dialogueService.PrintLineDivider();
            _dialogueService.FormatOutput("Please provide the Id of the habit you would like to delete", OutputType.Header);
            
        }
    }
}