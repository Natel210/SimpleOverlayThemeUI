using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Shell;
using Microsoft.Win32;
using Microsoft.Xaml.Behaviors;

namespace SimpleOverlayTheme.Behavior.WindowHeader
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MaximizeRestore : Behavior<ToggleButton>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            ApplyDpi();
            SyncWindowState();
            UpdateLayoutRootUI();

            AssociatedObject.Checked += OnChecked;
            AssociatedObject.Unchecked += OnUnchecked;
            if (Window.GetWindow(AssociatedObject) is Window window)
                window.StateChanged += OnWindowStateChanged;
            SystemEvents.DisplaySettingsChanged += OnDisplaySettingsChanged;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Checked -= OnChecked;
            AssociatedObject.Unchecked -= OnUnchecked;
            if (Window.GetWindow(AssociatedObject) is Window window)
                window.StateChanged -= OnWindowStateChanged;
            SystemEvents.DisplaySettingsChanged -= OnDisplaySettingsChanged;
        }
    }

    // evnet
    public partial class MaximizeRestore
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChecked(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(AssociatedObject) is Window window)
            {
                if (window.WindowState is WindowState.Normal)
                    window.WindowState = WindowState.Maximized;
                UpdateLayoutRootUI();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUnchecked(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(AssociatedObject) is Window window)
            {
                if (window.WindowState is WindowState.Maximized)
                    window.WindowState = WindowState.Normal;
                UpdateLayoutRootUI();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowStateChanged(object? sender, EventArgs e)
        {
            SyncWindowState();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDisplaySettingsChanged(object? sender, EventArgs e)
        {
            ApplyDpi();
            UpdateLayoutRootUI();
        }

    }

    // members
    public partial class MaximizeRestore
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly Thickness zeroDpiEdge = new Thickness(0);
        /// <summary>
        /// 
        /// </summary>
        private static readonly Thickness defaultDpiEdge = new Thickness(7.5);
        /// <summary>
        /// 
        /// </summary>
        private Thickness CurrentDpiEdge { get; set; } = defaultDpiEdge;
    }

    // inner func
    public partial class MaximizeRestore
    {

        /// <summary>
        /// Synchronize the state of the window's maximum return to the toggle button.
        /// </summary>
        private void SyncWindowState()
        {
            try
            {
                Window window = Window.GetWindow(AssociatedObject);
                if (window is null)
                    return;
                if (window.WindowState == WindowState.Maximized
                    || window.WindowState == WindowState.Normal)
                    AssociatedObject.SetCurrentValue(ToggleButton.IsCheckedProperty, window.WindowState == WindowState.Maximized);
            }
            catch (Exception) { return; }
        }

        /// <summary>
        /// Is <see cref="WindowChrome"/>
        /// </summary>
        private bool IsChromeWindow()
        {
            if (AssociatedObject == null)
                return false;

            try
            {
                Window window = Window.GetWindow(AssociatedObject);
                if (window == null)
                    return false;

                WindowChrome windowChrome = WindowChrome.GetWindowChrome(window);
                if (windowChrome == null)
                    return false;
            }
            catch (Exception) { return false; }

            return true;
        }

        /// <summary>
        /// Measures margins according to DPI.
        /// </summary>
        private void ApplyDpi()
        {
            try
            {
                if (PresentationSource.FromVisual(Window.GetWindow(AssociatedObject)) is PresentationSource source)
                {
                    // Screen Device
                    double Scale_AxisX = source.CompositionTarget.TransformToDevice.M11; // x axis scale
                    double Scale_AxisY = source.CompositionTarget.TransformToDevice.M22; // y axis scale
                    // Apply Dpi Setting
                    CurrentDpiEdge = new Thickness()
                    {
                        Left = defaultDpiEdge.Left * Scale_AxisX,
                        Top = defaultDpiEdge.Top * Scale_AxisY,
                        Right = defaultDpiEdge.Right * Scale_AxisX,
                        Bottom = defaultDpiEdge.Bottom * Scale_AxisY
                    };
                }
            }
            catch (Exception) { CurrentDpiEdge = defaultDpiEdge; }

        }

        /// <summary>
        /// Updates the UI based on pre-measured DPI edges.
        /// </summary>
        private void UpdateLayoutRootUI()
        {
            try
            {
                Window window = Window.GetWindow(AssociatedObject);
                if (window is null)
                    return;
                if (IsChromeWindow() is false)
                    return;
                if (window.Template.FindName("PART_LayoutRoot", window) is FrameworkElement layoutRoot)
                {
                    if (window.WindowState is WindowState.Maximized)
                        layoutRoot.Margin = CurrentDpiEdge;
                    else
                        layoutRoot.Margin = zeroDpiEdge;
                }
            }
            catch (Exception) { return; }
        }
    }

}
