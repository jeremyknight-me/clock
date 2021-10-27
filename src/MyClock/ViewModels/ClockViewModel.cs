using MyClock.Commands;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace MyClock.ViewModels
{
    public class ClockViewModel : INotifyPropertyChanged
    {
        private DateTime date;
        private Visibility showDateVisibility;
        private DispatcherTimer timer;

        public ClockViewModel()
        {
            this.date = DateTime.Now.ToLocalTime();
            this.ToggleDateCommand = new RelayCommand(obj => this.ToggleDateVisibility());

            var seconds = 5;
            this.timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, seconds) };
            this.timer.Tick += HandleTimerTick;
            this.timer.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CloseCommand { get; private set; } = new ShutdownCommand();
        public ICommand ToggleDateCommand { get; private set; }

        public DateTime Date
        {
            get => this.date;
            set
            {
                this.date = value;
                this.NotifyPropertyChanged(nameof(this.Date));
            }
        }

        public Visibility ShowDateVisibility
        {
            get => this.showDateVisibility;
            set
            {
                this.showDateVisibility = value;
                this.NotifyPropertyChanged(nameof(this.ShowDateVisibility));
            }
        }

        private void HandleTimerTick(object sender, EventArgs e)
        {
            this.Date = DateTime.Now.ToLocalTime();
        }

        private void ToggleDateVisibility()
        {
            switch (this.ShowDateVisibility)
            {
                case Visibility.Visible:
                    this.ShowDateVisibility = Visibility.Collapsed;
                    break;
                //case Visibility.Hidden:
                //case Visibility.Collapsed:
                default:
                    this.ShowDateVisibility = Visibility.Visible;
                    break;
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
