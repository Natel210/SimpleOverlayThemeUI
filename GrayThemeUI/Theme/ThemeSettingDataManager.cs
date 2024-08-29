using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using utility.ini;

namespace GrayThemeUI.Theme
{
    public static partial class ThemeSettingDataManager
    {
        private static readonly IniFile _iniFile = new("./GrayThemeUI/ThemeData.ini");

        

        public static Dictionary<string, ThemeSettingData> DataDictionary { get; } = new Dictionary<string, ThemeSettingData>();



        public static void CreateThemeSettingData(string name, string iniPath)
        {
            ThemeSettingData tempData = new(name, iniPath);
            DataDictionary[name] = tempData;
            tempData.Save();
        }

        public static void CreateThemeSettingData_FromCurrentValue(string name, string iniPath)
        {
            ThemeSettingData tempData = new(name, iniPath);

            tempData.FontSize.Header1.Value = FontSize_Header1;
            tempData.FontSize.Header2.Value = FontSize_Header2;
            tempData.FontSize.Header3.Value = FontSize_Header3;
            tempData.FontSize.Header4.Value = FontSize_Header4;
            tempData.FontSize.Header5.Value = FontSize_Header5;
            tempData.FontSize.Header6.Value = FontSize_Header6;
            tempData.FontSize.Default.Value = FontSize_Default;

            tempData.DefaultBrush.Foreground.Value = DefaultBrush_Foreground;
            tempData.DefaultBrush.Foreground_Disable.Value = DefaultBrush_Foreground_Disable;
            tempData.DefaultBrush.Background.Value = DefaultBrush_Background;
            tempData.DefaultBrush.Outline.Value = DefaultBrush_Outline;
            tempData.DefaultBrush.Line.Value = DefaultBrush_Line;
            tempData.DefaultBrush.Highlight.Value = DefaultBrush_Highlight;
            tempData.DefaultBrush.Selection.Value = DefaultBrush_Selection;
            tempData.DefaultBrush.Mask.Value = DefaultBrush_Mask;

            tempData.OverlayBoaderBackground.Disable.Value = OverlayBoaderBackground_Disable;
            tempData.OverlayBoaderBackground.Default.Value = OverlayBoaderBackground_Default;
            tempData.OverlayBoaderBackground.MouseOver.Value = OverlayBoaderBackground_MouseOver;
            tempData.OverlayBoaderBackground.Active.Value = OverlayBoaderBackground_Active;

            tempData.OverlayBoaderOutline.Disable.Value = OverlayBoaderOutline_Disable;
            tempData.OverlayBoaderOutline.Default.Value = OverlayBoaderOutline_Default;
            tempData.OverlayBoaderOutline.MouseOver.Value = OverlayBoaderOutline_MouseOver;
            tempData.OverlayBoaderOutline.Active.Value = OverlayBoaderOutline_Active;

            tempData.OverlayMaskForeground.Disable.Value = OverlayMaskForeground_Disable;
            tempData.OverlayMaskForeground.Default.Value = OverlayMaskForeground_Default;
            tempData.OverlayMaskForeground.MouseOver.Value = OverlayMaskForeground_MouseOver;
            tempData.OverlayMaskForeground.Active.Value = OverlayMaskForeground_Active;

            DataDictionary[name] = tempData;
            tempData.Save();
        }

        public static ThemeSettingData? GetThemeSettingData(string name)
        {
            if (DataDictionary.ContainsKey(name) is false)
                return null;
            return DataDictionary[name];
        }

        public static string[] GetThemeNameList()
        {
            return DataDictionary.Keys.ToArray();
        }



        static ThemeSettingDataManager()
        {
            Load();
            MakeDefaultTheme();
        }


        public static bool Load()
        {
            if (_iniFile is null)
                return false;
            if (_iniFile.Load() is false)
                return false;

            string currentThemeName = _iniFile.GetValue("Common", "CurrentThemeName", "Light");
            if (string.IsNullOrEmpty(currentThemeName) is true)
                return false;

            string[] themeNameList = _iniFile.GetValue("Common", "ThemeNameList", []);
            if (themeNameList.Length is 0)
                return false;

            DataDictionary.Clear();
            foreach (var item in themeNameList)
            {
                string tempPath = _iniFile.GetValue(item, "Path", "");
                if (string.IsNullOrEmpty(tempPath) is false)
                    DataDictionary[item] = new(item, tempPath);
            }

            bool result = false;
            foreach (var item in DataDictionary)
                result |= !item.Value.Load();

            CurrentThemeName = currentThemeName;

            return !result;
        }

        private static void MakeDefaultTheme()
        {
            #region Make Light Theme
            CreateThemeSettingData("Light", "./GrayThemeUI/ThemeDataItem/Light.data");
            if (GetThemeSettingData("Light") is ThemeSettingData lightTheme)
            {
                lightTheme.FontSize.Header1.DefaultValue = InnerItems.FontSize.BaceValue.Header1;
                lightTheme.FontSize.Header2.DefaultValue = InnerItems.FontSize.BaceValue.Header2;
                lightTheme.FontSize.Header3.DefaultValue = InnerItems.FontSize.BaceValue.Header3;
                lightTheme.FontSize.Header4.DefaultValue = InnerItems.FontSize.BaceValue.Header4;
                lightTheme.FontSize.Header5.DefaultValue = InnerItems.FontSize.BaceValue.Header5;
                lightTheme.FontSize.Header6.DefaultValue = InnerItems.FontSize.BaceValue.Header6;
                lightTheme.FontSize.Default.DefaultValue = InnerItems.FontSize.BaceValue.Default;

                lightTheme.DefaultBrush.Foreground.DefaultValue = InnerItems.DefaultBrush.BaceValue.Foreground;
                lightTheme.DefaultBrush.Foreground_Disable.DefaultValue = InnerItems.DefaultBrush.BaceValue.Foreground_Disable;
                lightTheme.DefaultBrush.Background.DefaultValue = InnerItems.DefaultBrush.BaceValue.Background;
                lightTheme.DefaultBrush.Outline.DefaultValue = InnerItems.DefaultBrush.BaceValue.Outline;
                lightTheme.DefaultBrush.Line.DefaultValue = InnerItems.DefaultBrush.BaceValue.Line;
                lightTheme.DefaultBrush.Highlight.DefaultValue = InnerItems.DefaultBrush.BaceValue.Highlight;
                lightTheme.DefaultBrush.Selection.DefaultValue = InnerItems.DefaultBrush.BaceValue.Selection;
                lightTheme.DefaultBrush.Mask.DefaultValue = InnerItems.DefaultBrush.BaceValue.Mask;

                lightTheme.OverlayBoaderBackground.Disable.DefaultValue = InnerItems.OverlayBoaderBackground.BaceValue.Disable;
                lightTheme.OverlayBoaderBackground.Default.DefaultValue = InnerItems.OverlayBoaderBackground.BaceValue.Default;
                lightTheme.OverlayBoaderBackground.MouseOver.DefaultValue = InnerItems.OverlayBoaderBackground.BaceValue.MouseOver;
                lightTheme.OverlayBoaderBackground.Active.DefaultValue = InnerItems.OverlayBoaderBackground.BaceValue.Active;

                lightTheme.OverlayBoaderOutline.Disable.DefaultValue = InnerItems.OverlayBoaderOutline.BaceValue.Disable;
                lightTheme.OverlayBoaderOutline.Default.DefaultValue = InnerItems.OverlayBoaderOutline.BaceValue.Default;
                lightTheme.OverlayBoaderOutline.MouseOver.DefaultValue = InnerItems.OverlayBoaderOutline.BaceValue.MouseOver;
                lightTheme.OverlayBoaderOutline.Active.DefaultValue = InnerItems.OverlayBoaderOutline.BaceValue.Active;

                lightTheme.OverlayMaskForeground.Disable.DefaultValue = InnerItems.OverlayMaskForeground.BaceValue.Disable;
                lightTheme.OverlayMaskForeground.Default.DefaultValue = InnerItems.OverlayMaskForeground.BaceValue.Default;
                lightTheme.OverlayMaskForeground.MouseOver.DefaultValue = InnerItems.OverlayMaskForeground.BaceValue.MouseOver;
                lightTheme.OverlayMaskForeground.Active.DefaultValue = InnerItems.OverlayMaskForeground.BaceValue.Active;

                lightTheme.ResetDefault();
            }
            else
                throw new Exception("no making theme [Light].");
            #endregion
            #region Make Dark Theme
            CreateThemeSettingData("Dark", "./GrayThemeUI/ThemeDataItem/Dark.data");

            if (GetThemeSettingData("Dark") is ThemeSettingData darkTheme)
            {
                darkTheme.FontSize.Header1.DefaultValue = InnerItems.FontSize.BaceValue.Header1;
                darkTheme.FontSize.Header2.DefaultValue = InnerItems.FontSize.BaceValue.Header2;
                darkTheme.FontSize.Header3.DefaultValue = InnerItems.FontSize.BaceValue.Header3;
                darkTheme.FontSize.Header4.DefaultValue = InnerItems.FontSize.BaceValue.Header4;
                darkTheme.FontSize.Header5.DefaultValue = InnerItems.FontSize.BaceValue.Header5;
                darkTheme.FontSize.Header6.DefaultValue = InnerItems.FontSize.BaceValue.Header6;
                darkTheme.FontSize.Default.DefaultValue = InnerItems.FontSize.BaceValue.Default;

                darkTheme.DefaultBrush.Foreground.DefaultValue = InnerItems.DefaultBrush.BaceValueDark.Foreground;
                darkTheme.DefaultBrush.Foreground_Disable.DefaultValue = InnerItems.DefaultBrush.BaceValueDark.Foreground_Disable;
                darkTheme.DefaultBrush.Background.DefaultValue = InnerItems.DefaultBrush.BaceValueDark.Background;
                darkTheme.DefaultBrush.Outline.DefaultValue = InnerItems.DefaultBrush.BaceValue.Outline;
                darkTheme.DefaultBrush.Line.DefaultValue = InnerItems.DefaultBrush.BaceValue.Line;
                darkTheme.DefaultBrush.Highlight.DefaultValue = InnerItems.DefaultBrush.BaceValue.Highlight;
                darkTheme.DefaultBrush.Selection.DefaultValue = InnerItems.DefaultBrush.BaceValue.Selection;
                darkTheme.DefaultBrush.Mask.DefaultValue = InnerItems.DefaultBrush.BaceValue.Mask;

                darkTheme.OverlayBoaderBackground.Disable.DefaultValue = InnerItems.OverlayBoaderBackground.BaceValueDark.Disable;
                darkTheme.OverlayBoaderBackground.Default.DefaultValue = InnerItems.OverlayBoaderBackground.BaceValueDark.Default;
                darkTheme.OverlayBoaderBackground.MouseOver.DefaultValue = InnerItems.OverlayBoaderBackground.BaceValueDark.MouseOver;
                darkTheme.OverlayBoaderBackground.Active.DefaultValue = InnerItems.OverlayBoaderBackground.BaceValueDark.Active;

                darkTheme.OverlayBoaderOutline.Disable.DefaultValue = InnerItems.OverlayBoaderOutline.BaceValueDark.Disable;
                darkTheme.OverlayBoaderOutline.Default.DefaultValue = InnerItems.OverlayBoaderOutline.BaceValueDark.Default;
                darkTheme.OverlayBoaderOutline.MouseOver.DefaultValue = InnerItems.OverlayBoaderOutline.BaceValueDark.MouseOver;
                darkTheme.OverlayBoaderOutline.Active.DefaultValue = InnerItems.OverlayBoaderOutline.BaceValueDark.Active;

                darkTheme.OverlayMaskForeground.Disable.DefaultValue = InnerItems.OverlayMaskForeground.BaceValueDark.Disable;
                darkTheme.OverlayMaskForeground.Default.DefaultValue = InnerItems.OverlayMaskForeground.BaceValueDark.Default;
                darkTheme.OverlayMaskForeground.MouseOver.DefaultValue = InnerItems.OverlayMaskForeground.BaceValueDark.MouseOver;
                darkTheme.OverlayMaskForeground.Active.DefaultValue = InnerItems.OverlayMaskForeground.BaceValueDark.Active;

                darkTheme.ResetDefault();
            }
            else
                throw new Exception("no making theme [Dark].");
            #endregion
            CurrentThemeName = "Light";
            Save();
        }

        public static bool Save()
        {
            if (_iniFile is null)
                return false;
            _iniFile.SetValue("Common", "CurrentThemeName", CurrentThemeName);
            _iniFile.SetValue("Common", "ThemeNameList", DataDictionary.Keys.ToArray());
            foreach (var item in DataDictionary)
                _iniFile.SetValue(item.Key, "Path", item.Value.INI_PATH);
            _iniFile.Save();
            bool result = false;
            foreach (var item in DataDictionary)
                result |= !item.Value.Save();
            return !result;
        }
    }

    public static partial class ThemeSettingDataManager
    {
        public static event PropertyChangedEventHandler? PropertyChanged;
        private static void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        #region Property
        //Theme
        public static string CurrentThemeName
        {
            get => _currentThemeName;
            set
            {
                if (_currentThemeName == value)
                    return;
                if (DataDictionary.ContainsKey(value) is false)
                    return;
                if (GetThemeSettingData(value) is ThemeSettingData getTheme)
                {
                    _currentThemeName = value;

                    FontSize_Header1 = getTheme.FontSize.Header1.Value;
                    FontSize_Header2 = getTheme.FontSize.Header2.Value;
                    FontSize_Header3 = getTheme.FontSize.Header3.Value;
                    FontSize_Header4 = getTheme.FontSize.Header4.Value;
                    FontSize_Header5 = getTheme.FontSize.Header5.Value;
                    FontSize_Header6 = getTheme.FontSize.Header6.Value;
                    FontSize_Default = getTheme.FontSize.Default.Value;

                    DefaultBrush_Foreground = getTheme.DefaultBrush.Foreground.Value;
                    DefaultBrush_Foreground_Disable = getTheme.DefaultBrush.Foreground_Disable.Value;
                    DefaultBrush_Background = getTheme.DefaultBrush.Background.Value;
                    DefaultBrush_Outline = getTheme.DefaultBrush.Outline.Value;
                    DefaultBrush_Line = getTheme.DefaultBrush.Line.Value;
                    DefaultBrush_Highlight = getTheme.DefaultBrush.Highlight.Value;
                    DefaultBrush_Selection = getTheme.DefaultBrush.Selection.Value;
                    DefaultBrush_Mask = getTheme.DefaultBrush.Mask.Value;

                    OverlayBoaderBackground_Disable = getTheme.OverlayBoaderBackground.Disable.Value;
                    OverlayBoaderBackground_Default = getTheme.OverlayBoaderBackground.Default.Value;
                    OverlayBoaderBackground_MouseOver = getTheme.OverlayBoaderBackground.MouseOver.Value;
                    OverlayBoaderBackground_Active = getTheme.OverlayBoaderBackground.Active.Value;

                    OverlayBoaderOutline_Disable = getTheme.OverlayBoaderOutline.Disable.Value;
                    OverlayBoaderOutline_Default = getTheme.OverlayBoaderOutline.Default.Value;
                    OverlayBoaderOutline_MouseOver = getTheme.OverlayBoaderOutline.MouseOver.Value;
                    OverlayBoaderOutline_Active = getTheme.OverlayBoaderOutline.Active.Value;

                    OverlayMaskForeground_Disable = getTheme.OverlayMaskForeground.Disable.Value;
                    OverlayMaskForeground_Default = getTheme.OverlayMaskForeground.Default.Value;
                    OverlayMaskForeground_MouseOver = getTheme.OverlayMaskForeground.MouseOver.Value;
                    OverlayMaskForeground_Active = getTheme.OverlayMaskForeground.Active.Value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.CurrentThemeName));
                }
            }
        }
        //FontSize
        public static double FontSize_Header1
        {
            get => _fontSize_Header1;
            set
            {
                if (_fontSize_Header1 != value)
                {
                    _fontSize_Header1 = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.FontSize_Header1));
                }
            }
        }
        public static double FontSize_Header2
        {
            get => _fontSize_Header2;
            set
            {
                if (_fontSize_Header2 != value)
                {
                    _fontSize_Header2 = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.FontSize_Header2));
                }
            }
        }
        public static double FontSize_Header3
        {
            get => _fontSize_Header3;
            set
            {
                if (_fontSize_Header3 != value)
                {
                    _fontSize_Header3 = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.FontSize_Header3));
                }
            }
        }
        public static double FontSize_Header4
        {
            get => _fontSize_Header4;
            set
            {
                if (_fontSize_Header4 != value)
                {
                    _fontSize_Header4 = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.FontSize_Header4));
                }
            }
        }
        public static double FontSize_Header5
        {
            get => _fontSize_Header5;
            set
            {
                if (_fontSize_Header5 != value)
                {
                    _fontSize_Header5 = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.FontSize_Header5));
                }
            }
        }
        public static double FontSize_Header6
        {
            get => _fontSize_Header6;
            set
            {
                if (_fontSize_Header6 != value)
                {
                    _fontSize_Header6 = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.FontSize_Header6));
                }
            }
        }
        public static double FontSize_Default
        {
            get => _fontSize_Default;
            set
            {
                if (_fontSize_Default != value)
                {
                    _fontSize_Default = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.FontSize_Default));
                }
            }
        }
        //DefaultBrush
        public static Color DefaultBrush_Foreground
        {
            get => _defaultBrush_Foreground;
            set
            {
                if (_defaultBrush_Foreground != value)
                {
                    _defaultBrush_Foreground = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.DefaultBrush_Foreground));
                }
            }
        }
        public static Color DefaultBrush_Foreground_Disable
        {
            get => _defaultBrush_Foreground_Disable;
            set
            {
                if (_defaultBrush_Foreground_Disable != value)
                {
                    _defaultBrush_Foreground_Disable = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.DefaultBrush_Foreground_Disable));
                }
            }
        }
        public static Color DefaultBrush_Background
        {
            get => _defaultBrush_Background;
            set
            {
                if (_defaultBrush_Background != value)
                {
                    _defaultBrush_Background = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.DefaultBrush_Background));
                }
            }
        }
        public static Color DefaultBrush_Outline
        {
            get => _defaultBrush_Outline;
            set
            {
                if (_defaultBrush_Outline != value)
                {
                    _defaultBrush_Outline = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.DefaultBrush_Outline));
                }
            }
        }
        public static Color DefaultBrush_Line
        {
            get => _defaultBrush_Line;
            set
            {
                if (_defaultBrush_Line != value)
                {
                    _defaultBrush_Line = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.DefaultBrush_Line));
                }
            }
        }
        public static Color DefaultBrush_Highlight
        {
            get => _defaultBrush_Highlight;
            set
            {
                if (_defaultBrush_Highlight != value)
                {
                    _defaultBrush_Highlight = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.DefaultBrush_Highlight));
                }
            }
        }
        public static Color DefaultBrush_Selection
        {
            get => _defaultBrush_Selection;
            set
            {
                if (_defaultBrush_Selection != value)
                {
                    _defaultBrush_Selection = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.DefaultBrush_Selection));
                }
            }
        }
        public static Color DefaultBrush_Mask
        {
            get => _defaultBrush_Mask;
            set
            {
                if (_defaultBrush_Mask != value)
                {
                    _defaultBrush_Mask = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.DefaultBrush_Mask));
                }
            }
        }
        //OverlayBoader.Background
        public static Color OverlayBoaderBackground_Disable
        {
            get => _overlayBoaderBackground_Disable;
            set
            {
                if (_overlayBoaderBackground_Disable != value)
                {
                    _overlayBoaderBackground_Disable = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.OverlayBoaderBackground_Disable));
                }
            }
        }
        public static Color OverlayBoaderBackground_Default
        {
            get => _overlayBoaderBackground_Default;
            set
            {
                if (_overlayBoaderBackground_Default != value)
                {
                    _overlayBoaderBackground_Default = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.OverlayBoaderBackground_Default));
                }
            }
        }
        public static Color OverlayBoaderBackground_MouseOver
        {
            get => _overlayBoaderBackground_MouseOver;
            set
            {
                if (_overlayBoaderBackground_MouseOver != value)
                {
                    _overlayBoaderBackground_MouseOver = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.OverlayBoaderBackground_MouseOver));
                }
            }
        }
        public static Color OverlayBoaderBackground_Active
        {
            get => _overlayBoaderBackground_Active;
            set
            {
                if (_overlayBoaderBackground_Active != value)
                {
                    _overlayBoaderBackground_Active = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.OverlayBoaderBackground_Active));
                }
            }
        }
        //OverlayBoader.Outline
        public static Color OverlayBoaderOutline_Disable
        {
            get => _overlayBoaderOutline_Disable;
            set
            {
                if (_overlayBoaderOutline_Disable != value)
                {
                    _overlayBoaderOutline_Disable = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.OverlayBoaderOutline_Disable));
                }
            }
        }
        public static Color OverlayBoaderOutline_Default
        {
            get => _overlayBoaderOutline_Default;
            set
            {
                if (_overlayBoaderOutline_Default != value)
                {
                    _overlayBoaderOutline_Default = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.OverlayBoaderOutline_Default));
                }
            }
        }
        public static Color OverlayBoaderOutline_MouseOver
        {
            get => _overlayBoaderOutline_MouseOver;
            set
            {
                if (_overlayBoaderOutline_MouseOver != value)
                {
                    _overlayBoaderOutline_MouseOver = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.OverlayBoaderOutline_MouseOver));
                }
            }
        }
        public static Color OverlayBoaderOutline_Active
        {
            get => _overlayBoaderOutline_Active;
            set
            {
                if (_overlayBoaderOutline_Active != value)
                {
                    _overlayBoaderOutline_Active = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.OverlayBoaderOutline_Active));
                }
            }
        }
        //OverlayMask.Foreground
        public static Color OverlayMaskForeground_Disable
        {
            get => _overlayMaskForeground_Disable;
            set
            {
                if (_overlayMaskForeground_Disable != value)
                {
                    _overlayMaskForeground_Disable = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.OverlayMaskForeground_Disable));
                }
            }
        }
        public static Color OverlayMaskForeground_Default
        {
            get => _overlayMaskForeground_Default;
            set
            {
                if (_overlayMaskForeground_Default != value)
                {
                    _overlayMaskForeground_Default = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.OverlayMaskForeground_Default));
                }
            }
        }
        public static Color OverlayMaskForeground_MouseOver
        {
            get => _overlayMaskForeground_MouseOver;
            set
            {
                if (_overlayMaskForeground_MouseOver != value)
                {
                    _overlayMaskForeground_MouseOver = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.OverlayMaskForeground_MouseOver));
                }
            }
        }
        public static Color OverlayMaskForeground_Active
        {
            get => _overlayMaskForeground_Active;
            set
            {
                if (_overlayMaskForeground_Active != value)
                {
                    _overlayMaskForeground_Active = value;
                    OnPropertyChanged(nameof(ThemeSettingDataManager.OverlayMaskForeground_Active));
                }
            }
        }
        #endregion

        #region Private Property Source
        //Theme
        private static string _currentThemeName = "";
        //FontSize
        private static double _fontSize_Header1 = InnerItems.FontSize.BaceValue.Header1;
        private static double _fontSize_Header2 = InnerItems.FontSize.BaceValue.Header2;
        private static double _fontSize_Header3 = InnerItems.FontSize.BaceValue.Header3;
        private static double _fontSize_Header4 = InnerItems.FontSize.BaceValue.Header4;
        private static double _fontSize_Header5 = InnerItems.FontSize.BaceValue.Header5;
        private static double _fontSize_Header6 = InnerItems.FontSize.BaceValue.Header6;
        private static double _fontSize_Default = InnerItems.FontSize.BaceValue.Default;
        //DefaultBrush
        private static Color _defaultBrush_Foreground = InnerItems.DefaultBrush.BaceValue.Foreground;
        private static Color _defaultBrush_Foreground_Disable = InnerItems.DefaultBrush.BaceValue.Foreground_Disable;
        private static Color _defaultBrush_Background = InnerItems.DefaultBrush.BaceValue.Background;
        private static Color _defaultBrush_Outline = InnerItems.DefaultBrush.BaceValue.Outline;
        private static Color _defaultBrush_Line = InnerItems.DefaultBrush.BaceValue.Line;
        private static Color _defaultBrush_Highlight = InnerItems.DefaultBrush.BaceValue.Highlight;
        private static Color _defaultBrush_Selection = InnerItems.DefaultBrush.BaceValue.Selection;
        private static Color _defaultBrush_Mask = InnerItems.DefaultBrush.BaceValue.Mask;
        //OverlayBoader.Background
        private static Color _overlayBoaderBackground_Disable = InnerItems.OverlayBoaderBackground.BaceValue.Disable;
        private static Color _overlayBoaderBackground_Default = InnerItems.OverlayBoaderBackground.BaceValue.Default;
        private static Color _overlayBoaderBackground_MouseOver = InnerItems.OverlayBoaderBackground.BaceValue.MouseOver;
        private static Color _overlayBoaderBackground_Active = InnerItems.OverlayBoaderBackground.BaceValue.Active;
        //OverlayBoader.Outline
        private static Color _overlayBoaderOutline_Disable = InnerItems.OverlayBoaderOutline.BaceValue.Disable;
        private static Color _overlayBoaderOutline_Default = InnerItems.OverlayBoaderOutline.BaceValue.Default;
        private static Color _overlayBoaderOutline_MouseOver = InnerItems.OverlayBoaderOutline.BaceValue.MouseOver;
        private static Color _overlayBoaderOutline_Active = InnerItems.OverlayBoaderOutline.BaceValue.Active;
        //OverlayMask.Foreground
        private static Color _overlayMaskForeground_Disable = InnerItems.OverlayMaskForeground.BaceValue.Disable;
        private static Color _overlayMaskForeground_Default = InnerItems.OverlayMaskForeground.BaceValue.Default;
        private static Color _overlayMaskForeground_MouseOver = InnerItems.OverlayMaskForeground.BaceValue.MouseOver;
        private static Color _overlayMaskForeground_Active = InnerItems.OverlayMaskForeground.BaceValue.Active;
        #endregion

    }
}
