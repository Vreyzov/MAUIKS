using HabitTrackerApp.Models;
using HabitTrackerApp.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HabitTrackerApp.ViewModels;

public class AddHabitViewModel : INotifyPropertyChanged
{
    public string Title { get; set; }
    public string SelectedFrequency { get; set; }
    public TimeSpan ReminderTime { get; set; } = new(8, 0, 0);

    public List<string> Frequencies { get; } = new() { "Ежедневно", "Через день", "Раз в неделю" };

    public async Task<bool> SaveHabit()
    {
        if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(SelectedFrequency))
            return false;

        var habit = new Habit
        {
            Title = Title,
            Frequency = SelectedFrequency,
            ReminderTime = ReminderTime
        };

        var service = new HabitDataService();
        service.AddHabit(habit);

        return true;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
