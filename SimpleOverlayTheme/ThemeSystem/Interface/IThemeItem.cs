using SimpleIniController;
namespace SimpleOverlayTheme.ThemeSystem.Interface
{
    public interface IThemeItem
    {

        public bool SetValue_Form(IniFile? iniFile);

        public bool GetValue_Form(IniFile? iniFile);

        public void ResetDefault();

    }
}
