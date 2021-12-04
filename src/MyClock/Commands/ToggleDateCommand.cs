using MyClock.ViewModels;

namespace MyClock.Commands;

internal class ToggleDateCommand : RelayCommand
{
    public ToggleDateCommand(ClockViewModel clockViewModel)
        : base(obj => Toggle(clockViewModel))
    {
    }

    public static void Toggle(ClockViewModel clockViewModel)
    {
        switch (clockViewModel.DateVisibility)
        {
            case Visibility.Visible:
                clockViewModel.DateVisibility = Visibility.Collapsed;
                break;
            //case Visibility.Hidden:
            //case Visibility.Collapsed:
            default:
                clockViewModel.DateVisibility = Visibility.Visible;
                break;
        }
    }
}
