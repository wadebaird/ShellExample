using Xamarin.Forms;

namespace Sunbreak.DailyBook.Views.Converters;

public class FlyoutGlyphConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value == null)
            return null;

        if (value is not BaseShellItem baseShellItem)
            throw new ArgumentException($"This converter may only be used on values of type {nameof(BaseShellItem)}.");

        if (baseShellItem.Icon is not FontImageSource fontImageSource)
            throw new ArgumentException($"This converter may only be used on values of type {nameof(BaseShellItem)}s with Icons of type {nameof(FontImageSource)}.");

        return fontImageSource.Glyph;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException("This method is not implemented.");
    }
}