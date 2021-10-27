using System.Windows;

namespace MyClock.Commands
{
    public class ShutdownCommand : RelayCommand
    {
        public ShutdownCommand()
            : base(obj => Application.Current.Shutdown())
        {
        }
    }
}
