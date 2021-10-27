using MyClock.Extensions;
using MyClock.Properties;
using System;
using System.Windows;
using System.Windows.Media;

namespace MyClock
{
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

    internal class SettingsFacade : ISettings
    {
        private static readonly Lazy<SettingsFacade> lazy = new Lazy<SettingsFacade>(() => new SettingsFacade());

        private SettingsFacade()
        {
        }

        public static SettingsFacade Instance => lazy.Value;

        public string BackgroundColor
        {
            get => Settings.Default.BackgroundColor;
            set => Settings.Default.BackgroundColor = value;
        }

        public short BackgroundOpacity
        {
            get => Settings.Default.BackgroundOpacity;
            set => Settings.Default.BackgroundOpacity = value;
        }

        public Visibility DateVisibility
        {
            get => Settings.Default.ShowDate ? Visibility.Visible : Visibility.Collapsed;
            set
            {
                Settings.Default.ShowDate = value == Visibility.Visible;
                this.Save();
            }
        }

        public bool IsDateVisible => Settings.Default.ShowDate;

        public string FontColor
        {
            get => Settings.Default.FontColor;
            set => Settings.Default.FontColor = value;
        }

        public FontFamily FontFamily
        {
            get => new FontFamily(Settings.Default.FontFamily);
            set => Settings.Default.FontFamily = value.Source ?? "Segoe UI";
        }

        public SolidColorBrush GetBackgroundColorBrush()
        {
            var opacityHex = BackgroundOpacity.ToOpactiyHex();
            var colorHex = BackgroundColor;
            return (opacityHex + colorHex).ToSolidColorBrush();
        }

        public SolidColorBrush GetFontColorBrush() => this.FontColor.ToSolidColorBrush();

        public void Save() => Settings.Default.Save();
    }
}
