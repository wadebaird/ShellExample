using System.Diagnostics;
using Xamarin.Forms;

namespace ShellExample.Views;

public static class ViewsCommon
{
    private static readonly string ExceptionMessage = "Invalid {0} string '{1}' found in page '{2}'.";
    
    public static FontAttributes ConvertFontAttributes(string fontAttributesString, string pageName)
    {
        FontAttributes? fontAttributes = null;
        try
        {
            if (!string.IsNullOrEmpty(fontAttributesString))
            {
                var fontAttributesStrings = fontAttributesString?.RemoveWhitespace().Split(',').ToList();

                foreach(string currentFontAttributesString in fontAttributesStrings)
                {
                    if (Enum.TryParse(currentFontAttributesString, out FontAttributes currentFontAttributes))
                    {
                        if (fontAttributes == null)
                        {
                            fontAttributes = currentFontAttributes;
                        }
                        else
                        {
                            fontAttributes |= currentFontAttributes;
                        }
                    }
                    else
                    {
                        //Error condition as there are non-parseable strings
                        fontAttributes = null;
                        break;
                    }
                }
            }

            if(fontAttributes == null)
            {
                App.Analytics.TrackError(new FormatException(string.Format(ExceptionMessage,  "FontAttributes", fontAttributesString, pageName)));
                fontAttributes = FontAttributes.None;
            }
        }
        catch (Exception ex)
        {
            App.Analytics.TrackError(ex);
            Debug.WriteLine(ex);
            fontAttributes = FontAttributes.None;
        }

        return fontAttributes.Value;
    }

    public static LayoutOptions ConvertHorizontalOptions(string horizontalOptionsString, string pageName)
    {
        try
        {
            return horizontalOptionsString switch
            {
                nameof(LayoutOptions.Start) => LayoutOptions.Start,
                nameof(LayoutOptions.StartAndExpand) => LayoutOptions.StartAndExpand,
                nameof(LayoutOptions.Center) => LayoutOptions.Center,
                nameof(LayoutOptions.CenterAndExpand) => LayoutOptions.CenterAndExpand,
                nameof(LayoutOptions.End) => LayoutOptions.End,
                nameof(LayoutOptions.EndAndExpand) => LayoutOptions.EndAndExpand,
                nameof(LayoutOptions.Fill) => LayoutOptions.Fill,
                nameof(LayoutOptions.FillAndExpand) => LayoutOptions.FillAndExpand,
                _ => throw new FormatException(string.Format(ExceptionMessage, "HorizontalOptions", horizontalOptionsString, pageName)),
            };
        }
        catch (Exception ex)
        {
            App.Analytics.TrackError(ex);
            Debug.WriteLine(ex);
        }

        return LayoutOptions.Start;
    }

    public static TextAlignment ConvertHorizontalTextAlignment(string horizontalTextAlignmentString, string pageName)
    {
        TextAlignment? textAlignment;
        try
        {
            switch(horizontalTextAlignmentString)
            {
                case nameof(TextAlignment.Start):
                    textAlignment = TextAlignment.Start;
                    break;
                case nameof(TextAlignment.Center):
                    textAlignment = TextAlignment.Center;
                    break;
                case nameof(TextAlignment.End):
                    textAlignment = TextAlignment.End;
                    break;
                default:
                    App.Analytics.TrackError(new FormatException(string.Format(ExceptionMessage, "TextAlignment", horizontalTextAlignmentString, pageName)));
                    textAlignment = TextAlignment.Start;
                    break;
            };
        }
        catch (Exception ex)
        {
            App.Analytics.TrackError(ex);
            Debug.WriteLine(ex);
            textAlignment = TextAlignment.Start;
        }

        return textAlignment.Value;
    }

    public static Thickness ConvertThickness(string thicknessString, string pageName)
    {
        Thickness? thickness;
        try
        {
            var thicknessStrings = thicknessString?.Split(',');

            if (thicknessStrings?.Length == 1 && !string.IsNullOrEmpty(thicknessStrings[0]) && double.TryParse(thicknessStrings[0], out double result))
            {
                thickness = new(result);
            }
            else if (thicknessStrings?.Length == 4 && 
                double.TryParse(thicknessStrings[0], out double left) &&
                double.TryParse(thicknessStrings[1], out double top) && 
                double.TryParse(thicknessStrings[2], out double right) &&
                double.TryParse(thicknessStrings[3], out double bottom))
            {
                thickness = new(left, top, right, bottom);
            }
            else
            {
                App.Analytics.TrackError(new FormatException(string.Format(ExceptionMessage, "Thickness", thicknessString, pageName)));
                thickness = new Thickness(0);
            }
        }
        catch (Exception ex)
        {
            App.Analytics.TrackError(ex);
            Debug.WriteLine(ex);
            thickness = new Thickness(0);
        }

        return thickness.Value;
    }
}