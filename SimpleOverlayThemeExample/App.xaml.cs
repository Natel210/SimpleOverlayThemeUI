using System.Configuration;
using System.Data;
using System.Windows;
using SimpleOverlayTheme.ThemeSystem;

namespace SimpleOverlayThemeExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Manager.InitializeModule();
            //Manager.CurrentThemeName = "Dark";
        }
    }

}
