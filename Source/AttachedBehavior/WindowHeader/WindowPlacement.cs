using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SimpleOverlayTheme.AttachedBehavior.WindowHeader
{
    public static class WindowPlacement
    {
        private static readonly TimeSpan DoubleClickThreshold = TimeSpan.FromMilliseconds(200);
        private static Point _lastClickPosition;
        private static DateTime _lastClickTime;
        private static bool _isDragging = false;
        private static Point _restoreClickPoint;

        public static void Attach(FrameworkElement dragArea)
        {
            dragArea.MouseLeftButtonDown += OnMouseLeftButtonDown;
            dragArea.MouseMove += OnMouseMove;
            dragArea.MouseLeftButtonUp += OnMouseLeftButtonUp;
            dragArea.LostMouseCapture += OnLostMouseCapture;
        }

        public static void Detach(FrameworkElement dragArea)
        {
            dragArea.MouseLeftButtonDown -= OnMouseLeftButtonDown;
            dragArea.MouseMove -= OnMouseMove;
            dragArea.MouseLeftButtonUp -= OnMouseLeftButtonUp;
            dragArea.LostMouseCapture -= OnLostMouseCapture;
        }

        private static void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is not FrameworkElement element) return;

            var window = Window.GetWindow(element);
            if (window == null) return;

            var now = DateTime.Now;
            var position = e.GetPosition(window);

            // 더블 클릭 감지
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

            // Capture 마우스
            element.CaptureMouse();
            _isDragging = true;
        }

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
                // 살짝 움직일 때만 복원
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

        private static void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is not FrameworkElement element) return;
            EndDrag(element);
        }

        private static void OnLostMouseCapture(object sender, MouseEventArgs e)
        {
            if (sender is not FrameworkElement element) return;
            EndDrag(element);
        }

        private static void EndDrag(FrameworkElement element)
        {
            _isDragging = false;
            element.ReleaseMouseCapture();
        }

        private static void ToggleWindowState(Window window)
        {
            if (window.WindowState == WindowState.Maximized)
                window.WindowState = WindowState.Normal;
            else
                window.WindowState = WindowState.Maximized;
        }
    }
}

