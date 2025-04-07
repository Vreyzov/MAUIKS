using HabitTrackerApp.Models;
using HabitTrackerApp.Services;
using System.Collections.ObjectModel;

namespace HabitTrackerApp.ViewModels;

public class HabitListViewModel
{
    public ObservableCollection<Habit> Habits { get; set; } = new();

    public HabitListViewModel()
    {
        var service = new HabitDataService();
        var data = service.GetHabits();
        foreach (var habit in data)
            Habits.Add(habit);
    }
}
