using MyClock.Commands;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace MyClock.ViewModels
{
    public class ClockViewModel : ViewModelBase
    {
        private readonly ISettings settings;

        private SolidColorBrush backgroundColor; 
        private DateTime date;
        private SolidColorBrush fontColor;
        private FontFamily fontFamily;
        private DispatcherTimer timer;

        public ClockViewModel(ISettings appSettings)
        {
            this.settings = appSettings;
            this.BackgroundColor = this.settings.GetBackgroundColorBrush();
            this.FontColor = this.settings.GetFontColorBrush();
            this.FontFamily = this.settings.FontFamily;

            this.ShowSettingsCommand = new RelayCommand(obj =>
            {
                var viewModel = new SettingsViewModel(this.settings, this);
                var window = new Views.SettingsWindow(viewModel);
                window.ShowDialog();
            });
            this.ToggleDateCommand = new RelayCommand(obj => this.ToggleDateVisibility());

            this.date = DateTime.Now.ToLocalTime();
            var seconds = 5;
            this.timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, seconds) };
            this.timer.Tick += HandleTimerTick;
            this.timer.Start();
        }

        public ICommand CloseCommand { get; private set; } = new ShutdownCommand();
        public ICommand ShowSettingsCommand { get; private set; }
        public ICommand ToggleDateCommand { get; private set; }

        public SolidColorBrush BackgroundColor
        {
            get => this.backgroundColor;
            set
            {
                this.backgroundColor = value;
                this.NotifyPropertyChanged(nameof(this.BackgroundColor));
            }
        }

        public DateTime Date
        {
            get => this.date;
            set
            {
                this.date = value;
                this.NotifyPropertyChanged(nameof(this.Date));
            }
        }

        public Visibility DateVisibility
        {
            get => this.settings.DateVisibility;
            set
            {
                this.settings.DateVisibility = value;
                this.NotifyPropertyChanged(nameof(this.DateVisibility));
            }
        }

        public SolidColorBrush FontColor
        {
            get => this.fontColor;
            set
            {
                this.fontColor = value;
                this.NotifyPropertyChanged(nameof(this.FontColor));
            }
        }

        public FontFamily FontFamily
        {
            get => this.fontFamily;
            set
            {
                this.fontFamily = value;
                this.NotifyPropertyChanged(nameof(this.FontFamily));
            }
        }

        private void HandleTimerTick(object sender, EventArgs e)
        {
            this.Date = DateTime.Now.ToLocalTime();
        }

        private void ToggleDateVisibility()
        {
            switch (this.DateVisibility)
            {
                case Visibility.Visible:
                    this.DateVisibility = Visibility.Collapsed;
                    break;
                //case Visibility.Hidden:
                //case Visibility.Collapsed:
                default:
                    this.DateVisibility = Visibility.Visible;
                    break;
            }
        }
    }
}
