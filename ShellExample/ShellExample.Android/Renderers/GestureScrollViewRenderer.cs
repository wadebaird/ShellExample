using Android.Content;
using Android.Views;
using ShellExample.Droid.Renderers;
using ShellExample.Views.Controls;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GestureScrollView), typeof(GestureScrollViewRenderer))]
namespace ShellExample.Droid.Renderers;

public class GestureScrollViewRenderer : ScrollViewRenderer
{
    private readonly CustomGestureListener _listener = new();
    private readonly GestureDetector _detector;

    public GestureScrollViewRenderer(Context context) : base(context)
    {
        _detector = new(context, _listener);
    }

    public override bool DispatchTouchEvent(MotionEvent e)
    {
        if (_detector != null)
        {
            _detector.OnTouchEvent(e);
            base.DispatchTouchEvent(e);
            return true;
        }

        return base.DispatchTouchEvent(e);
    }

    public override bool OnTouchEvent(MotionEvent ev)
    {
        base.OnTouchEvent(ev);

        if (_detector != null)
        {
            return _detector.OnTouchEvent(ev);
        }

        return false;
    }

    protected override void OnElementChanged(VisualElementChangedEventArgs e)
    {
        base.OnElementChanged(e);

        if (e.NewElement == null)
        {
            _listener.OnSwipeLeft -= HandleOnSwipeLeft;
            _listener.OnSwipeRight -= HandleOnSwipeRight;
        }

        if (e.OldElement == null)
        {
            _listener.OnSwipeLeft += HandleOnSwipeLeft;
            _listener.OnSwipeRight += HandleOnSwipeRight;
        }
    }

    void HandleOnSwipeLeft(object sender, SwipedEventArgs e) => ((GestureScrollView)Element).OnSwipeLeft(sender, e);

    void HandleOnSwipeRight(object sender, SwipedEventArgs e) => ((GestureScrollView)Element).OnSwipeRight(sender, e);
}

public class CustomGestureListener : GestureDetector.SimpleOnGestureListener
{
    private const int SWIPE_THRESHOLD = 100;
    private const int SWIPE_VELOCITY_THRESHOLD = 100;

    private MotionEvent mLastOnDownEvent;

    public event EventHandler<SwipedEventArgs> OnSwipeLeft;
    public event EventHandler<SwipedEventArgs> OnSwipeRight;

    public override bool OnDown(MotionEvent e)
    {
        mLastOnDownEvent = e;
        return true;
    }

    public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
    {
        if (e1 == null)
            e1 = mLastOnDownEvent;

        float diffY = e2.GetY() - e1.GetY();
        float diffX = e2.GetX() - e1.GetX();

        if (Math.Abs(diffX) > Math.Abs(diffY) && Math.Abs(diffX) > SWIPE_THRESHOLD && Math.Abs(velocityX) > SWIPE_VELOCITY_THRESHOLD)
        {
            if (diffX > 0)
            {
                OnSwipeRight?.Invoke(this, new SwipedEventArgs(null, SwipeDirection.Right));
            }
            else
            {
                OnSwipeLeft?.Invoke(this, new SwipedEventArgs(null, SwipeDirection.Left));
            }
        }

        return base.OnFling(e1, e2, velocityX, velocityY);
    }
}