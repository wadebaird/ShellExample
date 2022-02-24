using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;
using ShellExample.Views.Controls;
using System;

[assembly: ExportRenderer(typeof(BorderedEntry), typeof(ShellExample.iOS.Renderers.BorderedEntryRenderer))]

namespace ShellExample.iOS.Renderers;

public class BorderedEntryRenderer : EntryRenderer
{
    protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
    {
        base.OnElementChanged(e);

        if (e.NewElement != null)
        {
            var view = (BorderedEntry)Element;

            Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));
            Control.LeftViewMode = UITextFieldViewMode.Always;
            Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
            Control.ReturnKeyType = UIReturnKeyType.Done;
            Control.Layer.CornerRadius = Convert.ToSingle(view.CornerRadius);
            Control.Layer.BorderColor = view.BorderColor.ToCGColor();
            Control.Layer.BorderWidth = view.BorderWidth;
            Control.ClipsToBounds = view.IsClippedToBounds;
        }
    }
}