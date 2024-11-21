using SimpleFileIO.State.Ini;

namespace SimpleOverlayTheme.ThemeSystem.Interface
{
    public interface IThemeItem
    {

        public bool SetValue_Form(IINIState? iniFile);

        public bool GetValue_Form(IINIState? iniFile);

        public void ResetDefault();

    }
}
