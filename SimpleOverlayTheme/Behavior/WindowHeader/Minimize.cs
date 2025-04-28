using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace SimpleOverlayTheme.Behavior.WindowHeader
{
    public partial class Minimize : Behavior<Button>
    {

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Click += OnButtonClick;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Click -= OnButtonClick;
        }
        
    }

    // evnet
    public partial class Minimize
    {
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(AssociatedObject) is Window window)
                window.WindowState = WindowState.Minimized;
        }
    }
}
