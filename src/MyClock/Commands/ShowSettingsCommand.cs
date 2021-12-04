using MyClock.ViewModels;

namespace MyClock.Commands;

internal class ShowSettingsCommand : RelayCommand
{
    public ShowSettingsCommand(ClockViewModel clockViewModel)
        : base(obj => ShowSettings(clockViewModel))
    {
    }

    public static void ShowSettings(ClockViewModel clockViewModel)
    {
        var viewModel = new SettingsViewModel(clockViewModel.Settings, clockViewModel);
        var window = new Views.SettingsWindow(viewModel);
        window.ShowDialog();
    }
}
