using System.Windows;
using System.Windows.Input;

namespace SimpleOverlayTheme.AttachedBehavior.WindowHeader
{

    internal static class WindowPlacement
    {
        private static readonly TimeSpan DoubleClickThreshold = TimeSpan.FromMilliseconds(200);
        private static Point _lastClickPosition;
        private static DateTime _lastClickTime;
        private static bool _isDragging = false;
        private static Point _restoreClickPoint;

        /// <summary> Attaches the mouse event handlers to a UI element to enable custom window dragging behavior. </summary>
        /// <param name="dragArea">The UI element (typically a header) that will act as a drag surface.</param>
        public static void Attach(FrameworkElement dragArea)
        {
            dragArea.MouseLeftButtonDown += OnMouseLeftButtonDown;
            dragArea.MouseMove += OnMouseMove;
            dragArea.MouseLeftButtonUp += OnMouseLeftButtonUp;
            dragArea.LostMouseCapture += OnLostMouseCapture;
        }

        /// <summary> Detaches the previously attached mouse event handlers from the UI element. </summary>
        /// <param name="dragArea">The drag surface element to remove event bindings from.</param>
        public static void Detach(FrameworkElement dragArea)
        {
            dragArea.MouseLeftButtonDown -= OnMouseLeftButtonDown;
            dragArea.MouseMove -= OnMouseMove;
            dragArea.MouseLeftButtonUp -= OnMouseLeftButtonUp;
            dragArea.LostMouseCapture -= OnLostMouseCapture;
        }

        /// <summary> Handles the MouseLeftButtonDown event. Captures the mouse and checks for double-click to toggle window state. </summary>
        private static void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is not FrameworkElement element) return;

            var window = Window.GetWindow(element);
            if (window == null) return;

            var now = DateTime.Now;
            var position = e.GetPosition(window);

            // double click detection
            if ((now - _lastClickTime) <= DoubleClickThreshold &&
                (Math.Abs(position.X - _lastClickPosition.X) < SystemParameters.MinimumHorizontalDragDistance &&
                 Math.Abs(position.Y - _lastClickPosition.Y) < SystemParameters.MinimumVerticalDragDistance))
            {
                ToggleWindowState(window);
                e.Handled = true;
                return;
            }

            _lastClickTime = now;
            _lastClickPosition = position;

            if (window.WindowState == WindowState.Maximized)
            {
                _restoreClickPoint = e.GetPosition(window);
            }

            element.CaptureMouse();
            _isDragging = true;
        }

        /// <summary>
        /// Handles the MouseMove event to allow window dragging. <br/>
        /// If maximized, restores the window and repositions it before drag.
        /// </summary>
        private static void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDragging) return;

            if (sender is not FrameworkElement element) return;
            var window = Window.GetWindow(element);
            if (window == null) return;

            if (e.LeftButton != MouseButtonState.Pressed)
            {
                EndDrag(element);
                return;
            }

            var pos = e.GetPosition(window);
            var screenPos = window.PointToScreen(pos);

            if (window.WindowState == WindowState.Maximized)
            {
                // Restore when a valid move is made.
                if (Math.Sqrt(Math.Pow(pos.X - _restoreClickPoint.X, 2) + Math.Pow(pos.Y - _restoreClickPoint.Y, 2)) > 2)
                {
                    double percentX = pos.X / window.ActualWidth;

                    window.WindowState = WindowState.Normal;

                    window.Left = screenPos.X - window.Width * percentX;
                    window.Top = screenPos.Y - _restoreClickPoint.Y;

                    try { window.DragMove(); } catch { }
                    EndDrag(element);
                }
            }
            else
            {
                try { window.DragMove(); } catch { }
                EndDrag(element);
            }
        }

        /// <summary> Handles the MouseLeftButtonUp event. Ends the dragging operation. </summary>
        private static void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is not FrameworkElement element) return;
            EndDrag(element);
        }

        /// <summary> Handles the LostMouseCapture event. Ensures drag state is reset when mouse capture is lost. </summary>
        private static void OnLostMouseCapture(object sender, MouseEventArgs e)
        {
            if (sender is not FrameworkElement element) return;
            EndDrag(element);
        }

        /// <summary> Ends the drag operation and releases the mouse capture. </summary>
        /// <param name="element">The UI element that captured the mouse.</param>
        private static void EndDrag(FrameworkElement element)
        {
            _isDragging = false;
            element.ReleaseMouseCapture();
        }

        /// <summary> Toggles the window state between Normal and Maximized. </summary>
        /// <param name="window">The window to toggle state for.</param>
        private static void ToggleWindowState(Window window)
        {
            if (window.WindowState == WindowState.Maximized)
                window.SetCurrentValue(Window.WindowStateProperty, WindowState.Normal);
            else
                window.SetCurrentValue(Window.WindowStateProperty, WindowState.Maximized);
        }
    }
}

