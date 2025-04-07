using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTrackerApp.Models
{
    public class HabitStats
    {
        public string Title { get; set; }
        public int CompletionsLast7Days { get; set; }
        public double Progress { get; set; } // От 0 до 1, для прогресс-бара
    }
}
