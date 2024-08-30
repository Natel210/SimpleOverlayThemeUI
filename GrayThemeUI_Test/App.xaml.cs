using GrayThemeUI.Theme;
using System.Windows;

namespace GrayThemeUI_Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ThemeSettingDataManager.InitializeModule();
        }
    }

}
