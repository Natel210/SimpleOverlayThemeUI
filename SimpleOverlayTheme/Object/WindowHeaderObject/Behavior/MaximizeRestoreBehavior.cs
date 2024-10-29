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

            if (Window.GetWindow(AssociatedObject) is Window window)
            {
                window.StateChanged += OnWindowStateChanged;
                UpdateButtonState(window); // 초기 상태 설정
            }

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

        private void OnWindowStateChanged(object? sender, EventArgs e)
        {
            var window = sender as Window;
            if (window is null)
                return;

            UpdateButtonState(window);
            bool isNoneWindowStyle = window.WindowStyle == WindowStyle.None;
            bool canResize = window.ResizeMode == ResizeMode.CanResizeWithGrip
                || window.ResizeMode == ResizeMode.CanResize;

            if (isNoneWindowStyle && canResize)
            {
                if (window.WindowState == WindowState.Maximized)
                {
                    window.Margin = new Thickness(15); // 윈도우 크기 조정 시 추가할 패딩
                                                       //window.Margin = new Thickness(8);  // 기본 마진으로 조정
                }
                else
                {
                    window.Margin = new Thickness(0); // 윈도우 크기 조정 시 추가할 패딩
                                                       //window.Margin = new Thickness(0);  // 기본 마진으로 조정
                }
            }
        }

        private void UpdateButtonState(Window window)
        {
            AssociatedObject.SetCurrentValue(ToggleButton.IsCheckedProperty, window.WindowState == WindowState.Maximized);
        }
    }
}
