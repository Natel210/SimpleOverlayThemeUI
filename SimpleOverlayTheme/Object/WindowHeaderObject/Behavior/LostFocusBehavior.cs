using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;


namespace SimpleOverlayTheme.Object.WindowHeaderObject.Behavior
{
    public class LostFocusBehavior : Behavior<FrameworkElement>
    {
        private Window? _parentWindow;

        protected override void OnAttached()
        {
            base.OnAttached();

            // 비헤이비어가 적용된 요소의 부모 윈도우 가져오기
            _parentWindow = Window.GetWindow(AssociatedObject);
            if (_parentWindow != null)
            {
                // 활성화, 비활성화 이벤트에 대한 구독
                _parentWindow.Activated += OnWindowActivated;
                _parentWindow.Deactivated += OnWindowDeactivated;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            // 이벤트 구독 해제
            if (_parentWindow != null)
            {
                _parentWindow.Activated -= OnWindowActivated;
                _parentWindow.Deactivated -= OnWindowDeactivated;
            }
        }

        // 윈도우 활성화(포커스 인) 시 실행되는 메서드
        private void OnWindowActivated(object? sender, EventArgs e)
        {
            // 포커스가 들어왔을 때 원하는 동작 정의
            if (AssociatedObject is Border focusOverlay)
                focusOverlay.Visibility = Visibility.Hidden;  // 포커스 인 시, 보이지 않게 설정
        }

        // 윈도우 비활성화(포커스 아웃) 시 실행되는 메서드
        private void OnWindowDeactivated(object? sender, EventArgs e)
        {
            // 포커스가 나갔을 때 원하는 동작 정의
            if (AssociatedObject is Border focusOverlay)
                focusOverlay.Visibility = Visibility.Visible;  // 포커스 아웃 시, 보이게 설정
        }
    }
}
