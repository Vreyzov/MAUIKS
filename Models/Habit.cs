using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTrackerApp.Models
{
    // Models/Habit.cs
    public class Habit
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Frequency { get; set; } // Ежедневно, еженедельно и т.д.
        public TimeSpan? ReminderTime { get; set; }
        public DateTime? LastCompletedDate { get; set; }
        public List<DateTime> CompletionHistory { get; set; } = new();
    }

}
