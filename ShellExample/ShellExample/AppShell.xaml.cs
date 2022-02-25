using ShellExample.Views;
using Xamarin.Forms;

namespace ShellExample;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        BindingContext = this;

        //this.ChildAdded += AppShell_ChildAdded;
        //FlyoutIcon fi;
        //FlyoutItem fi;
        //((FontImageSource)fi.Icon).gl
        //FlyoutItemIcon2.SetBinding(FontImageSource.ColorProperty, new Binding("{AppThemeBinding Light={StaticResource HyperlinkTextColorLight}, Dark={StaticResource HyperlinkTextColorDark}}"))
    }

    private void AppShell_ChildAdded(object sender, ElementEventArgs e)
    {
        var x = e.Element;

        if(x is Grid grid)
        {
            grid.ChildAdded += AppShell_ChildAdded;
            foreach(var c in grid.Children)
            {
                var f = c;
            }
        }
    }
}

public interface IShellIconFont
{
    public string Title { get; set; }
    public string Glyph { get; set; }
}

public class FlyoutItemIconFont : FlyoutItem, IShellIconFont
{
    public static readonly BindableProperty IconGlyphProperty = BindableProperty.Create(nameof(IconGlyphProperty), typeof(string), typeof(FlyoutItemIconFont), string.Empty);
    public string Glyph
    {
        get { return (string)GetValue(IconGlyphProperty); }
        set { SetValue(IconGlyphProperty, value); }
    }
}

public class ShellContentIconFont : ShellContent, IShellIconFont
{
    public static readonly BindableProperty GlyphProperty = BindableProperty.Create(nameof(GlyphProperty), typeof(string), typeof(ShellContentIconFont), string.Empty);
    public string Glyph
    {
        get { return (string)GetValue(GlyphProperty); }
        set { SetValue(GlyphProperty, value); }
    }
}

public class TabIconFont : Tab, IShellIconFont
{
    public static readonly BindableProperty GlyphProperty = BindableProperty.Create(nameof(GlyphProperty), typeof(string), typeof(ShellContentIconFont), string.Empty);
    public string Glyph
    {
        get { return (string)GetValue(GlyphProperty); }
        set { SetValue(GlyphProperty, value); }
    }
}
