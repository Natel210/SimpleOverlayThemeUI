using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GrayThemeUI_Test.ExamplePage
{
    /// <summary>
    /// ButtonExample.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ButtonExample : Page
    {
        public ButtonExample()
        {
            InitializeComponent();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            GrayThemeUI.Theme.ThemeSettingDataManager.CurrentThemeName = "Dark";
            var getToggleButton = sender as ToggleButton;
            if (getToggleButton is not null)
                getToggleButton.Content = " To Light (ToggleButton) ";
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            GrayThemeUI.Theme.ThemeSettingDataManager.CurrentThemeName = "Light";
            var getToggleButton = sender as ToggleButton;
            if (getToggleButton is not null)
                getToggleButton.Content = " To Dark (ToggleButton) ";
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //GrayThemeUI.Theme.ThemeSettingDataManager.OverlayBoaderBackground_Active = new SolidColorBrush(Color.FromArgb(255, 255, 255, 0));
        }

        private void DefaultTitleOff(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this);
            parentWindow.WindowStyle = WindowStyle.None;
        }

        private void DefaultTitleOn(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this);
            parentWindow.WindowStyle = WindowStyle.SingleBorderWindow;
        }
    }
}
