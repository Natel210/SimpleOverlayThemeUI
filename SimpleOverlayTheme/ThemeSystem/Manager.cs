using SimpleFileIO.State.Ini;
using SimpleFileIO.Utility;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace SimpleOverlayTheme.ThemeSystem
{
    public static partial class Manager
    {
        private static readonly string _rootDictionary = $"./Propertes/{Assembly.GetExecutingAssembly().GetName().Name}/";
        private static readonly IINIState _iniFile;
        public static Dictionary<string, Data> DataDictionary { get; } = new Dictionary<string, Data>();

        public static void CreateThemeSettingData(string name, PathProperty properties)
        {
            Data tempData = new(name, properties);
            DataDictionary[name] = tempData;
            tempData.Save();
        }

        public static void CreateThemeSettingData_FromCurrentValue(string name, PathProperty properties)
        {
            Data tempData = new(name, properties);

            tempData.FontSize.Header1 = FontSize_Header1;
            tempData.FontSize.Header2 = FontSize_Header2;
            tempData.FontSize.Header3 = FontSize_Header3;
            tempData.FontSize.Header4 = FontSize_Header4;
            tempData.FontSize.Header5 = FontSize_Header5;
            tempData.FontSize.Header6 = FontSize_Header6;
            tempData.FontSize.Default = FontSize_Default;

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

        public static Data? GetThemeSettingData(string name)
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
            //MakeDefaultTheme();
            Application.Current.Resources.MergedDictionaries.Add(new UserResourceDictionary());
        }

        static Manager()
        {
            SimpleFileIO.Manager.CreateIniState("ThemeData",
                new()
                {
                    RootDirectory = new(_rootDictionary),
                    FileName = "ThemeData",
                    Extension = "ini"
                });
            _iniFile = SimpleFileIO.Manager.GetIniState("ThemeData") ?? throw new ArgumentNullException("Not Make ThemeData.ini");
        }


        public static bool Load()
        {
            if (_iniFile is null)
                return false;
            if (_iniFile.Load() is false)
            {
                MakeDefaultTheme();
                Save();
                if (_iniFile.Load() is false)
                    return false;
            }

            string currentThemeName = _iniFile.GetValue("Common", "CurrentThemeName", "Light");
            if (string.IsNullOrEmpty(currentThemeName) is true)
                return false;

            string[] themeNameList = _iniFile.GetValue_UseParser<string[]>("Common", "ThemeNameList", ["Light","Dark"]);
            if (themeNameList.Length is 0)
                return false;

            DataDictionary.Clear();
            foreach (var item in themeNameList)
            {
                string tempPath = _iniFile.GetValue(item, "Path", "");

                PathProperty pathProperty = new PathProperty();
                if (string.IsNullOrEmpty(tempPath) is false && File.Exists(tempPath) is false)
                    continue;
                pathProperty.RootDirectory = new(System.IO.Path.GetDirectoryName(tempPath) ?? string.Empty);
                pathProperty.FileName = System.IO.Path.GetFileNameWithoutExtension(tempPath);
                pathProperty.Extension = System.IO.Path.GetExtension(tempPath).TrimStart('.');
                DataDictionary[item] = new(item, pathProperty);
            }
            // after DataDictionary appending
            MakeDefaultTheme();

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
            if (string.IsNullOrEmpty(CurrentThemeName))
            {
                CurrentThemeName = "Light";
            }
            _iniFile.SetValue_UseParser("Common", "CurrentThemeName", CurrentThemeName);
            _iniFile.SetValue_UseParser("Common", "ThemeNameList", DataDictionary.Keys.ToArray());
            foreach (var item in DataDictionary)
                _iniFile.SetValue_UseParser(item.Key, "Path", $"{item.Value.IniPathProperty.RootDirectory}/{item.Value.IniPathProperty.FileName}.{item.Value.IniPathProperty.Extension}");
            _iniFile.Save();
            bool result = false;
            foreach (var item in DataDictionary)
            {
                result |= !item.Value.Save();
                item.Value.MakeDummyXaml(new DirectoryInfo(System.IO.Path.Combine(_iniFile.PathProperty.RootDirectory.FullName, "ThemeDummy")));
            }

            //Make Dummy Data
            return !result;
        }

        private static void MakeDefaultTheme()
        {
            bool isChange = false;
            #region Make Light Theme
            string lightName = "Light";
            if (DataDictionary.ContainsKey(lightName) is false)
            {
                CreateThemeSettingData(lightName, new() {
                    RootDirectory = new($"{_rootDictionary}/ThemeDataItem"),
                    FileName = lightName,
                    Extension = "data" });

                if (GetThemeSettingData(lightName) is Data lightTheme)
                {
                    lightTheme.FontSize.Header1 = Specific.FontSize.BaceValue.Header1;
                    lightTheme.FontSize.Header2 = Specific.FontSize.BaceValue.Header2;
                    lightTheme.FontSize.Header3 = Specific.FontSize.BaceValue.Header3;
                    lightTheme.FontSize.Header4 = Specific.FontSize.BaceValue.Header4;
                    lightTheme.FontSize.Header5 = Specific.FontSize.BaceValue.Header5;
                    lightTheme.FontSize.Header6 = Specific.FontSize.BaceValue.Header6;
                    lightTheme.FontSize.Default = Specific.FontSize.BaceValue.Default;

                    lightTheme.DefaultBrush.Foreground = new(Specific.DefaultBrush.BaceValue.Foreground);
                    lightTheme.DefaultBrush.Foreground_Disable = new(Specific.DefaultBrush.BaceValue.Foreground_Disable);
                    lightTheme.DefaultBrush.Background = new(Specific.DefaultBrush.BaceValue.Background);
                    lightTheme.DefaultBrush.Outline = new(Specific.DefaultBrush.BaceValue.Outline);
                    lightTheme.DefaultBrush.Line = new(Specific.DefaultBrush.BaceValue.Line);
                    lightTheme.DefaultBrush.Highlight = new(Specific.DefaultBrush.BaceValue.Highlight);
                    lightTheme.DefaultBrush.Selection = new(Specific.DefaultBrush.BaceValue.Selection);
                    lightTheme.DefaultBrush.Mask = new(Specific.DefaultBrush.BaceValue.Mask);

                    lightTheme.OverlayBoaderBackground.Disable = new(Specific.OverlayBoaderBackground.BaceValue.Disable);
                    lightTheme.OverlayBoaderBackground.Default = new(Specific.OverlayBoaderBackground.BaceValue.Default);
                    lightTheme.OverlayBoaderBackground.MouseOver = new(Specific.OverlayBoaderBackground.BaceValue.MouseOver);
                    lightTheme.OverlayBoaderBackground.Active = new(Specific.OverlayBoaderBackground.BaceValue.Active);

                    lightTheme.OverlayBoaderOutline.Disable = new(Specific.OverlayBoaderOutline.BaceValue.Disable);
                    lightTheme.OverlayBoaderOutline.Default = new(Specific.OverlayBoaderOutline.BaceValue.Default);
                    lightTheme.OverlayBoaderOutline.MouseOver = new(Specific.OverlayBoaderOutline.BaceValue.MouseOver);
                    lightTheme.OverlayBoaderOutline.Active = new(Specific.OverlayBoaderOutline.BaceValue.Active);

                    lightTheme.OverlayMaskForeground.Disable = new(Specific.OverlayMaskForeground.BaceValue.Disable);
                    lightTheme.OverlayMaskForeground.Default = new(Specific.OverlayMaskForeground.BaceValue.Default);
                    lightTheme.OverlayMaskForeground.MouseOver = new(Specific.OverlayMaskForeground.BaceValue.MouseOver);
                    lightTheme.OverlayMaskForeground.Active = new(Specific.OverlayMaskForeground.BaceValue.Active);
                    lightTheme.Save();
                    lightTheme.ResetDefault();
                    isChange = true;
                }
                else
                    throw new Exception($"no making theme [{lightName}].");
            }
            #endregion
            #region Make Dark Theme
            string darkName = "Dark";
            if (DataDictionary.ContainsKey(darkName) is false)
            {
                CreateThemeSettingData(darkName, new() {
                    RootDirectory = new($"{_rootDictionary}/ThemeDataItem"),
                    FileName = darkName,
                    Extension = "data"
                });
                if (GetThemeSettingData(darkName) is Data darkTheme)
                {
                    darkTheme.FontSize.Header1 = Specific.FontSize.BaceValue.Header1;
                    darkTheme.FontSize.Header2 = Specific.FontSize.BaceValue.Header2;
                    darkTheme.FontSize.Header3 = Specific.FontSize.BaceValue.Header3;
                    darkTheme.FontSize.Header4 = Specific.FontSize.BaceValue.Header4;
                    darkTheme.FontSize.Header5 = Specific.FontSize.BaceValue.Header5;
                    darkTheme.FontSize.Header6 = Specific.FontSize.BaceValue.Header6;
                    darkTheme.FontSize.Default = Specific.FontSize.BaceValue.Default;

                    darkTheme.DefaultBrush.Foreground = new(Specific.DefaultBrush.BaceValueDark.Foreground);
                    darkTheme.DefaultBrush.Foreground_Disable = new(Specific.DefaultBrush.BaceValueDark.Foreground_Disable);
                    darkTheme.DefaultBrush.Background = new(Specific.DefaultBrush.BaceValueDark.Background);
                    darkTheme.DefaultBrush.Outline = new(Specific.DefaultBrush.BaceValueDark.Outline);
                    darkTheme.DefaultBrush.Line = new(Specific.DefaultBrush.BaceValueDark.Line);
                    darkTheme.DefaultBrush.Highlight = new(Specific.DefaultBrush.BaceValueDark.Highlight);
                    darkTheme.DefaultBrush.Selection = new(Specific.DefaultBrush.BaceValueDark.Selection);
                    darkTheme.DefaultBrush.Mask = new(Specific.DefaultBrush.BaceValueDark.Mask);

                    darkTheme.OverlayBoaderBackground.Disable = new(Specific.OverlayBoaderBackground.BaceValueDark.Disable);
                    darkTheme.OverlayBoaderBackground.Default = new(Specific.OverlayBoaderBackground.BaceValueDark.Default);
                    darkTheme.OverlayBoaderBackground.MouseOver = new(Specific.OverlayBoaderBackground.BaceValueDark.MouseOver);
                    darkTheme.OverlayBoaderBackground.Active = new(Specific.OverlayBoaderBackground.BaceValueDark.Active);

                    darkTheme.OverlayBoaderOutline.Disable = new(Specific.OverlayBoaderOutline.BaceValueDark.Disable);
                    darkTheme.OverlayBoaderOutline.Default = new(Specific.OverlayBoaderOutline.BaceValueDark.Default);
                    darkTheme.OverlayBoaderOutline.MouseOver = new(Specific.OverlayBoaderOutline.BaceValueDark.MouseOver);
                    darkTheme.OverlayBoaderOutline.Active = new(Specific.OverlayBoaderOutline.BaceValueDark.Active);

                    darkTheme.OverlayMaskForeground.Disable = new(Specific.OverlayMaskForeground.BaceValueDark.Disable);
                    darkTheme.OverlayMaskForeground.Default = new(Specific.OverlayMaskForeground.BaceValueDark.Default);
                    darkTheme.OverlayMaskForeground.MouseOver = new(Specific.OverlayMaskForeground.BaceValueDark.MouseOver);
                    darkTheme.OverlayMaskForeground.Active = new(Specific.OverlayMaskForeground.BaceValueDark.Active);
                    darkTheme.Save();
                    darkTheme.ResetDefault();
                    isChange = true;
                }
                else
                    throw new Exception($"no making theme [{darkName}].");
            }


            #endregion


            if (isChange is true)
            {
                Save();
                _iniFile.Load();
            }
        }

    }

    public static partial class Manager
    {
        public static event PropertyChangedEventHandler? PropertyChanged;
        private static void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        #region Property
        //Theme

        /// <summary>
        /// If changed <see cref="CurrentThemeName"/> re-register <see cref="UserResourceDictionary"/>.
        /// </summary>
        public static string CurrentThemeName
        {
            get => _currentThemeName;
            set
            {
                if (_currentThemeName == value)
                    return;
                if (DataDictionary.ContainsKey(value) is false)
                    return;
                if (GetThemeSettingData(value) is Data getTheme)
                {
                    _currentThemeName = value;

                    FontSize_Header1 = getTheme.FontSize.Header1;
                    FontSize_Header2 = getTheme.FontSize.Header2;
                    FontSize_Header3 = getTheme.FontSize.Header3;
                    FontSize_Header4 = getTheme.FontSize.Header4;
                    FontSize_Header5 = getTheme.FontSize.Header5;
                    FontSize_Header6 = getTheme.FontSize.Header6;
                    FontSize_Default = getTheme.FontSize.Default;

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
                    OnPropertyChanged(nameof(Manager.CurrentThemeName));

                    var dictionaries = Application.Current.Resources.MergedDictionaries;

                    // 특정 타입의 리소스 사전 찾기 (ThemeSetting 타입)
                    var existingDictionary = dictionaries.OfType<UserResourceDictionary>().FirstOrDefault();

                    if (existingDictionary != null)
                    {
                        // 기존 ThemeSetting 리소스 사전을 새로운 것으로 교체
                        int index = dictionaries.IndexOf(existingDictionary);
                        dictionaries[index] = new UserResourceDictionary(); // 새로운 ThemeSetting 인스턴스를 추가
                    }
                    else
                    {
                        // 기존 ThemeSetting이 없다면 새로 추가
                        dictionaries.Add(new UserResourceDictionary());
                    }

                    //Application.Current.Resources.MergedDictionaries.Add(new UserResourceDictionary());
                    _iniFile.SetValue("Common", "CurrentThemeName", CurrentThemeName);
                    _iniFile.Save();
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
                    OnPropertyChanged(nameof(Manager.FontSize_Header1));
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
                    OnPropertyChanged(nameof(Manager.FontSize_Header2));
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
                    OnPropertyChanged(nameof(Manager.FontSize_Header3));
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
                    OnPropertyChanged(nameof(Manager.FontSize_Header4));
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
                    OnPropertyChanged(nameof(Manager.FontSize_Header5));
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
                    OnPropertyChanged(nameof(Manager.FontSize_Header6));
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
                    OnPropertyChanged(nameof(Manager.FontSize_Default));
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
                    OnPropertyChanged(nameof(Manager.DefaultBrush_Foreground));
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
                    OnPropertyChanged(nameof(Manager.DefaultBrush_Foreground_Disable));
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
                    OnPropertyChanged(nameof(Manager.DefaultBrush_Background));
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
                    OnPropertyChanged(nameof(Manager.DefaultBrush_Outline));
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
                    OnPropertyChanged(nameof(Manager.DefaultBrush_Line));
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
                    OnPropertyChanged(nameof(Manager.DefaultBrush_Highlight));
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
                    OnPropertyChanged(nameof(Manager.DefaultBrush_Selection));
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
                    OnPropertyChanged(nameof(Manager.DefaultBrush_Mask));
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
                    OnPropertyChanged(nameof(Manager.OverlayBoaderBackground_Disable));
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
                    OnPropertyChanged(nameof(Manager.OverlayBoaderBackground_Default));
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
                    OnPropertyChanged(nameof(Manager.OverlayBoaderBackground_MouseOver));
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
                    OnPropertyChanged(nameof(Manager.OverlayBoaderBackground_Active));
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
                    OnPropertyChanged(nameof(Manager.OverlayBoaderOutline_Disable));
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
                    OnPropertyChanged(nameof(Manager.OverlayBoaderOutline_Default));
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
                    OnPropertyChanged(nameof(Manager.OverlayBoaderOutline_MouseOver));
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
                    OnPropertyChanged(nameof(Manager.OverlayBoaderOutline_Active));
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
                    OnPropertyChanged(nameof(Manager.OverlayMaskForeground_Disable));
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
                    OnPropertyChanged(nameof(Manager.OverlayMaskForeground_Default));
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
                    OnPropertyChanged(nameof(Manager.OverlayMaskForeground_MouseOver));
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
                    OnPropertyChanged(nameof(Manager.OverlayMaskForeground_Active));
                }
            }
        }
        #endregion

        internal static string PropertyNameToThemeSystemKey(string items)
        {

            switch (items)
            {
                //Theme
                case nameof(CurrentThemeName):
                    return KeywordDictionary.ThemeSystemKey.CurrentThemeName;
                //FontSize
                case nameof(FontSize_Header1):
                    return KeywordDictionary.ThemeSystemKey.FontSize.Header1;
                case nameof(FontSize_Header2):
                    return KeywordDictionary.ThemeSystemKey.FontSize.Header2;
                case nameof(FontSize_Header3):
                    return KeywordDictionary.ThemeSystemKey.FontSize.Header3;
                case nameof(FontSize_Header4):
                    return KeywordDictionary.ThemeSystemKey.FontSize.Header4;
                case nameof(FontSize_Header5):
                    return KeywordDictionary.ThemeSystemKey.FontSize.Header5;
                case nameof(FontSize_Header6):
                    return KeywordDictionary.ThemeSystemKey.FontSize.Header6;
                case nameof(FontSize_Default):
                    return KeywordDictionary.ThemeSystemKey.FontSize.Default;
                //// Thickness
                //case nameof(Thickness_Default):
                //    return KeywordDictionary.ThemeSystemKey.DefaultThickness.Default;
                //case nameof(Thickness_Zero):
                //    return KeywordDictionary.ThemeSystemKey.DefaultThickness.Zero;
                // Default Brush
                case nameof(DefaultBrush_Foreground):
                    return KeywordDictionary.ThemeSystemKey.DefaultBrush.Foreground;
                case nameof(DefaultBrush_Foreground_Disable):
                    return KeywordDictionary.ThemeSystemKey.DefaultBrush.Foreground_Disable;
                case nameof(DefaultBrush_Background):
                    return KeywordDictionary.ThemeSystemKey.DefaultBrush.Background;
                case nameof(DefaultBrush_Outline):
                    return KeywordDictionary.ThemeSystemKey.DefaultBrush.Outline;
                case nameof(DefaultBrush_Line):
                    return KeywordDictionary.ThemeSystemKey.DefaultBrush.Line;
                case nameof(DefaultBrush_Highlight):
                    return KeywordDictionary.ThemeSystemKey.DefaultBrush.Highlight;
                case nameof(DefaultBrush_Selection):
                    return KeywordDictionary.ThemeSystemKey.DefaultBrush.Selection;
                case nameof(DefaultBrush_Mask):
                    return KeywordDictionary.ThemeSystemKey.DefaultBrush.Mask;
                // Overlay Boader Background
                case nameof(OverlayBoaderBackground_Disable):
                    return KeywordDictionary.ThemeSystemKey.OverlayBoader.Background.Disable;
                case nameof(OverlayBoaderBackground_Default):
                    return KeywordDictionary.ThemeSystemKey.OverlayBoader.Background.Default;
                case nameof(OverlayBoaderBackground_MouseOver):
                    return KeywordDictionary.ThemeSystemKey.OverlayBoader.Background.MouseOver;
                case nameof(OverlayBoaderBackground_Active):
                    return KeywordDictionary.ThemeSystemKey.OverlayBoader.Background.Active;
                // Overlay Boader Outline
                case nameof(OverlayBoaderOutline_Disable):
                    return KeywordDictionary.ThemeSystemKey.OverlayBoader.Outline.Disable;
                case nameof(OverlayBoaderOutline_Default):
                    return KeywordDictionary.ThemeSystemKey.OverlayBoader.Outline.Default;
                case nameof(OverlayBoaderOutline_MouseOver):
                    return KeywordDictionary.ThemeSystemKey.OverlayBoader.Outline.MouseOver;
                case nameof(OverlayBoaderOutline_Active):
                    return KeywordDictionary.ThemeSystemKey.OverlayBoader.Outline.Active;
                // Overlay Mask Foreground
                case nameof(OverlayMaskForeground_Disable):
                    return KeywordDictionary.ThemeSystemKey.OverlayMask.Foreground.Disable;
                case nameof(OverlayMaskForeground_Default):
                    return KeywordDictionary.ThemeSystemKey.OverlayMask.Foreground.Default;
                case nameof(OverlayMaskForeground_MouseOver):
                    return KeywordDictionary.ThemeSystemKey.OverlayMask.Foreground.MouseOver;
                case nameof(OverlayMaskForeground_Active):
                    return KeywordDictionary.ThemeSystemKey.OverlayMask.Foreground.Active;
                // Default
                default:
                    break;
            }

            return "";
        }

        #region Private Property Source
        //Theme
        private static string _currentThemeName = "";
        //FontSize
        private static double _fontSize_Header1 = Specific.FontSize.BaceValue.Header1;
        private static double _fontSize_Header2 = Specific.FontSize.BaceValue.Header2;
        private static double _fontSize_Header3 = Specific.FontSize.BaceValue.Header3;
        private static double _fontSize_Header4 = Specific.FontSize.BaceValue.Header4;
        private static double _fontSize_Header5 = Specific.FontSize.BaceValue.Header5;
        private static double _fontSize_Header6 = Specific.FontSize.BaceValue.Header6;
        private static double _fontSize_Default = Specific.FontSize.BaceValue.Default;
        //DefaultBrush
        private static SolidColorBrush _defaultBrush_Foreground = new(Specific.DefaultBrush.BaceValue.Foreground);
        private static SolidColorBrush _defaultBrush_Foreground_Disable = new(Specific.DefaultBrush.BaceValue.Foreground_Disable);
        private static SolidColorBrush _defaultBrush_Background = new(Specific.DefaultBrush.BaceValue.Background);
        private static SolidColorBrush _defaultBrush_Outline = new(Specific.DefaultBrush.BaceValue.Outline);
        private static SolidColorBrush _defaultBrush_Line = new(Specific.DefaultBrush.BaceValue.Line);
        private static SolidColorBrush _defaultBrush_Highlight = new(Specific.DefaultBrush.BaceValue.Highlight);
        private static SolidColorBrush _defaultBrush_Selection = new(Specific.DefaultBrush.BaceValue.Selection);
        private static SolidColorBrush _defaultBrush_Mask = new(Specific.DefaultBrush.BaceValue.Mask);
        //OverlayBoader.Background
        private static SolidColorBrush _overlayBoaderBackground_Disable = new(Specific.OverlayBoaderBackground.BaceValue.Disable);
        private static SolidColorBrush _overlayBoaderBackground_Default = new(Specific.OverlayBoaderBackground.BaceValue.Default);
        private static SolidColorBrush _overlayBoaderBackground_MouseOver = new(Specific.OverlayBoaderBackground.BaceValue.MouseOver);
        private static SolidColorBrush _overlayBoaderBackground_Active = new(Specific.OverlayBoaderBackground.BaceValue.Active);
        //OverlayBoader.Outline
        private static SolidColorBrush _overlayBoaderOutline_Disable = new(Specific.OverlayBoaderOutline.BaceValue.Disable);
        private static SolidColorBrush _overlayBoaderOutline_Default = new(Specific.OverlayBoaderOutline.BaceValue.Default);
        private static SolidColorBrush _overlayBoaderOutline_MouseOver = new(Specific.OverlayBoaderOutline.BaceValue.MouseOver);
        private static SolidColorBrush _overlayBoaderOutline_Active = new(Specific.OverlayBoaderOutline.BaceValue.Active);
        //OverlayMask.Foreground
        private static SolidColorBrush _overlayMaskForeground_Disable = new(Specific.OverlayMaskForeground.BaceValue.Disable);
        private static SolidColorBrush _overlayMaskForeground_Default = new(Specific.OverlayMaskForeground.BaceValue.Default);
        private static SolidColorBrush _overlayMaskForeground_MouseOver = new(Specific.OverlayMaskForeground.BaceValue.MouseOver);
        private static SolidColorBrush _overlayMaskForeground_Active = new(Specific.OverlayMaskForeground.BaceValue.Active);
        #endregion
    }
}
