using MyClock.Commands;
using MyClock.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;

namespace MyClock.ViewModels;

public class SettingsViewModel : ViewModelBase
{
    private readonly ISettings settings;
    private readonly ClockViewModel clock;

    private string backgroundColor;
    private Brush backgroundColorBrush;
    private short backgroundOpacity;
    private string fontColor;
    private Brush fontColorBrush;
    private IEnumerable<FontFamily> fontFamilies;
    private FontFamily selectedFontFamily;

    public SettingsViewModel(ISettings appSettings, ClockViewModel clockViewModel)
    {
        this.settings = appSettings;
        this.clock = clockViewModel;

        this.ApplyCommand = new RelayCommand(obj => this.Apply());
        this.CloseCommand = new RelayCommand(obj => this.CloseAction.Invoke());
        this.SaveCommand = new RelayCommand(obj =>
        {
            this.Apply();
            this.CloseAction.Invoke();
        });

        this.BackgroundColor = this.settings.BackgroundColor;
        this.BackgroundOpacity = this.settings.BackgroundOpacity;
        this.FontColor = this.settings.FontColor;
        this.FontFamilies = Fonts.SystemFontFamilies.OrderBy(x => x.Source);
        this.selectedFontFamily = this.settings.FontFamily;
    }

    public ICommand ApplyCommand
    {
        get; private set;
    }
    public ICommand CloseCommand
    {
        get; private set;
    }
    public ICommand SaveCommand
    {
        get; private set;
    }

    public Action CloseAction
    {
        get; set;
    }

    public string BackgroundColor
    {
        get => this.backgroundColor;
        set
        {
            this.backgroundColor = value.Trim('#');
            this.BackgroundColorBrush = this.backgroundColor.ToSolidColorBrush();
            this.NotifyPropertyChanged(nameof(this.BackgroundColor));
        }
    }
    public Brush BackgroundColorBrush
    {
        get => this.backgroundColorBrush;
        set
        {
            this.backgroundColorBrush = value;
            this.NotifyPropertyChanged(nameof(this.BackgroundColorBrush));
        }
    }

    public short BackgroundOpacity
    {
        get => this.backgroundOpacity;
        set
        {
            this.backgroundOpacity = value;
            this.NotifyPropertyChanged(nameof(this.BackgroundOpacity));
        }
    }

    public string FontColor
    {
        get => this.fontColor;
        set
        {
            this.fontColor = value.Trim('#');
            this.FontColorBrush = this.fontColor.ToSolidColorBrush();
            this.NotifyPropertyChanged(nameof(this.FontColor));
        }
    }

    public Brush FontColorBrush
    {
        get => this.fontColorBrush;
        set
        {
            this.fontColorBrush = value;
            this.NotifyPropertyChanged(nameof(this.FontColorBrush));
        }
    }

    public IEnumerable<FontFamily> FontFamilies
    {
        get => this.fontFamilies;
        set
        {
            this.fontFamilies = value;
            this.NotifyPropertyChanged(nameof(this.FontFamilies));
        }
    }

    public FontFamily SelectedFontFamily
    {
        get => this.selectedFontFamily;
        set
        {
            this.selectedFontFamily = value;
            this.NotifyPropertyChanged(nameof(this.SelectedFontFamily));
        }
    }

    private void Apply()
    {
        this.settings.BackgroundColor = this.BackgroundColor;
        this.settings.BackgroundOpacity = this.BackgroundOpacity;
        this.settings.FontColor = this.FontColor;
        this.settings.FontFamily = this.SelectedFontFamily;
        this.settings.Save();
        this.clock.Draw();
    }
}
