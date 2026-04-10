using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace habit_tracker.src.DB
{
    public class HabitEntry
    {
        public int HabitId { get; set; }
        public required string HabitName { get; set; }
    }
}