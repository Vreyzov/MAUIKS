using HabitTrackerApp.Models;
using HabitTrackerApp.Services;
using Microsoft.Maui.Controls;

namespace HabitTrackerApp.Views
{
    [QueryProperty(nameof(HabitId), "HabitId")]  // ��������� �������� ��� ��������
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

            // �������� �������� �� ����������� HabitId
            currentHabit = dataService.GetHabits().FirstOrDefault(h => h.Id.ToString() == HabitId);
            BindingContext = currentHabit;  // ����������� � ���������
        }

        private void OnMarkDoneClicked(object sender, EventArgs e)
        {
            // �������� �������� ��� �����������
            currentHabit.LastCompletedDate = DateTime.Now;
            currentHabit.CompletionHistory.Add(DateTime.Now);
            dataService.UpdateHabit(currentHabit);
            DisplayAlert("������", "�������� �������� ��� �����������!", "��");
        }
    }
}
