using Microsoft.Xaml.Behaviors;
using SimpleOverlayTheme.CustomControl;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SimpleOverlayTheme.Object.WindowHeaderObject.Behavior
{
    /// <summary>
    /// Use only on properties such as borders or grids.
    /// </summary>
    public partial class WindowMovementBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseLeftButtonDown += OnMouseLeftDown;
            AssociatedObject.MouseMove += OnMouseMove;
            AssociatedObject.MouseLeftButtonUp += OnMouseLeftUp;
            AssociatedObject.LostFocus += OnLostFocus;
            _changeWindowStateDelay_FromDoubleClick.Start();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseLeftButtonDown -= OnMouseLeftDown;
            AssociatedObject.MouseMove -= OnMouseMove;
            AssociatedObject.MouseLeftButtonUp -= OnMouseLeftUp;
            AssociatedObject.LostFocus -= OnLostFocus;
        }
    }

    // evnet
    public partial class WindowMovementBehavior
    {

        private void OnMouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            if (IsLeftMouseDrag() is true)
                return;

            // check window
            Window window = Window.GetWindow(AssociatedObject);
            if (window is null)
                return;

            // exist window header
            try
            {
                if (VisualTreeHelper.GetParent(AssociatedObject) is WindowHeader windowHeader)
                {
                    // check window lock
                    if (windowHeader.WindowUnlocked is false)
                        return;
                    // not visible
                    if (windowHeader.ShowToggleMaximizeRestore is not Visibility.Visible)
                        return;
                }
            }
            catch (Exception) {}
            
            if (e.ClickCount == 2) // bar double click
                MouseLeftDoubleClick();
            else if (window.WindowState == WindowState.Maximized) // maximized
                _restoreMousePos = e.GetPosition(window);
            else
                try { window.DragMove(); } catch { }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            MouseMoveTrace(e);
            MouseLeftDrag(e);
        }

        private void OnMouseLeftUp(object sender, MouseButtonEventArgs e)
        {
            MouseLeftDragEnd();
        }

        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            MouseLeftDragEnd();
        }

    }

    // members
    public partial class WindowMovementBehavior
    {

        #region double click window state restore

        private const long _changeWindowStateDelayTime = 100L;
        private Stopwatch _changeWindowStateDelay_FromDoubleClick = new Stopwatch();

        #endregion

        #region restore mouse drag mode

        private bool _isRestoreMouseDragMode = false;
        private Point _restoreMousePos;

        #endregion

        #region current mouse pos

        private Point _mouseCurPos;

        /// <summary>
        /// Features that may be available
        /// </summary>
        public Point CurrentMousePos { get => _mouseCurPos; }

        #endregion

    }

    // inner func
    public partial class WindowMovementBehavior
    {

        /// <summary>
        /// double click
        /// </summary>
        private void MouseLeftDoubleClick()
        {
            // check window
            Window window = Window.GetWindow(AssociatedObject);
            if (window is null)
                return;

            // check interval timer
            if (_changeWindowStateDelay_FromDoubleClick.IsRunning is false)
            {
                _changeWindowStateDelay_FromDoubleClick.Start();
                return;
            }

            // limit 0.1s over, avoid duplicate changes
            if (_changeWindowStateDelay_FromDoubleClick.ElapsedMilliseconds <= _changeWindowStateDelayTime)
                return;
            // max to normal
            else if (window.WindowState == WindowState.Maximized)
                window.WindowState = WindowState.Normal;
            // normal to max
            else if (window.WindowState == WindowState.Normal)
                window.WindowState = WindowState.Maximized;
            // restart timer
            _changeWindowStateDelay_FromDoubleClick.Restart();
        }

        /// <summary>
        /// mouse movement trace
        /// </summary>
        private void MouseMoveTrace(MouseEventArgs e)
        {
            // check window
            Window window = Window.GetWindow(AssociatedObject);
            if (window is null)
                return;
            // Trace Current Pos
            _mouseCurPos = e.GetPosition(window);
        }

        /// <summary>
        /// 
        /// </summary>
        private bool IsLeftMouseDrag()
        {
            return _isRestoreMouseDragMode;
        }

        /// <summary>
        /// 
        /// </summary>
        private void MouseLeftDrag(MouseEventArgs e)
        {
            // check mouse pressed
            if (e.LeftButton is not MouseButtonState.Pressed)
            {
                MouseLeftDragEnd();
                return;
            }

            // check double click delay
            if (_changeWindowStateDelay_FromDoubleClick.ElapsedMilliseconds <= 100)
            {
                MouseLeftDragEnd();
                return;
            }

            // check window
            Window window = Window.GetWindow(AssociatedObject);
            if (window is null)
            {
                MouseLeftDragEnd();
                return;
            }

            // window to screen
            Point screenMousePosition = window.PointToScreen(_mouseCurPos);
            // dragging

            // specific maximized 
            if (window.WindowState == WindowState.Maximized )
            {
                // sqrt( (x2 - x1)^2 + (y2 - y1)^2 )
                if (Math.Sqrt(Math.Pow(_mouseCurPos.X - _restoreMousePos.X, 2) + Math.Pow(_mouseCurPos.Y - _restoreMousePos.Y, 2)) > 1.0)
                {
                    // save last maximized scale
                    Point lastMaximizedScale = new Point(AssociatedObject.ActualWidth, AssociatedObject.ActualHeight);

                    // to normal
                    window.WindowState = WindowState.Normal;

                    // set reposition
                    window.Left = screenMousePosition.X - _restoreMousePos.X * (AssociatedObject.ActualWidth / lastMaximizedScale.X);
                    window.Top = screenMousePosition.Y - _restoreMousePos.Y * (AssociatedObject.ActualHeight / lastMaximizedScale.Y);
                }
            }

            // change
            if(_isRestoreMouseDragMode is false)
                _isRestoreMouseDragMode = true;

            // movement
            if (_isRestoreMouseDragMode is true)
                window.DragMove();
        }

        /// <summary>
        /// 
        /// </summary>
        private void MouseLeftDragEnd()
        {
            _isRestoreMouseDragMode = false;
        }

    }
}
