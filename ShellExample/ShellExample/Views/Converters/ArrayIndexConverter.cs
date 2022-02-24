using Xamarin.Forms;

namespace ShellExample.Views.Converters;

public class ArrayIndexConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value == null)
            return null;

        int arrayIndex = 0;

        if (value is not Array array)
            throw new ArgumentException($"This converter may only be used on values of type {nameof(Array)}.");

        if (parameter is int @int)
            arrayIndex = @int;
        else if (parameter is not string parameterString || !int.TryParse(parameterString, out arrayIndex))
            throw new ArgumentException($"This converter may only be used on parameters of type int.");

        return arrayIndex <= array.Length - 1 ? array.GetValue(arrayIndex) : null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException("This method is not implemented.");
    }
}