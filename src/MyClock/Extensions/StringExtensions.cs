using System.Windows.Media;

namespace MyClock.Extensions;

internal static class StringExtensions
{
    internal static SolidColorBrush ToSolidColorBrush(this string hexColor)
    {
        var bc = new BrushConverter();
        var brush = bc.ConvertFrom(hexColor.EnsureHex()) as SolidColorBrush;
        brush.Freeze();
        return brush;
    }

    private static string EnsureHex(this string hexColor) => $"#{hexColor.TrimStart('#')}";
}
