using MyClock.ViewModels;
using System.Windows;

namespace MyClock.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new ClockViewModel();
            InitializeComponent();
        }

        internal ClockViewModel ViewModel => this.DataContext as ClockViewModel;

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
