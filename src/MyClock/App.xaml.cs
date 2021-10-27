using System.Windows;

namespace MyClock
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var settings = SettingsFacade.Instance;
            var clockViewModel = new ViewModels.ClockViewModel(settings);
            var mainWindow = new Views.MainWindow(clockViewModel);
            mainWindow.Show();
        }
    }
}
