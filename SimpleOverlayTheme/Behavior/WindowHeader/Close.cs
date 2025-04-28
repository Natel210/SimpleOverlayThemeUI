using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace SimpleOverlayTheme.Behavior.WindowHeader
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Close : Behavior<Button>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Click += OnButtonClick;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Click -= OnButtonClick;
        }
        
    }

    // evnet
    public partial class Close
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(AssociatedObject) is Window window)
                window.Close();
        }
    }
}
