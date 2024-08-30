using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
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

            tempData.DefaultBrush.Foreground = DefaultBrush_Foreground;
            tempData.DefaultBrush.Foreground_Disable = DefaultBrush_Foreground_Disable;
            tempData.DefaultBrush.Background = DefaultBrush_Background;
            tempData.DefaultBrush.Outline = DefaultBrush_Outline;
            tempData.DefaultBrush.Line = DefaultBrush_Line;
            tempData.DefaultBrush.Highlight = DefaultBrush_Highlight;
            tempData.DefaultBrush.Selection = DefaultBrush_Selection;
            tempData.DefaultBrush.Mask = DefaultBrush_Mask;

            tempData.OverlayBoaderBackground.Disable = OverlayBoaderBackground_Disable;
            tempData.OverlayBoaderBackground.Default = OverlayBoaderBackground_Default;
            tempData.OverlayBoaderBackground.MouseOver = OverlayBoaderBackground_MouseOver;
            tempData.OverlayBoaderBackground.Active = OverlayBoaderBackground_Active;

            tempData.OverlayBoaderOutline.Disable = OverlayBoaderOutline_Disable;
            tempData.OverlayBoaderOutline.Default = OverlayBoaderOutline_Default;
            tempData.OverlayBoaderOutline.MouseOver = OverlayBoaderOutline_MouseOver;
            tempData.OverlayBoaderOutline.Active = OverlayBoaderOutline_Active;

            tempData.OverlayMaskForeground.Disable = OverlayMaskForeground_Disable;
            tempData.OverlayMaskForeground.Default = OverlayMaskForeground_Default;
            tempData.OverlayMaskForeground.MouseOver = OverlayMaskForeground_MouseOver;
            tempData.OverlayMaskForeground.Active = OverlayMaskForeground_Active;

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


        public static void InitializeModule()
        {
            Load();
            MakeDefaultTheme();
            Application.Current.Resources.MergedDictionaries.Add(new ThemeSetting());
        }

        static ThemeSettingDataManager()
        {
            //Load();
            //MakeDefaultTheme();
            //Application.Current.Resources.MergedDictionaries.Add(new ThemeSetting() );
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
            {
                result |= !item.Value.Save();
                var rootPath = Path.GetDirectoryName(_iniFile.FilePath) ?? "./GrayThemeUI/";
                item.Value.MakeDummyXaml(new DirectoryInfo(Path.Combine(rootPath, "ThemeDummy")));
            }
                
            //Make Dummy Data
            return !result;
        }

        private static void MakeDefaultTheme()
        {
            #region Make Light Theme
            CreateThemeSettingData("Light", "./GrayThemeUI/ThemeDataItem/Light.data");
            if (GetThemeSettingData("Light") is ThemeSettingData lightTheme)
            {
                lightTheme.FontSize.Header1.Value = InnerItems.FontSize.BaceValue.Header1;
                lightTheme.FontSize.Header2.Value = InnerItems.FontSize.BaceValue.Header2;
                lightTheme.FontSize.Header3.Value = InnerItems.FontSize.BaceValue.Header3;
                lightTheme.FontSize.Header4.Value = InnerItems.FontSize.BaceValue.Header4;
                lightTheme.FontSize.Header5.Value = InnerItems.FontSize.BaceValue.Header5;
                lightTheme.FontSize.Header6.Value = InnerItems.FontSize.BaceValue.Header6;
                lightTheme.FontSize.Default.Value = InnerItems.FontSize.BaceValue.Default;

                lightTheme.DefaultBrush.Foreground = new(InnerItems.DefaultBrush.BaceValue.Foreground);
                lightTheme.DefaultBrush.Foreground_Disable = new(InnerItems.DefaultBrush.BaceValue.Foreground_Disable);
                lightTheme.DefaultBrush.Background = new(InnerItems.DefaultBrush.BaceValue.Background);
                lightTheme.DefaultBrush.Outline = new(InnerItems.DefaultBrush.BaceValue.Outline);
                lightTheme.DefaultBrush.Line = new(InnerItems.DefaultBrush.BaceValue.Line);
                lightTheme.DefaultBrush.Highlight = new(InnerItems.DefaultBrush.BaceValue.Highlight);
                lightTheme.DefaultBrush.Selection = new(InnerItems.DefaultBrush.BaceValue.Selection);
                lightTheme.DefaultBrush.Mask = new(InnerItems.DefaultBrush.BaceValue.Mask);

                lightTheme.OverlayBoaderBackground.Disable = new(InnerItems.OverlayBoaderBackground.BaceValue.Disable);
                lightTheme.OverlayBoaderBackground.Default = new(InnerItems.OverlayBoaderBackground.BaceValue.Default);
                lightTheme.OverlayBoaderBackground.MouseOver = new(InnerItems.OverlayBoaderBackground.BaceValue.MouseOver);
                lightTheme.OverlayBoaderBackground.Active = new(InnerItems.OverlayBoaderBackground.BaceValue.Active);

                lightTheme.OverlayBoaderOutline.Disable = new(InnerItems.OverlayBoaderOutline.BaceValue.Disable);
                lightTheme.OverlayBoaderOutline.Default = new(InnerItems.OverlayBoaderOutline.BaceValue.Default);
                lightTheme.OverlayBoaderOutline.MouseOver = new(InnerItems.OverlayBoaderOutline.BaceValue.MouseOver);
                lightTheme.OverlayBoaderOutline.Active = new(InnerItems.OverlayBoaderOutline.BaceValue.Active);

                lightTheme.OverlayMaskForeground.Disable = new(InnerItems.OverlayMaskForeground.BaceValue.Disable);
                lightTheme.OverlayMaskForeground.Default = new(InnerItems.OverlayMaskForeground.BaceValue.Default);
                lightTheme.OverlayMaskForeground.MouseOver = new(InnerItems.OverlayMaskForeground.BaceValue.MouseOver);
                lightTheme.OverlayMaskForeground.Active = new(InnerItems.OverlayMaskForeground.BaceValue.Active);

                //lightTheme.ResetDefault();
            }
            else
                throw new Exception("no making theme [Light].");
            #endregion
            #region Make Dark Theme
            CreateThemeSettingData("Dark", "./GrayThemeUI/ThemeDataItem/Dark.data");

            if (GetThemeSettingData("Dark") is ThemeSettingData darkTheme)
            {
                darkTheme.FontSize.Header1.Value = InnerItems.FontSize.BaceValue.Header1;
                darkTheme.FontSize.Header2.Value = InnerItems.FontSize.BaceValue.Header2;
                darkTheme.FontSize.Header3.Value = InnerItems.FontSize.BaceValue.Header3;
                darkTheme.FontSize.Header4.Value = InnerItems.FontSize.BaceValue.Header4;
                darkTheme.FontSize.Header5.Value = InnerItems.FontSize.BaceValue.Header5;
                darkTheme.FontSize.Header6.Value = InnerItems.FontSize.BaceValue.Header6;
                darkTheme.FontSize.Default.Value = InnerItems.FontSize.BaceValue.Default;

                darkTheme.DefaultBrush.Foreground = new(InnerItems.DefaultBrush.BaceValueDark.Foreground);
                darkTheme.DefaultBrush.Foreground_Disable = new(InnerItems.DefaultBrush.BaceValueDark.Foreground_Disable);
                darkTheme.DefaultBrush.Background = new(InnerItems.DefaultBrush.BaceValueDark.Background);
                darkTheme.DefaultBrush.Outline = new(InnerItems.DefaultBrush.BaceValue.Outline);
                darkTheme.DefaultBrush.Line = new(InnerItems.DefaultBrush.BaceValue.Line);
                darkTheme.DefaultBrush.Highlight = new(InnerItems.DefaultBrush.BaceValue.Highlight);
                darkTheme.DefaultBrush.Selection = new(InnerItems.DefaultBrush.BaceValue.Selection);
                darkTheme.DefaultBrush.Mask = new(InnerItems.DefaultBrush.BaceValue.Mask);

                darkTheme.OverlayBoaderBackground.Disable = new(InnerItems.OverlayBoaderBackground.BaceValueDark.Disable);
                darkTheme.OverlayBoaderBackground.Default = new(InnerItems.OverlayBoaderBackground.BaceValueDark.Default);
                darkTheme.OverlayBoaderBackground.MouseOver = new(InnerItems.OverlayBoaderBackground.BaceValueDark.MouseOver);
                darkTheme.OverlayBoaderBackground.Active = new(InnerItems.OverlayBoaderBackground.BaceValueDark.Active);

                darkTheme.OverlayBoaderOutline.Disable = new(InnerItems.OverlayBoaderOutline.BaceValueDark.Disable);
                darkTheme.OverlayBoaderOutline.Default = new(InnerItems.OverlayBoaderOutline.BaceValueDark.Default);
                darkTheme.OverlayBoaderOutline.MouseOver = new(InnerItems.OverlayBoaderOutline.BaceValueDark.MouseOver);
                darkTheme.OverlayBoaderOutline.Active = new(InnerItems.OverlayBoaderOutline.BaceValueDark.Active);

                darkTheme.OverlayMaskForeground.Disable = new(InnerItems.OverlayMaskForeground.BaceValueDark.Disable);
                darkTheme.OverlayMaskForeground.Default = new(InnerItems.OverlayMaskForeground.BaceValueDark.Default);
                darkTheme.OverlayMaskForeground.MouseOver = new(InnerItems.OverlayMaskForeground.BaceValueDark.MouseOver);
                darkTheme.OverlayMaskForeground.Active = new(InnerItems.OverlayMaskForeground.BaceValueDark.Active);

                //darkTheme.ResetDefault();
            }
            else
                throw new Exception("no making theme [Dark].");
            #endregion
            CurrentThemeName = "Light";
            Save();
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

                    DefaultBrush_Foreground = new(getTheme.DefaultBrush.Foreground.Color);
                    DefaultBrush_Foreground_Disable = new(getTheme.DefaultBrush.Foreground_Disable.Color);
                    DefaultBrush_Background = new(getTheme.DefaultBrush.Background.Color);
                    DefaultBrush_Outline = new(getTheme.DefaultBrush.Outline.Color);
                    DefaultBrush_Line = new(getTheme.DefaultBrush.Line.Color);
                    DefaultBrush_Highlight = new(getTheme.DefaultBrush.Highlight.Color);
                    DefaultBrush_Selection = new(getTheme.DefaultBrush.Selection.Color);
                    DefaultBrush_Mask = new(getTheme.DefaultBrush.Mask.Color);

                    OverlayBoaderBackground_Disable = new(getTheme.OverlayBoaderBackground.Disable.Color);
                    OverlayBoaderBackground_Default = new(getTheme.OverlayBoaderBackground.Default.Color);
                    OverlayBoaderBackground_MouseOver = new(getTheme.OverlayBoaderBackground.MouseOver.Color);
                    OverlayBoaderBackground_Active = new(getTheme.OverlayBoaderBackground.Active.Color);

                    OverlayBoaderOutline_Disable = new(getTheme.OverlayBoaderOutline.Disable.Color);
                    OverlayBoaderOutline_Default = new(getTheme.OverlayBoaderOutline.Default.Color);
                    OverlayBoaderOutline_MouseOver = new(getTheme.OverlayBoaderOutline.MouseOver.Color);
                    OverlayBoaderOutline_Active = new(getTheme.OverlayBoaderOutline.Active.Color);

                    OverlayMaskForeground_Disable = new(getTheme.OverlayMaskForeground.Disable.Color);
                    OverlayMaskForeground_Default = new(getTheme.OverlayMaskForeground.Default.Color);
                    OverlayMaskForeground_MouseOver = new(getTheme.OverlayMaskForeground.MouseOver.Color);
                    OverlayMaskForeground_Active = new(getTheme.OverlayMaskForeground.Active.Color);
                    OnPropertyChanged(nameof(ThemeSettingDataManager.CurrentThemeName));

                    var dictionaries = Application.Current.Resources.MergedDictionaries;

                    // 특정 타입의 리소스 사전 찾기 (ThemeSetting 타입)
                    var existingDictionary = dictionaries.OfType<ThemeSetting>().FirstOrDefault();

                    if (existingDictionary != null)
                    {
                        // 기존 ThemeSetting 리소스 사전을 새로운 것으로 교체
                        int index = dictionaries.IndexOf(existingDictionary);
                        dictionaries[index] = new ThemeSetting(); // 새로운 ThemeSetting 인스턴스를 추가
                    }
                    else
                    {
                        // 기존 ThemeSetting이 없다면 새로 추가
                        dictionaries.Add(new ThemeSetting());
                    }

                    Application.Current.Resources.MergedDictionaries.Add(new ThemeSetting());
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
        public static SolidColorBrush DefaultBrush_Foreground
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
        public static SolidColorBrush DefaultBrush_Foreground_Disable
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
        public static SolidColorBrush DefaultBrush_Background
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
        public static SolidColorBrush DefaultBrush_Outline
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
        public static SolidColorBrush DefaultBrush_Line
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
        public static SolidColorBrush DefaultBrush_Highlight
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
        public static SolidColorBrush DefaultBrush_Selection
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
        public static SolidColorBrush DefaultBrush_Mask
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
        public static SolidColorBrush OverlayBoaderBackground_Disable
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
        public static SolidColorBrush OverlayBoaderBackground_Default
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
        public static SolidColorBrush OverlayBoaderBackground_MouseOver
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
        public static SolidColorBrush OverlayBoaderBackground_Active
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
        public static SolidColorBrush OverlayBoaderOutline_Disable
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
        public static SolidColorBrush OverlayBoaderOutline_Default
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
        public static SolidColorBrush OverlayBoaderOutline_MouseOver
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
        public static SolidColorBrush OverlayBoaderOutline_Active
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
        public static SolidColorBrush OverlayMaskForeground_Disable
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
        public static SolidColorBrush OverlayMaskForeground_Default
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
        public static SolidColorBrush OverlayMaskForeground_MouseOver
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
        public static SolidColorBrush OverlayMaskForeground_Active
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
        private static SolidColorBrush _defaultBrush_Foreground = new(InnerItems.DefaultBrush.BaceValue.Foreground);
        private static SolidColorBrush _defaultBrush_Foreground_Disable = new(InnerItems.DefaultBrush.BaceValue.Foreground_Disable);
        private static SolidColorBrush _defaultBrush_Background = new(InnerItems.DefaultBrush.BaceValue.Background);
        private static SolidColorBrush _defaultBrush_Outline = new(InnerItems.DefaultBrush.BaceValue.Outline);
        private static SolidColorBrush _defaultBrush_Line = new(InnerItems.DefaultBrush.BaceValue.Line);
        private static SolidColorBrush _defaultBrush_Highlight = new(InnerItems.DefaultBrush.BaceValue.Highlight);
        private static SolidColorBrush _defaultBrush_Selection = new(InnerItems.DefaultBrush.BaceValue.Selection);
        private static SolidColorBrush _defaultBrush_Mask = new(InnerItems.DefaultBrush.BaceValue.Mask);
        //OverlayBoader.Background
        private static SolidColorBrush _overlayBoaderBackground_Disable = new(InnerItems.OverlayBoaderBackground.BaceValue.Disable);
        private static SolidColorBrush _overlayBoaderBackground_Default = new(InnerItems.OverlayBoaderBackground.BaceValue.Default);
        private static SolidColorBrush _overlayBoaderBackground_MouseOver = new(InnerItems.OverlayBoaderBackground.BaceValue.MouseOver);
        private static SolidColorBrush _overlayBoaderBackground_Active = new(InnerItems.OverlayBoaderBackground.BaceValue.Active);
        //OverlayBoader.Outline
        private static SolidColorBrush _overlayBoaderOutline_Disable = new(InnerItems.OverlayBoaderOutline.BaceValue.Disable);
        private static SolidColorBrush _overlayBoaderOutline_Default = new(InnerItems.OverlayBoaderOutline.BaceValue.Default);
        private static SolidColorBrush _overlayBoaderOutline_MouseOver = new(InnerItems.OverlayBoaderOutline.BaceValue.MouseOver);
        private static SolidColorBrush _overlayBoaderOutline_Active = new(InnerItems.OverlayBoaderOutline.BaceValue.Active);
        //OverlayMask.Foreground
        private static SolidColorBrush _overlayMaskForeground_Disable = new(InnerItems.OverlayMaskForeground.BaceValue.Disable);
        private static SolidColorBrush _overlayMaskForeground_Default = new(InnerItems.OverlayMaskForeground.BaceValue.Default);
        private static SolidColorBrush _overlayMaskForeground_MouseOver = new(InnerItems.OverlayMaskForeground.BaceValue.MouseOver);
        private static SolidColorBrush _overlayMaskForeground_Active = new(InnerItems.OverlayMaskForeground.BaceValue.Active);
        #endregion

    }
}
