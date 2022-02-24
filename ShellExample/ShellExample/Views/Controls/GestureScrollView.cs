using Xamarin.Forms;

namespace ShellExample.Views.Controls;

// There's a bug in Android where Left / Right gestures don't work within a scroll view, so there's this workaround:
// https://github.com/xamarin/Xamarin.Forms/issues/1977
// https://stackoverflow.com/questions/59189164/xamarin-forms-how-to-add-swipegesturerecognizer-for-stacklayout
// https://docs.microsoft.com/en-us/answers/questions/698944/gestures-inside-a-scrollview-are-not-working.html
public class GestureScrollView : ScrollView
{
    private bool isInitialized = false;
    private List<SwipeGestureRecognizer> LeftSwipeRecognizers { get; } = new();
    private List<SwipeGestureRecognizer> RightSwipeRecognizers { get; } = new();

    public GestureScrollView() : base()
    {
    }

    protected override void LayoutChildren(double x, double y, double width, double height)
    {
        base.LayoutChildren(x, y, width, height);

        //Not sure if this is the best place, but the ctor wasn't getting called.
        if (!isInitialized)
        {
            isInitialized = true;
            foreach (SwipeGestureRecognizer swipeGestureRecognizer in GestureRecognizers.Where(x => x is SwipeGestureRecognizer))
            {
                if (swipeGestureRecognizer.Direction.HasFlag(SwipeDirection.Left))
                {
                    LeftSwipeRecognizers.Add(swipeGestureRecognizer);
                }

                if (swipeGestureRecognizer.Direction.HasFlag(SwipeDirection.Right))
                {
                    RightSwipeRecognizers.Add(swipeGestureRecognizer);
                }
            }
        }
    }

    private void ExecuteGestureCommands(List<SwipeGestureRecognizer> swipeRecognizers, SwipedEventArgs e)
    {
        foreach (var gesture in swipeRecognizers)
        {
            gesture.SendSwiped(this, e.Direction);
        }
    }

    public void OnSwipeLeft(object sender, SwipedEventArgs e)
    {
        ExecuteGestureCommands(LeftSwipeRecognizers, e);
    }

    public void OnSwipeRight(object sender, SwipedEventArgs e)
    {
        ExecuteGestureCommands(RightSwipeRecognizers, e);
    }
}