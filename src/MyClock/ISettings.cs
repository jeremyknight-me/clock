using System.Windows.Media;

namespace MyClock;

public interface ISettings
{
    string BackgroundColor { get; set; }
    short BackgroundOpacity { get; set; }
    Visibility DateVisibility { get; set; }
    string FontColor { get; set; }
    FontFamily FontFamily { get; set; }
    bool IsDateVisible { get; }

    SolidColorBrush GetBackgroundColorBrush();
    SolidColorBrush GetFontColorBrush();
    void Save();
}
