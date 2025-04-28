using System.Windows;
using Microsoft.Xaml.Behaviors;


namespace SimpleOverlayTheme.Behavior.WindowHeader
{
    /// <summary>
    /// 
    /// </summary>
    public partial class LostFocus : Behavior<FrameworkElement>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            if (Window.GetWindow(AssociatedObject) is Window window)
            {
                window.Activated += OnWindowActivated;
                window.Deactivated += OnWindowDeactivated;
            }
        }

        /// <summary>
        /// 
        /// </summary>
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
    public partial class LostFocus
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowActivated(object? sender, EventArgs e)
        {
            AssociatedObject.SetCurrentValue(UIElement.VisibilityProperty, Visibility.Hidden);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowDeactivated(object? sender, EventArgs e)
        {
            AssociatedObject.SetCurrentValue(UIElement.VisibilityProperty, Visibility.Visible);
        }
    }

}
