
using System.Windows.Input;
using Xamarin.Forms;

namespace ShellExample.Views.Controls;

public class BorderedEntry : Entry
{
    public static readonly BindableProperty BorderColorProperty =
    BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(BorderedEntry), Color.Gray);

    // Gets or sets BorderColor value
    public Color BorderColor
    {
        get { return (Color)GetValue(BorderColorProperty); }
        set { SetValue(BorderColorProperty, value); }
    }

    public static readonly BindableProperty BorderWidthProperty =
        BindableProperty.Create(nameof(BorderWidth), typeof(int), typeof(BorderedEntry),
            Device.RuntimePlatform switch
            {
                Device.iOS => 1,
                Device.Android => 2,
                _ => throw new NotImplementedException()
            });

    // Gets or sets BorderWidth value
    public int BorderWidth
    {
        get { return (int)GetValue(BorderWidthProperty); }
        set { SetValue(BorderWidthProperty, value); }
    }

    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(BorderedEntry), 
            Device.RuntimePlatform switch
            {
                Device.iOS => (double)6.0,
                Device.Android => (double)7.0,
                _ => throw new NotImplementedException()
            });

    // Gets or sets CornerRadius value
    public double CornerRadius
    {
        get { return (double)GetValue(CornerRadiusProperty); }
        set { SetValue(CornerRadiusProperty, value); }
    }

    public static readonly BindableProperty IsClippedToBoundsProperty =
        BindableProperty.Create(nameof(IsClippedToBounds), typeof(bool), typeof(BorderedEntry), true);

    // Gets or sets IsCurvedCornersEnabled value
    public bool IsClippedToBounds
    {
        get { return (bool)GetValue(IsClippedToBoundsProperty); }
        set { SetValue(IsClippedToBoundsProperty, value); }
    }

    public static readonly BindableProperty CompletedCommandProperty =
        BindableProperty.Create(nameof(CompletedCommand), typeof(ICommand), typeof(BorderedEntry));

    // Gets or sets BorderColor value
    public ICommand CompletedCommand
    {
        get { return (ICommand)GetValue(CompletedCommandProperty); }
        set { SetValue(CompletedCommandProperty, value); }
    }

    public BorderedEntry()
    {
        Completed += (object sender, EventArgs e) =>
        {
            if(CompletedCommand != null && CompletedCommand.CanExecute(this))
            {
                CompletedCommand.Execute(this);
            }
        };
    }
}