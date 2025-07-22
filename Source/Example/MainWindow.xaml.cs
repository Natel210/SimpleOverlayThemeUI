using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            

            SimpleVisualTheme.Theme.ThemeManager.Instance.DiscoverThemeData();
            InitializeComponent();
            PART_LIST.ItemsSource = OutuputList;
        }

        private ObservableCollection<string> OutuputList = new();


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SimpleVisualTheme.Theme.Current.Current.Instance.ThemeName = "Dark";
            OutuputList.Clear();
            OutuputList.Add( $"FontSize.Header : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<double>("FontSize.Header")}");
            OutuputList.Add( $"FontSize.Default : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<double>("FontSize.Default")}");
            OutuputList.Add( $"Color.Common.Background.Default : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<SolidColorBrush>("Color.Common.Background.Default")}");
            OutuputList.Add( $"Color.Common.Foreground.Default : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<SolidColorBrush>("Color.Common.Foreground.Default")}");
            OutuputList.Add( $"Color.Common.Foreground.Disable : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<SolidColorBrush>("Color.Common.Foreground.Disable")}");
            OutuputList.Add( $"Color.Common.Outline.Default : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<SolidColorBrush>("Color.Common.Outline.Default")}");
            OutuputList.Add( $"Color.Effect.Background.Active : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<SolidColorBrush>("Color.Effect.Background.Active")}");
            OutuputList.Add( $"Color.Effect.Background.Mouseover : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<SolidColorBrush>("Color.Effect.Background.Mouseover")}");
            OutuputList.Add( $"Color.Effect.Outline.Active : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<SolidColorBrush>("Color.Effect.Outline.Active")}");
            OutuputList.Add( $"Color.Effect.Outline.Mouseover : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<SolidColorBrush>("Color.Effect.Outline.Mouseover")}");



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SimpleVisualTheme.Theme.Current.Current.Instance.ThemeName = "Light";
            OutuputList.Clear();
            OutuputList.Add($"FontSize.Header : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<double>("FontSize.Header")}");
            OutuputList.Add($"FontSize.Default : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<double>("FontSize.Default")}");
            OutuputList.Add($"Color.Common.Background.Default : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<SolidColorBrush>("Color.Common.Background.Default")}");
            OutuputList.Add($"Color.Common.Foreground.Default : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<SolidColorBrush>("Color.Common.Foreground.Default")}");
            OutuputList.Add($"Color.Common.Foreground.Disable : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<SolidColorBrush>("Color.Common.Foreground.Disable")}");
            OutuputList.Add($"Color.Common.Outline.Default : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<SolidColorBrush>("Color.Common.Outline.Default")}");
            OutuputList.Add($"Color.Effect.Background.Active : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<SolidColorBrush>("Color.Effect.Background.Active")}");
            OutuputList.Add($"Color.Effect.Background.Mouseover : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<SolidColorBrush>("Color.Effect.Background.Mouseover")}");
            OutuputList.Add($"Color.Effect.Outline.Active : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<SolidColorBrush>("Color.Effect.Outline.Active")}");
            OutuputList.Add($"Color.Effect.Outline.Mouseover : " +
                $"{SimpleVisualTheme.Theme.ThemeManager.Instance.GetThemeProperty<SolidColorBrush>("Color.Effect.Outline.Mouseover")}");
        }
    }
}