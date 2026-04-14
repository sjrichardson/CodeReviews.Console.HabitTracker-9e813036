using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace habit_tracker.src.Dialogue
{
    public class DialogueService
    {
        public void FormatOutput(string message)
        {
            Console.WriteLine($"\n\n{message} \n\n");
        }
    }
}