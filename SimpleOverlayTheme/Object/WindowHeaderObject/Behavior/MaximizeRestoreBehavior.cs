using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Microsoft.Xaml.Behaviors;

namespace SimpleOverlayTheme.Object.WindowHeaderObject.Behavior
{


    public class MaximizeRestoreBehavior : Behavior<ToggleButton>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Checked += OnChecked;
            AssociatedObject.Unchecked += OnUnchecked;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Checked -= OnChecked;
            AssociatedObject.Unchecked -= OnUnchecked;
        }

        // Checked 이벤트 핸들러
        private void OnChecked(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(AssociatedObject) is Window window)
                window.WindowState = WindowState.Maximized;
        }

        // Unchecked 이벤트 핸들러
        private void OnUnchecked(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(AssociatedObject) is Window window)
                window.WindowState = WindowState.Normal;
        }
    }
}
