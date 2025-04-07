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

    // ����� ��������� ������� ������ "���������"
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (await viewModel.SaveHabit())
        {
            await DisplayAlert("�����", "�������� ������� ���������!", "OK");

            // ������� �� ������� (������������)
            await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
        }
        else
        {
            await DisplayAlert("������", "����������, ��������� ��� ����", "��");
        }
    }


}
