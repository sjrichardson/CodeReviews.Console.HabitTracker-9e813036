using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace habit_tracker.src.DB
{
    public class HabitLogEntry
    {
        public int HabitLogId { get; set; }
        public required string HabitName { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
    }
}