using MyClock.ViewModels;

namespace MyClock.Views;

public partial class MainWindow : Window
{
    public MainWindow(ClockViewModel viewModel)
    {
        this.DataContext = viewModel;
        this.InitializeComponent();
    }

    internal ClockViewModel ViewModel => this.DataContext as ClockViewModel;

    private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        this.DragMove();
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        this.ViewModel.Dispose();
    }
}
