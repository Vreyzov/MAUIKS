using HabitTrackerApp.Models;
using System.Text.Json;
using Microsoft.Maui.Storage;


namespace HabitTrackerApp.Services;

public class HabitDataService
{
    private const string FileName = "habits.json";
    private string FilePath => Path.Combine(FileSystem.AppDataDirectory, FileName);

    private List<Habit> habits = new();

    public HabitDataService()
    {
        LoadHabits();
    }

    public List<Habit> GetHabits() => habits;

    public void AddHabit(Habit habit)
    {
        habits.Add(habit);
        SaveHabits();
    }

    public void UpdateHabit(Habit habit)
    {
        var index = habits.FindIndex(h => h.Id == habit.Id);
        if (index >= 0)
        {
            habits[index] = habit;
            SaveHabits();
        }
    }

    private void LoadHabits()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            habits = JsonSerializer.Deserialize<List<Habit>>(json) ?? new();
        }
    }

    private void SaveHabits()
    {
        string json = JsonSerializer.Serialize(habits);
        File.WriteAllText(FilePath, json);
    }

}

