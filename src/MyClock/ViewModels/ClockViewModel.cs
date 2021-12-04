using MyClock.Commands;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace MyClock.ViewModels;

public class ClockViewModel : ViewModelBase, IDisposable
{
    private SolidColorBrush backgroundColor;
    private DateTime date;
    private SolidColorBrush fontColor;
    private FontFamily fontFamily;
    private DispatcherTimer timer;

    public ClockViewModel(ISettings appSettings)
    {
        this.Settings = appSettings;
        this.ShowSettingsCommand = new ShowSettingsCommand(this);
        this.ToggleDateCommand = new ToggleDateCommand(this);
        this.Draw();

        this.date = DateTime.Now.ToLocalTime();
        this.timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
        this.timer.Tick += (object sender, EventArgs e) => this.Date = DateTime.Now.ToLocalTime();
        this.timer.Start();
    }

    public ICommand CloseCommand { get; } = new ShutdownCommand();
    public ICommand ShowSettingsCommand { get; }
    public ICommand ToggleDateCommand { get; }

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
        get => this.Settings.DateVisibility;
        set
        {
            this.Settings.DateVisibility = value;
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

    public ISettings Settings { get; }

    public void Dispose()
    {
        this.timer.Stop();
        this.timer = null;
    }

    public void Draw()
    {
        this.BackgroundColor = this.Settings.GetBackgroundColorBrush();
        this.FontColor = this.Settings.GetFontColorBrush();
        this.FontFamily = this.Settings.FontFamily;
    }
}
