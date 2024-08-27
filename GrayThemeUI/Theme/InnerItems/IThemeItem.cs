using utility.ini;

namespace GrayThemeUI.Theme.InnerItems
{
    public interface IThemeItem
    {

        public bool SetValue_Form(IniFile? iniFile);

        public bool GetValue_Form(IniFile? iniFile);

        public void ResetDefault();

    }
}
