using MyClock.ViewModels;

namespace MyClock.Views;

public partial class SettingsWindow : Window
{
    public SettingsWindow(SettingsViewModel viewModel)
    {
        if (viewModel.CloseAction is null)
        {
            viewModel.CloseAction = new Action(this.Close);
        }
        this.DataContext = viewModel;
        InitializeComponent();
    }

    internal SettingsViewModel ViewModel => this.DataContext as SettingsViewModel;
}
