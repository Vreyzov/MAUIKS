using HabitTrackerApp.ViewModels;
using HabitTrackerApp.Models;
using HabitTrackerApp.Services;
using Microsoft.Maui.Controls;
using HabitTrackerApp.Views;
using System.IO;



namespace HabitTrackerApp.Views
{
    // Views/MainPage.xaml.cs
    public partial class MainPage : ContentPage
    {
        HabitListViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            viewModel = new HabitListViewModel();
            BindingContext = viewModel;
        }

        private async void OnAddHabitClicked(object sender, EventArgs e)
        {
            // Используем абсолютный путь для навигации
            await Shell.Current.GoToAsync("///AddHabitPage");
        }


        private async void OnHabitSelected(object sender, SelectionChangedEventArgs e)
        {
            var selected = e.CurrentSelection.FirstOrDefault() as Habit;
            if (selected != null)
            {
                // Передаем параметр HabitId при переходе
                await Shell.Current.GoToAsync($"///HabitDetailPage?HabitId={selected.Id}");

            }
        }


        private async void OnStatisticsClicked(object sender, EventArgs e)
        {
            // Используйте абсолютный путь для навигации
            await Shell.Current.GoToAsync("///StatisticsPage");
        }
        
    }


}
