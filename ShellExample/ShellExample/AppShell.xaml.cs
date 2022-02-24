using ShellExample.Views;
using Xamarin.Forms;

namespace ShellExample;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        BindingContext = this;
    }
}