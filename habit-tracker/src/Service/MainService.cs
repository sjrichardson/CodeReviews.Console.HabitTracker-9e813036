using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using habit_tracker.src.Dialogue;

namespace habit_tracker.src.Service
{
    public class MainService
    {
        private readonly HabitLogService _habitLogService;
        private readonly HabitService _habitService;
        private readonly DialogueService _dialogueService;

        public MainService(HabitLogService habitLogService, HabitService habitService, DialogueService dialogueService)
        {
            _habitLogService = habitLogService;
            _habitService = habitService;
            _dialogueService = dialogueService;
        }

        public void Run()
        {
            bool closeApp = false;
            while (!closeApp)
            {
                closeApp = GetUserInput();
            }
        }

        public bool GetUserInput()
        {
            _dialogueService.FormatOutput("MAIN MENU", OutputType.Header);
            _dialogueService.FormatOutput("Type 0 to Close Application", OutputType.Subheader);
            _dialogueService.FormatOutput("Type 1 to access Habit Editor");
            _dialogueService.FormatOutput("Type 2 to access Habit Log");

            string? command = Console.ReadLine();

            switch (command)
            {
                case "0":
                    _dialogueService.FormatOutput("Goodbye!", OutputType.Header);
                    return true;
                case "1":
                    _habitService.GetUserInput();
                    return false;
                case "2":
                    _habitLogService.GetUserInput();
                    return false;
                default:
                    _dialogueService.FormatOutput("Invalid Command...", OutputType.Header);
                    return false;
            }
        }

    }
}