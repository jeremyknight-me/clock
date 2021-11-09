namespace MyClock.Extensions;

internal static class ShortExtensions
{
    internal static string ToOpactiyHex(this short opacity)
    {
        if (opacity < 0 || opacity > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(opacity), opacity, "Value must be betwen 0 and 100");
        }

        decimal percent = opacity / 100m;
        var rbga = (short)(percent * 255);
        return rbga.ToString("X2");
    }
}
