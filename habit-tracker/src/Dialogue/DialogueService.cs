using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace habit_tracker.src.Dialogue
{
    public class DialogueService
    {
        
        public void FormatOutput(string message, OutputType type = OutputType.Standard)
        {
            switch (type)
            {
                case OutputType.Header:
                    Console.WriteLine($"\n\n{message} \n\n");
                    break;
                case OutputType.Subheader:
                    Console.WriteLine($"\n{message}");
                    break;
                case OutputType.Standard:
                    Console.WriteLine($"{message}");
                    break;
            }
        }

        public void PrintLineDivider()
        {
            Console.WriteLine("------------------------------------------\n");
        }
        
        public string GetDateInput(string message)
        {
            var input = GetValidatedInput(message, s => DateTime.TryParseExact(s, "dd-MM-yy",new CultureInfo("en-US"), DateTimeStyles.None, out _), "Invalid date: (Format: dd-mm-yy). Try again or type 0 to return to Main Menu.");
            return input;
        }
        
        public int GetNumberInput(string message)
        {
            var input = GetValidatedInput(message, s => int.TryParse(s, out _), "Invalid number. Try again or type 0 to return to Main Menu.");
            return int.Parse(input);
        }

        public string GetStringInput(string message)
        {
            return GetValidatedInput(message, _ => true, "Invalid value. Try again or type 0 to return to Main Menu.");          
        }

        private string GetValidatedInput(string message, Func<string, bool> validator, string errorMessage)
        {
            FormatOutput(message, OutputType.Header);
            string? input = Console.ReadLine();

            while(string.IsNullOrWhiteSpace(input) || !validator(input))
            {
                FormatOutput(errorMessage, OutputType.Header);
                input = Console.ReadLine();
            }

            return input;
        }
    }

}