using HabitTrackerApp.ViewModels;
using HabitTrackerApp.Models;
using HabitTrackerApp.Services;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace HabitTrackerApp.Views;

public partial class StatisticsPage : ContentPage
{
    StatisticsViewModel viewModel = new();

    public StatisticsPage()
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.LoadStats();
    }

    // ViewModels/StatisticsViewModel.cs

    public class StatisticsViewModel : ObservableObject
    {
        public ObservableCollection<HabitStats> Stats { get; set; } = new();

        public void LoadStats()
        {
            var service = new HabitDataService();
            var habits = service.GetHabits();

            Stats.Clear();
            foreach (var h in habits)
            {
                int count = h.CompletionHistory.Count(d => d >= DateTime.Today.AddDays(-6));
                Stats.Add(new HabitStats
                {
                    Title = h.Title,
                    CompletionsLast7Days = count,
                    Progress = count / 7.0
                });
            }
        }
    }

}