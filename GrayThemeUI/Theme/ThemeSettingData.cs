using utility.ini;
namespace GrayThemeUI.Theme
{
    public class ThemeSettingData
    {

        private readonly IniFile _iniFile;

        private string _name;

        //Commons
        public InnerItems.FontSize FontSize { get; } = new();

        public InnerItems.DefaultBrush DefaultBrush { get; } = new();

        public InnerItems.OverlayBoaderBackground OverlayBoaderBackground { get; } = new();

        public InnerItems.OverlayBoaderOutline OverlayBoaderOutline { get; } = new();

        public InnerItems.OverlayMaskForeground OverlayMaskForeground { get; } = new();

        public string INI_PATH
        {
            get => _iniFile.FilePath;
            set => _iniFile.FilePath = value;
        }

        public string Name
        {
            get => _name;
        }

        internal ThemeSettingData(string name, string iniPath)
        {
            _name = name;
            _iniFile = new(iniPath);
            /*bool*/Load();
        }

        public bool Save()
        {
            if (_iniFile is null)
                return false;
            bool result = false;
            result |= !FontSize.SetValue_Form(_iniFile);
            result |= !DefaultBrush.SetValue_Form(_iniFile);
            result |= !OverlayBoaderBackground.SetValue_Form(_iniFile);
            result |= !OverlayBoaderOutline.SetValue_Form(_iniFile);
            result |= !OverlayMaskForeground.SetValue_Form(_iniFile);
            _iniFile.Save();
            return !result;
        }
        public bool Load()
        {
            if (_iniFile is null)
                return false;
            if (_iniFile.Load() is false)
                return false;
            bool result = false;
            result |= !FontSize.GetValue_Form(_iniFile);
            result |= !DefaultBrush.GetValue_Form(_iniFile);
            result |= !OverlayBoaderBackground.SetValue_Form(_iniFile);
            result |= !OverlayBoaderOutline.SetValue_Form(_iniFile);
            result |= !OverlayMaskForeground.SetValue_Form(_iniFile);
            return !result;
        }

        public void ResetDefault()
        {
            FontSize.ResetDefault();
            DefaultBrush.ResetDefault();
            OverlayBoaderBackground.ResetDefault();
            OverlayBoaderOutline.ResetDefault();
            OverlayMaskForeground.ResetDefault();
        }
    }


}
