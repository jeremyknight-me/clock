using MyClock.ViewModels;

namespace MyClock.Views;

public partial class MainWindow : Window
{
    public MainWindow(ClockViewModel viewModel)
    {
        this.DataContext = viewModel;
        InitializeComponent();
    }

    internal ClockViewModel ViewModel => this.DataContext as ClockViewModel;

    private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        this.DragMove();
    }
}
