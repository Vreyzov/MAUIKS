using System.Collections.ObjectModel;
using System.ComponentModel;
using HabitTrackerApp.Models;
using HabitTrackerApp.Services;

namespace HabitTrackerApp.ViewModels
{
    public class StatisticsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<HabitStats> _stats = new();

        public ObservableCollection<HabitStats> Stats
        {
            get => _stats;
            set
            {
                if (_stats != value)
                {
                    _stats = value;
                    OnPropertyChanged(nameof(Stats));
                }
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
