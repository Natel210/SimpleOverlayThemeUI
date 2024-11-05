using System.Windows;
using Microsoft.Xaml.Behaviors;


namespace SimpleOverlayTheme.Object.WindowHeaderObject.Behavior
{
    public partial class LostFocusBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            if (Window.GetWindow(AssociatedObject) is Window window)
            {
                window.Activated += OnWindowActivated;
                window.Deactivated += OnWindowDeactivated;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (Window.GetWindow(AssociatedObject) is Window window)
            {
                window.Activated -= OnWindowActivated;
                window.Deactivated -= OnWindowDeactivated;
            }
        }


    }

    // evnet
    public partial class LostFocusBehavior
    {
        private void OnWindowActivated(object? sender, EventArgs e)
        {
            AssociatedObject.SetCurrentValue(UIElement.VisibilityProperty, Visibility.Hidden);
        }

        private void OnWindowDeactivated(object? sender, EventArgs e)
        {
            AssociatedObject.SetCurrentValue(UIElement.VisibilityProperty, Visibility.Visible);
        }
    }

}
