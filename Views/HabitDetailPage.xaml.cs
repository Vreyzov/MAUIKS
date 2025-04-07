using HabitTrackerApp.Models;
using HabitTrackerApp.Services;
using Microsoft.Maui.Controls;

namespace HabitTrackerApp.Views
{
    [QueryProperty(nameof(HabitId), "HabitId")]  // Указываем свойство для привязки
    public partial class HabitDetailPage : ContentPage
    {
        public string HabitId { get; set; }

        HabitDataService dataService = new();
        Habit currentHabit;

        public HabitDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Получаем привычку по переданному HabitId
            currentHabit = dataService.GetHabits().FirstOrDefault(h => h.Id.ToString() == HabitId);
            BindingContext = currentHabit;  // Привязываем к контексту
        }

        private void OnMarkDoneClicked(object sender, EventArgs e)
        {
            // Отмечаем привычку как выполненную
            currentHabit.LastCompletedDate = DateTime.Now;
            currentHabit.CompletionHistory.Add(DateTime.Now);
            dataService.UpdateHabit(currentHabit);
            DisplayAlert("Готово", "Привычка отмечена как выполненная!", "Ок");
        }
    }
}
