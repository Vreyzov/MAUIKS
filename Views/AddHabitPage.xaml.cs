using HabitTrackerApp.ViewModels;
using Microsoft.Maui.Controls;

namespace HabitTrackerApp.Views;

public partial class AddHabitPage : ContentPage
{
    private AddHabitViewModel viewModel = new();

    public AddHabitPage()
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    // Метод обработки нажатия кнопки "Сохранить"
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (await viewModel.SaveHabit())
        {
            await DisplayAlert("Успех", "Привычка успешно сохранена!", "OK");

            // Переход на главную (универсально)
            await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
        }
        else
        {
            await DisplayAlert("Ошибка", "Пожалуйста, заполните все поля", "ОК");
        }
    }


}
