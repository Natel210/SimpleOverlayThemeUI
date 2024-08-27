using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Utility.InI;
using System.Numerics;
using System.Windows.Media;
using System.Windows.Input;
using Microsoft.VisualBasic;

namespace GrayThemeUI.Theme
{

    public static partial class ThemeSettingData
    {
        public class ThemeItems
        {
            public ThemeItems(string name)
            {
                Name = name;
            }
            private string _name = "Temp";
            public string Name
            {
                get => _name;
                set
                {
                    _name = value;
                    SetEntry();
                }
            }

            public IniItem<Color> BrushForeground { get; } = new();
            public IniItem<Color> BrushForegroundDisable { get; } = new();
            public IniItem<Color> BrushBackground { get; } = new();

            public IniItem<Color> OverlayBackground_BrushDisable { get; } = new();
            public IniItem<Color> OverlayBackground_BrushDefault { get; } = new();
            public IniItem<Color> OverlayBackground_BrushMouseOver { get; } = new();
            public IniItem<Color> OverlayBackground_BrushFocus { get; } = new();

            public IniItem<Color> OverlayBorder_BrushDisable { get; } = new();
            public IniItem<Color> OverlayBorder_BrushDefault { get; } = new();
            public IniItem<Color> OverlayBorder_BrushMouseOver { get; } = new();
            public IniItem<Color> OverlayBorder_BrushFocus { get; } = new();

            public IniItem<Color> OverlayMask_BrushDisable { get; } = new();
            public IniItem<Color> OverlayMask_BrushDefault { get; } = new();
            public IniItem<Color> OverlayMask_BrushMouseOver { get; } = new();
            public IniItem<Color> OverlayMask_BrushFocus { get; } = new();

            private void SetEntry()
            {
                BrushForeground.Section = $"Theme.Items.{Name}";
                BrushForeground.Key = "Brush.Foreground";
                BrushForegroundDisable.Section = $"Theme.Items.{Name}";
                BrushForegroundDisable.Key = "Brush.Foreground.Disable";
                BrushBackground.Section = $"Theme.Items.{Name}";
                BrushBackground.Key = "Brush.Background";

                OverlayBackground_BrushDisable.Section = $"Theme.Items.{Name}.Overlay.Background";
                OverlayBackground_BrushDisable.Key = "Brush.Disable";
                OverlayBackground_BrushDefault.Section = $"Theme.Items.{Name}.Overlay.Background";
                OverlayBackground_BrushDefault.Key = "Brush.Default";
                OverlayBackground_BrushMouseOver.Section = $"Theme.Items.{Name}.Overlay.Background";
                OverlayBackground_BrushMouseOver.Key = "Brush.MouseOver";
                OverlayBackground_BrushFocus.Section = $"Theme.Items.{Name}.Overlay.Background";
                OverlayBackground_BrushFocus.Key = "Brush.Focus";

                OverlayBorder_BrushDisable.Section = $"Theme.Items.{Name}.Overlay.Border";
                OverlayBorder_BrushDisable.Key = "Brush.Disable";
                OverlayBorder_BrushDefault.Section = $"Theme.Items.{Name}.Overlay.Border";
                OverlayBorder_BrushDefault.Key = "Brush.Default";
                OverlayBorder_BrushMouseOver.Section = $"Theme.Items.{Name}.Overlay.Border";
                OverlayBorder_BrushMouseOver.Key = "Brush.MouseOver";
                OverlayBorder_BrushFocus.Section = $"Theme.Items.{Name}.Overlay.Border";
                OverlayBorder_BrushFocus.Key = "Brush.Focus";

                OverlayMask_BrushDisable.Section = $"Theme.Items.{Name}.Overlay.Mask";
                OverlayMask_BrushDisable.Key = "Brush.Disable";
                OverlayMask_BrushDefault.Section = $"Theme.Items.{Name}.Overlay.Mask";
                OverlayMask_BrushDefault.Key = "Brush.Default";
                OverlayMask_BrushMouseOver.Section = $"Theme.Items.{Name}.Overlay.Mask";
                OverlayMask_BrushMouseOver.Key = "Brush.MouseOver";
                OverlayMask_BrushFocus.Section = $"Theme.Items.{Name}.Overlay.Mask";
                OverlayMask_BrushFocus.Key = "Brush.Focus";
            }

            internal void LoadINI(IniFile iniFile)
            {
                if (iniFile is null)
                    return;
                SetEntry();

                Func<IniItem<Color>, Color> GetBrushValue = (item) => {
                    var tempColor = iniFile.GetValue(item);
                    if (tempColor is null)
                        return new Color();
                    if (tempColor.HasValue)
                        return new Color();
                    return tempColor.Value;
                };

                BrushForeground.Value = GetBrushValue(BrushForeground);
                BrushForegroundDisable.Value = GetBrushValue(BrushForegroundDisable);
                BrushBackground.Value = GetBrushValue(BrushBackground);

                OverlayBackground_BrushDisable.Value = GetBrushValue(OverlayBackground_BrushDisable);
                OverlayBackground_BrushDefault.Value = GetBrushValue(OverlayBackground_BrushDefault);
                OverlayBackground_BrushMouseOver.Value = GetBrushValue(OverlayBackground_BrushMouseOver);
                OverlayBackground_BrushFocus.Value = GetBrushValue(OverlayBackground_BrushFocus);

                OverlayBorder_BrushDisable.Value = GetBrushValue(OverlayBorder_BrushDisable);
                OverlayBorder_BrushDefault.Value = GetBrushValue(OverlayBorder_BrushDefault);
                OverlayBorder_BrushMouseOver.Value = GetBrushValue(OverlayBorder_BrushMouseOver);
                OverlayBorder_BrushFocus.Value = GetBrushValue(OverlayBorder_BrushFocus);

                OverlayMask_BrushDisable.Value = GetBrushValue(OverlayMask_BrushDisable);
                OverlayMask_BrushDefault.Value = GetBrushValue(OverlayMask_BrushDefault);
                OverlayMask_BrushMouseOver.Value = GetBrushValue(OverlayMask_BrushMouseOver);
                OverlayMask_BrushFocus.Value = GetBrushValue(OverlayMask_BrushFocus);
            }

            internal void SaveINI(IniFile iniFile)
            {
                if (iniFile is null)
                    return;
                SetEntry();

                iniFile.SetValue(BrushForeground);
                iniFile.SetValue(BrushForegroundDisable);
                iniFile.SetValue(BrushBackground);

                iniFile.SetValue(OverlayBackground_BrushDisable);
                iniFile.SetValue(OverlayBackground_BrushDefault);
                iniFile.SetValue(OverlayBackground_BrushMouseOver);
                iniFile.SetValue(OverlayBackground_BrushFocus);

                iniFile.SetValue(OverlayBorder_BrushDisable);
                iniFile.SetValue(OverlayBorder_BrushDefault);
                iniFile.SetValue(OverlayBorder_BrushMouseOver);
                iniFile.SetValue(OverlayBorder_BrushFocus);

                iniFile.SetValue(OverlayMask_BrushDisable);
                iniFile.SetValue(OverlayMask_BrushDefault);
                iniFile.SetValue(OverlayMask_BrushMouseOver);
                iniFile.SetValue(OverlayMask_BrushFocus);
            }
        }

    }

    public static partial class ThemeSettingData
    {
        private static readonly IniFile iniFile = new("../GrayThemeUI/ThemeSettingData.ini");
        static ThemeSettingData()
        {
            if (iniFile.CheckFileExist() is false)
            {
                SetDefaultValue();
                SaveINI();
            }
            else
                LoadInI();
        }
        #region INI FILE



        //private static readonly IniItem<double> _common_fontSizeHeader1 = new() { Section = "Common", Key = "FontSize.Header1" };

        private static void CreateIniItems()
        {

        }

        public static void LoadInI()
        {
            if (iniFile is null) { throw new Exception("ThemeSetting INI Failed."); }

            Common_FontSizeHeader1 = iniFile.GetValue(_common_fontSizeHeader1) ?? _common_fontSizeHeader1.DefaultValue;
            Common_FontSizeHeader2 = iniFile.GetValue(_common_FontSizeHeader2) ?? _common_FontSizeHeader2.DefaultValue;
            Common_FontSizeHeader3 = iniFile.GetValue(_common_FontSizeHeader3) ?? _common_FontSizeHeader3.DefaultValue;
            Common_FontSizeHeader4 = iniFile.GetValue(_common_FontSizeHeader4) ?? _common_FontSizeHeader4.DefaultValue;
            Common_FontSizeHeader5 = iniFile.GetValue(_common_FontSizeHeader5) ?? _common_FontSizeHeader5.DefaultValue;
            Common_FontSizeHeader6 = iniFile.GetValue(_common_FontSizeHeader6) ?? _common_FontSizeHeader6.DefaultValue;
            Common_FontSizeDefault = iniFile.GetValue(_common_FontSizeDefault) ?? _common_FontSizeDefault.DefaultValue;

            Common_ThicknessDefault = GetThickness(_common_ThicknessDefault);
            Common_ThicknessZero = GetThickness(_common_ThicknessZero);

            Common_BrushLine = GetSolidColorBrush(_common_BrushLine);
            Common_BrushHighlight = GetSolidColorBrush(_common_BrushHighlight);
            Common_BrushSelection = GetSolidColorBrush(_common_BrushSelection);
            Common_BrushMask = GetSolidColorBrush(_common_BrushMask);

            string[] strings = iniFile.GetValue("Theme", "ThemeList", []) ?? [];
            foreach (var item in strings)
            {
                ThemeItems temp = new(item);
                temp.LoadINI(iniFile);
                ThemeDictionary.Add(temp.Name, temp);
            }
            ThemeName = iniFile.GetValue(_themeName) ?? "Light";
        }

        public static void SaveINI()
        {
            if (iniFile is null) { throw new Exception("ThemeSetting INI Failed."); }

            iniFile.SetValue(_common_fontSizeHeader1);
            iniFile.SetValue(_common_FontSizeHeader2);
            iniFile.SetValue(_common_FontSizeHeader3);
            iniFile.SetValue(_common_FontSizeHeader4);
            iniFile.SetValue(_common_FontSizeHeader5);
            iniFile.SetValue(_common_FontSizeHeader6);
            iniFile.SetValue(_common_FontSizeDefault);

            iniFile.SetValue(_common_ThicknessDefault);
            iniFile.SetValue(_common_ThicknessZero);

            iniFile.SetValue(_common_BrushLine);
            iniFile.SetValue(_common_BrushHighlight);
            iniFile.SetValue(_common_BrushSelection);
            iniFile.SetValue(_common_BrushMask);

            foreach (var item in ThemeDictionary.Values)
                item.SaveINI(iniFile);
            iniFile.SetValue(_themeName);
        }
        #endregion

        #region PropertyChanged
        public static event PropertyChangedEventHandler? PropertyChanged;
        private static void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Common.FontSize
        private static IniItem<double> _common_fontSizeHeader1 = new()
        {
            Section = "Common",
            Key = "FontSize.Header1",
            Value = 32.0,
            DefaultValue = 32.0
        };
        public static double Common_FontSizeHeader1
        {
            get => _common_fontSizeHeader1.Value;
            set
            {
                if (_common_fontSizeHeader1.Value != value)
                {
                    _common_fontSizeHeader1.Value = value;
                    OnPropertyChanged(nameof(Common_FontSizeHeader1));
                }
            }
        }
        private static IniItem<double> _common_FontSizeHeader2 = new()
        {
            Section = "Common",
            Key = "FontSize.Header2",
            Value = 24.0,
            DefaultValue = 24.0
        };
        public static double Common_FontSizeHeader2
        {
            get => _common_FontSizeHeader2.Value;
            set
            {
                if (_common_FontSizeHeader2.Value != value)
                {
                    _common_FontSizeHeader2.Value = value;
                    OnPropertyChanged(nameof(Common_FontSizeHeader2));
                }
            }
        }
        private static IniItem<double> _common_FontSizeHeader3 = new()
        {
            Section = "Common",
            Key = "FontSize.Header3",
            Value = 18.72,
            DefaultValue = 18.72
        };
        public static double Common_FontSizeHeader3
        {
            get => _common_FontSizeHeader3.Value;
            set
            {
                if (_common_FontSizeHeader3.Value != value)
                {
                    _common_FontSizeHeader3.Value = value;
                    OnPropertyChanged(nameof(Common_FontSizeHeader3));
                }
            }
        }
        private static IniItem<double> _common_FontSizeHeader4 = new()
        {
            Section = "Common",
            Key = "FontSize.Header4",
            Value = 16.0,
            DefaultValue = 16.0
        };
        public static double Common_FontSizeHeader4
        {
            get => _common_FontSizeHeader4.Value;
            set
            {
                if (_common_FontSizeHeader4.Value != value)
                {
                    _common_FontSizeHeader4.Value = value;
                    OnPropertyChanged(nameof(Common_FontSizeHeader4));
                }
            }
        }
        private static IniItem<double> _common_FontSizeHeader5 = new()
        {
            Section = "Common",
            Key = "FontSize.Header5",
            Value = 13.28,
            DefaultValue = 13.28
        };
        public static double Common_FontSizeHeader5
        {
            get => _common_FontSizeHeader5.Value;
            set
            {
                if (_common_FontSizeHeader5.Value != value)
                {
                    _common_FontSizeHeader5.Value = value;
                    OnPropertyChanged(nameof(Common_FontSizeHeader5));
                }
            }
        }
        private static IniItem<double> _common_FontSizeHeader6 = new()
        {
            Section = "Common",
            Key = "FontSize.Header6",
            Value = 10.72,
            DefaultValue = 10.72
        };
        public static double Common_FontSizeHeader6
        {
            get => _common_FontSizeHeader6.Value;
            set
            {
                if (_common_FontSizeHeader6.Value != value)
                {
                    _common_FontSizeHeader6.Value = value;
                    OnPropertyChanged(nameof(Common_FontSizeHeader6));
                }
            }
        }
        private static IniItem<double> _common_FontSizeDefault = new()
        {
            Section = "Common",
            Key = "FontSize.Default",
            Value = 16.0,
            DefaultValue = 16.0
        };
        public static double Common_FontSizeDefault
        {
            get => _common_FontSizeDefault.Value;
            set
            {
                if (_common_FontSizeDefault.Value != value)
                {
                    _common_FontSizeDefault.Value = value;
                    OnPropertyChanged(nameof(Common_FontSizeDefault));
                }
            }
        }
        #endregion
        #region Common.BorderThichness
        private static IniItem<Vector4> _common_ThicknessDefault = new()
        {
            Section = "Common",
            Key = "Thickness.Default",
            Value = new Vector4(1.0f, 1.0f, 1.0f, 1.0f),
            DefaultValue = new Vector4(1.0f, 1.0f, 1.0f, 1.0f)
        };
        public static Thickness Common_ThicknessDefault
        {
            get => new Thickness()
            {
                Left = _common_ThicknessDefault.Value.X,
                Top = _common_ThicknessDefault.Value.Y,
                Right = _common_ThicknessDefault.Value.Z,
                Bottom = _common_ThicknessDefault.Value.W
            };
            set
            {
                Vector4 tempVector = new((float)value.Left, (float)value.Top, (float)value.Right, (float)value.Bottom);
                if (_common_ThicknessDefault.Value != tempVector)
                {
                    _common_ThicknessDefault.Value = tempVector;
                    OnPropertyChanged(nameof(Common_ThicknessDefault));
                }
            }
        }
        private static IniItem<Vector4> _common_ThicknessZero = new()
        {
            Section = "Common",
            Key = "Thickness.Zero",
            Value = new Vector4(0.0f, 0.0f, 0.0f, 0.0f),
            DefaultValue = new Vector4(0.0f, 0.0f, 0.0f, 0.0f)
        };
        public static Thickness Common_ThicknessZero
        {
            get => new Thickness()
            {
                Left = _common_ThicknessZero.Value.X,
                Top = _common_ThicknessZero.Value.Y,
                Right = _common_ThicknessZero.Value.Z,
                Bottom = _common_ThicknessZero.Value.W
            };
            set
            {
                Vector4 tempVector = new((float)value.Left, (float)value.Top, (float)value.Right, (float)value.Bottom);
                if (_common_ThicknessZero.Value != tempVector)
                {
                    _common_ThicknessZero.Value = tempVector;
                    OnPropertyChanged(nameof(Common_ThicknessZero));
                }
            }
        }
        #endregion
        #region Common.Brush
        private static IniItem<Color> _common_BrushLine = new()
        {
            Section = "Common",
            Key = "Brush.Line",
            Value = Color.FromArgb(255, 128, 128, 128),
            DefaultValue = Color.FromArgb(255, 128, 128, 128)
        };
        public static SolidColorBrush Common_BrushLine
        {
            get => new(_common_BrushLine.Value);
            set
            {
                if (_common_BrushLine.Value != value.Color)
                {
                    _common_BrushLine.Value = value.Color;
                    OnPropertyChanged(nameof(Common_BrushLine));
                }
            }
        }
        private static IniItem<Color> _common_BrushHighlight = new()
        {
            Section = "Common",
            Key = "Brush.Highlight",
            Value = Color.FromArgb(80, 255, 255, 255),
            DefaultValue = Color.FromArgb(80, 255, 255, 255)
        };
        public static SolidColorBrush Common_BrushHighlight
        {
            get => new(_common_BrushHighlight.Value);
            set
            {
                if (_common_BrushHighlight.Value != value.Color)
                {
                    _common_BrushHighlight.Value = value.Color;
                    OnPropertyChanged(nameof(_common_BrushHighlight));
                }
            }
        }
        private static IniItem<Color> _common_BrushSelection = new()
        {
            Section = "Common",
            Key = "Brush.Default",
            Value = Color.FromArgb(255, 128, 128, 128),
            DefaultValue = Color.FromArgb(255, 128, 128, 128)
        };
        public static SolidColorBrush Common_BrushSelection
        {
            get => new(_common_BrushSelection.Value);
            set
            {
                if (_common_BrushSelection.Value != value.Color)
                {
                    _common_BrushSelection.Value = value.Color;
                    OnPropertyChanged(nameof(Common_BrushSelection));
                }
            }
        }
        private static IniItem<Color> _common_BrushMask = new()
        {
            Section = "Common",
            Key = "Brush.Mask",
            Value = Color.FromArgb(160, 128, 128, 128),
            DefaultValue = Color.FromArgb(160, 128, 128, 128)
        };
        public static SolidColorBrush Common_BrushMask
        {
            get => new(_common_BrushMask.Value);
            set
            {
                if (_common_BrushMask.Value != value.Color)
                {
                    _common_BrushMask.Value = value.Color;
                    OnPropertyChanged(nameof(Common_BrushMask));
                }
            }
        }
        #endregion
        #region Theme.Common
        private static IniItem<string> _themeName = new()
        {
            Section = "Theme",
            Key = "Name",
            Value = "Light",
            DefaultValue = "Light"
        };
        public static string ThemeName
        {
            get => new(_themeName.Value);
            set
            {
                if (_themeName.Value == value)
                    return;
                if (ThemeDictionary.ContainsKey(value) is false)
                    return;
                _themeName.Value = value;
                OnPropertyChanged(nameof(Common_BrushMask));
                ChangedTheme();
            }
        }
        public static Dictionary<string, ThemeItems> ThemeDictionary { get; } = new();

        public static bool ChangedTheme()
        {
            if (ThemeDictionary.ContainsKey(ThemeName) is false)
                return false;

            Theme_BrushForeground = new(ThemeDictionary[ThemeName].BrushForeground.Value);
            Theme_BrushForegroundDisable = new(ThemeDictionary[ThemeName].BrushForegroundDisable.Value);
            Theme_BrushBackground = new(ThemeDictionary[ThemeName].BrushBackground.Value);

            ThemeOverlayBackground_BrushDisable = new(ThemeDictionary[ThemeName].OverlayBackground_BrushDisable.Value);
            ThemeOverlayBackground_BrushDefault = new(ThemeDictionary[ThemeName].OverlayBackground_BrushDefault.Value);
            ThemeOverlayBackground_BrushMouseOver = new(ThemeDictionary[ThemeName].OverlayBackground_BrushMouseOver.Value);
            ThemeOverlayBackground_BrushFocus = new(ThemeDictionary[ThemeName].OverlayBackground_BrushFocus.Value);

            ThemeOverlayBorder_BrushDisable = new(ThemeDictionary[ThemeName].OverlayBorder_BrushDisable.Value);
            ThemeOverlayBorder_BrushDefault = new(ThemeDictionary[ThemeName].OverlayBorder_BrushDefault.Value);
            ThemeOverlayBorder_BrushMouseOver = new(ThemeDictionary[ThemeName].OverlayBorder_BrushMouseOver.Value);
            ThemeOverlayBorder_BrushFocus = new(ThemeDictionary[ThemeName].OverlayBorder_BrushFocus.Value);

            ThemeOverlayMask_BrushDisable = new(ThemeDictionary[ThemeName].OverlayMask_BrushDisable.Value);
            ThemeOverlayMask_BrushDefault = new(ThemeDictionary[ThemeName].OverlayMask_BrushDefault.Value);
            ThemeOverlayMask_BrushMouseOver = new(ThemeDictionary[ThemeName].OverlayMask_BrushMouseOver.Value);
            ThemeOverlayMask_BrushFocus = new(ThemeDictionary[ThemeName].OverlayMask_BrushFocus.Value);

            return true;
        }
        #endregion
        #region Theme.Common.Brush
        private static IniItem<Color> _theme_BrushForeground = new()
        {
            Section = "Theme",
            Key = "Brush.Foreground",
            Value = Color.FromArgb(255, 21, 21, 21),
            DefaultValue = Color.FromArgb(255, 21, 21, 21)
        };
        public static SolidColorBrush Theme_BrushForeground
        {
            get => new(_theme_BrushForeground.Value);
            set
            {
                if (_theme_BrushForeground.Value != value.Color)
                {
                    _theme_BrushForeground.Value = value.Color;
                    OnPropertyChanged(nameof(Theme_BrushForeground));
                }
            }
        }
        private static IniItem<Color> _theme_BrushForegroundDisable = new()
        {
            Section = "Theme",
            Key = "Brush.Foreground.Disable",
            Value = Color.FromArgb(160, 128, 128, 128),
            DefaultValue = Color.FromArgb(160, 128, 128, 128)
        };
        public static SolidColorBrush Theme_BrushForegroundDisable
        {
            get => new(_theme_BrushForegroundDisable.Value);
            set
            {
                if (_theme_BrushForegroundDisable.Value != value.Color)
                {
                    _theme_BrushForegroundDisable.Value = value.Color;
                    OnPropertyChanged(nameof(Theme_BrushForegroundDisable));
                }
            }
        }
        private static IniItem<Color> _theme_BrushBackground = new()
        {
            Section = "Theme",
            Key = "Brush.Background",
            Value = Color.FromArgb(255, 255, 255, 255),
            DefaultValue = Color.FromArgb(255, 255, 255, 255)
        };
        public static SolidColorBrush Theme_BrushBackground
        {
            get => new(_theme_BrushBackground.Value);
            set
            {
                if (_theme_BrushBackground.Value != value.Color)
                {
                    _theme_BrushBackground.Value = value.Color;
                    OnPropertyChanged(nameof(Theme_BrushBackground));
                }
            }
        }
        #endregion
        #region Theme.Overlay.Background.Brush
        private static IniItem<Color> _themeOverlayBackground_BrushDisable = new()
        {
            Section = "Theme.Overlay.Background",
            Key = "Brush.Disable",
            Value = Color.FromArgb(5, 128, 128, 128),
            DefaultValue = Color.FromArgb(5, 128, 128, 128)
        };
        public static SolidColorBrush ThemeOverlayBackground_BrushDisable
        {
            get => new(_themeOverlayBackground_BrushDisable.Value);
            set
            {
                if (_themeOverlayBackground_BrushDisable.Value != value.Color)
                {
                    _themeOverlayBackground_BrushDisable.Value = value.Color;
                    OnPropertyChanged(nameof(ThemeOverlayBackground_BrushDisable));
                }
            }
        }
        private static IniItem<Color> _themeOverlayBackground_BrushDefault = new()
        {
            Section = "Theme.Overlay.Background",
            Key = "Brush.Default",
            Value = Color.FromArgb(16, 128, 128, 128),
            DefaultValue = Color.FromArgb(16, 128, 128, 128)
        };
        public static SolidColorBrush ThemeOverlayBackground_BrushDefault
        {
            get => new(_themeOverlayBackground_BrushDefault.Value);
            set
            {
                if (_themeOverlayBackground_BrushDefault.Value != value.Color)
                {
                    _themeOverlayBackground_BrushDefault.Value = value.Color;
                    OnPropertyChanged(nameof(ThemeOverlayBackground_BrushDefault));
                }
            }
        }
        private static IniItem<Color> _themeOverlayBackground_BrushMouseOver = new()
        {
            Section = "Theme.Overlay.Background",
            Key = "Brush.MouseOver",
            Value = Color.FromArgb(37, 128, 128, 128),
            DefaultValue = Color.FromArgb(37, 128, 128, 128)
        };
        public static SolidColorBrush ThemeOverlayBackground_BrushMouseOver
        {
            get => new(_themeOverlayBackground_BrushMouseOver.Value);
            set
            {
                if (_themeOverlayBackground_BrushMouseOver.Value != value.Color)
                {
                    _themeOverlayBackground_BrushMouseOver.Value = value.Color;
                    OnPropertyChanged(nameof(ThemeOverlayBackground_BrushMouseOver));
                }
            }
        }
        private static IniItem<Color> _themeOverlayBackground_BrushFocus = new()
        {
            Section = "Theme.Overlay.Background",
            Key = "Brush.Focus",
            Value = Color.FromArgb(64, 128, 128, 128),
            DefaultValue = Color.FromArgb(64, 128, 128, 128)

        };
        public static SolidColorBrush ThemeOverlayBackground_BrushFocus
        {
            get => new(_themeOverlayBackground_BrushFocus.Value);
            set
            {
                if (_themeOverlayBackground_BrushFocus.Value != value.Color)
                {
                    _themeOverlayBackground_BrushFocus.Value = value.Color;
                    OnPropertyChanged(nameof(ThemeOverlayBackground_BrushFocus));
                }
            }
        }
        #endregion
        #region Theme.Overlay.Border.Brush
        private static IniItem<Color> _themeOverlayBorder_BrushDisable = new()
        {
            Section = "Theme.Overlay.Border",
            Key = "Brush.Disable",
            Value = Color.FromArgb(37, 128, 128, 128),
            DefaultValue = Color.FromArgb(37, 128, 128, 128)
        };
        public static SolidColorBrush ThemeOverlayBorder_BrushDisable
        {
            get => new(_themeOverlayBorder_BrushDisable.Value);
            set
            {
                if (_themeOverlayBorder_BrushDisable.Value != value.Color)
                {
                    _themeOverlayBorder_BrushDisable.Value = value.Color;
                    OnPropertyChanged(nameof(ThemeOverlayBorder_BrushDisable));
                }
            }
        }
        private static IniItem<Color> _themeOverlayBorder_BrushDefault = new()
        {
            Section = "Theme.Overlay.Border",
            Key = "Brush.Default",
            Value = Color.FromArgb(80, 0, 0, 0),
            DefaultValue = Color.FromArgb(80, 0, 0, 0)
        };
        public static SolidColorBrush ThemeOverlayBorder_BrushDefault
        {
            get => new(_themeOverlayBorder_BrushDefault.Value);
            set
            {
                if (_themeOverlayBorder_BrushDefault.Value != value.Color)
                {
                    _themeOverlayBorder_BrushDefault.Value = value.Color;
                    OnPropertyChanged(nameof(ThemeOverlayBorder_BrushDefault));
                }
            }
        }
        private static IniItem<Color> _themeOverlayBorder_BrushMouseOver = new()
        {
            Section = "Theme.Overlay.Border",
            Key = "Brush.MouseOver",
            Value = Color.FromArgb(208, 0, 0, 0),
            DefaultValue = Color.FromArgb(208, 0, 0, 0)
        };
        public static SolidColorBrush ThemeOverlayBorder_BrushMouseOver
        {
            get => new(_themeOverlayBorder_BrushMouseOver.Value);
            set
            {
                if (_themeOverlayBorder_BrushMouseOver.Value != value.Color)
                {
                    _themeOverlayBorder_BrushMouseOver.Value = value.Color;
                    OnPropertyChanged(nameof(ThemeOverlayBorder_BrushMouseOver));
                }
            }
        }
        private static IniItem<Color> _themeOverlayBorder_BrushFocus = new()
        {
            Section = "Theme.Overlay.Border",
            Key = "Brush.Focus",
            Value = Color.FromArgb(255, 0, 0, 0),
            DefaultValue = Color.FromArgb(255, 0, 0, 0)
        };
        public static SolidColorBrush ThemeOverlayBorder_BrushFocus
        {
            get => new(_themeOverlayBorder_BrushFocus.Value);
            set
            {
                if (_themeOverlayBorder_BrushFocus.Value != value.Color)
                {
                    _themeOverlayBorder_BrushFocus.Value = value.Color;
                    OnPropertyChanged(nameof(ThemeOverlayBorder_BrushFocus));
                }
            }
        }
        #endregion
        #region Theme.Overlay.Mask.Brush
        private static IniItem<Color> _themeOverlayMask_BrushDisable = new()
        {
            Section = "Theme.Overlay.Mask",
            Key = "Brush.Disable",
            Value = Color.FromArgb(37, 128, 128, 128),
            DefaultValue = Color.FromArgb(37, 128, 128, 128)
        };
        public static SolidColorBrush ThemeOverlayMask_BrushDisable
        {
            get => new(_themeOverlayMask_BrushDisable.Value);
            set
            {
                if (_themeOverlayMask_BrushDisable.Value != value.Color)
                {
                    _themeOverlayMask_BrushDisable.Value = value.Color;
                    OnPropertyChanged(nameof(ThemeOverlayMask_BrushDisable));
                }
            }
        }
        private static IniItem<Color> _themeOverlayMask_BrushDefault = new()
        {
            Section = "Theme.Overlay.Mask",
            Key = "Brush.Default",
            //Color.FromArgb(80, 15, 15, 15),
            Value = Color.FromArgb(0, 0, 0, 0),
            DefaultValue = Color.FromArgb(0, 0, 0, 0)
        };
        public static SolidColorBrush ThemeOverlayMask_BrushDefault
        {
            get => new(_themeOverlayMask_BrushDefault.Value);
            set
            {
                if (_themeOverlayMask_BrushDefault.Value != value.Color)
                {
                    _themeOverlayMask_BrushDefault.Value = value.Color;
                    OnPropertyChanged(nameof(ThemeOverlayMask_BrushDefault));
                }
            }
        }
        private static IniItem<Color> _themeOverlayMask_BrushMouseOver = new()
        {
            Section = "Theme.Overlay.Mask",
            Key = "Brush.MouseOver",
            Value = Color.FromArgb(160, 21, 21, 21),
            DefaultValue = Color.FromArgb(160, 21, 21, 21)
        };
        public static SolidColorBrush ThemeOverlayMask_BrushMouseOver
        {
            get => new(_themeOverlayMask_BrushMouseOver.Value);
            set
            {
                if (_themeOverlayMask_BrushMouseOver.Value != value.Color)
                {
                    _themeOverlayMask_BrushMouseOver.Value = value.Color;
                    OnPropertyChanged(nameof(ThemeOverlayMask_BrushMouseOver));
                }
            }
        }
        private static IniItem<Color> _themeOverlayMask_BrushFocus = new()
        {
            Section = "Theme.Overlay.Mask",
            Key = "Brush.Focus",
            Value = Color.FromArgb(240, 21, 21, 21),
            DefaultValue = Color.FromArgb(240, 21, 21, 21)
        };
        public static SolidColorBrush ThemeOverlayMask_BrushFocus
        {
            get => new(_themeOverlayMask_BrushFocus.Value);
            set
            {
                if (_themeOverlayMask_BrushFocus.Value != value.Color)
                {
                    _themeOverlayMask_BrushFocus.Value = value.Color;
                    OnPropertyChanged(nameof(ThemeOverlayMask_BrushFocus));
                }
            }
        }
        #endregion
        #region Utility
        private static Thickness GetThickness(IniItem<Vector4> item)
        {
            Vector4? getValue = iniFile.GetValue(item) ?? item.DefaultValue;
            if (getValue is null)
                return new(1.0);
            return new(getValue.Value.X, getValue.Value.Y, getValue.Value.Z, getValue.Value.W);
        }
        private static Thickness GetDefaultThickness(IniItem<Vector4> item)
        {
            Vector4? getValue = item.DefaultValue;
            if (getValue is null)
                return new(1.0);
            return new(getValue.Value.X, getValue.Value.Y, getValue.Value.Z, getValue.Value.W);
        }
        private static SolidColorBrush GetSolidColorBrush(IniItem<Color> item)
        {
            Color? getValue = iniFile.GetValue(item) ?? item.DefaultValue;
            if (getValue is null)
                return new(Color.FromArgb(0, 0, 0, 0));
            return new(getValue.Value);
        }
        private static SolidColorBrush GetDefaultSolidColorBrush(IniItem<Color> item)
        {
            Color? getValue = item.DefaultValue;
            if (getValue is null)
                return new(Color.FromArgb(0, 0, 0, 0));
            return new(getValue.Value);
        }

        public static void SetDefaultCommon()
        {
            Common_FontSizeHeader1 = _common_fontSizeHeader1.DefaultValue;
            Common_FontSizeHeader2 = _common_FontSizeHeader2.DefaultValue;
            Common_FontSizeHeader3 = _common_FontSizeHeader3.DefaultValue;
            Common_FontSizeHeader4 = _common_FontSizeHeader4.DefaultValue;
            Common_FontSizeHeader5 = _common_FontSizeHeader5.DefaultValue;
            Common_FontSizeHeader6 = _common_FontSizeHeader6.DefaultValue;
            Common_FontSizeDefault = _common_FontSizeDefault.DefaultValue;

            Common_ThicknessDefault = GetDefaultThickness(_common_ThicknessDefault);
            Common_ThicknessZero = GetDefaultThickness(_common_ThicknessZero);
        }
        public static void SetDefaultThemeList()
        {

        }

        public static void SetDefaultThemeItem(string themeItem)
        {

        }

        public static void SetDefaultValue()
        {


            Common_BrushLine = GetDefaultSolidColorBrush(_common_BrushLine);
            Common_BrushHighlight = GetDefaultSolidColorBrush(_common_BrushHighlight);
            Common_BrushSelection = GetDefaultSolidColorBrush(_common_BrushSelection);
            Common_BrushMask = GetDefaultSolidColorBrush(_common_BrushMask);

            ThemeDictionary.Clear();
            ThemeItems tempLight = new("Light");
            //tempLight.BrushForeground.Value =;
            //tempLight.BrushForegroundDisable.Value =;
            //tempLight.BrushBackground.Value =;

            ThemeDictionary.Add(tempLight.Name, tempLight);
            ThemeItems tempDark = new("Dark");


            ThemeDictionary.Add(tempDark.Name, tempDark);

            ThemeName = _themeName.DefaultValue ?? "Light";
        }
        #endregion
    }



    public class ThemeSetting : ResourceDictionary
    {
        public ThemeSetting()
        {
            this["GrayThemeUI.Internal.Common.FontSize.Header1"] = ThemeSettingData.Common_FontSizeHeader1;
            this["GrayThemeUI.Internal.Common.FontSize.Header2"] = ThemeSettingData.Common_FontSizeHeader2;
            this["GrayThemeUI.Internal.Common.FontSize.Header3"] = ThemeSettingData.Common_FontSizeHeader3;
            this["GrayThemeUI.Internal.Common.FontSize.Header4"] = ThemeSettingData.Common_FontSizeHeader4;
            this["GrayThemeUI.Internal.Common.FontSize.Header5"] = ThemeSettingData.Common_FontSizeHeader5;
            this["GrayThemeUI.Internal.Common.FontSize.Header6"] = ThemeSettingData.Common_FontSizeHeader6;
            this["GrayThemeUI.Internal.Common.FontSize.Default"] = ThemeSettingData.Common_FontSizeDefault;

            this["GrayThemeUI.Internal.Common.Thickness.Default"] = ThemeSettingData.Common_ThicknessDefault;
            this["GrayThemeUI.Internal.Common.Thickness.Zero"] = ThemeSettingData.Common_ThicknessZero;

            this["GrayThemeUI.Internal.Common.Brush.Line"] = ThemeSettingData.Common_BrushLine;
            this["GrayThemeUI.Internal.Common.Brush.Highlight"] = ThemeSettingData.Common_BrushHighlight;
            this["GrayThemeUI.Internal.Common.Brush.Selection"] = ThemeSettingData.Common_BrushSelection;
            this["GrayThemeUI.Internal.Common.Brush.Mask"] = ThemeSettingData.Common_BrushMask;

            this["GrayThemeUI.Internal.Theme.Brush.Foreground"] = ThemeSettingData.Theme_BrushForeground;
            this["GrayThemeUI.Internal.Theme.Brush.Foreground.Disable"] = ThemeSettingData.Theme_BrushForegroundDisable;
            this["GrayThemeUI.Internal.Theme.Brush.Background"] = ThemeSettingData.Theme_BrushBackground;

            this["GrayThemeUI.Internal.Theme.Overlay.Background.Brush.Disable"] = ThemeSettingData.ThemeOverlayBackground_BrushDisable;
            this["GrayThemeUI.Internal.Theme.Overlay.Background.Brush.Default"] = ThemeSettingData.ThemeOverlayBackground_BrushDefault;
            this["GrayThemeUI.Internal.Theme.Overlay.Background.Brush.MouseOver"] = ThemeSettingData.ThemeOverlayBackground_BrushMouseOver;
            this["GrayThemeUI.Internal.Theme.Overlay.Background.Brush.Focus"] = ThemeSettingData.ThemeOverlayBackground_BrushFocus;

            this["GrayThemeUI.Internal.Theme.Overlay.Border.Brush.Disable"] = ThemeSettingData.ThemeOverlayBorder_BrushDisable;
            this["GrayThemeUI.Internal.Theme.Overlay.Border.Brush.Default"] = ThemeSettingData.ThemeOverlayBorder_BrushDefault;
            this["GrayThemeUI.Internal.Theme.Overlay.Border.Brush.MouseOver"] = ThemeSettingData.ThemeOverlayBorder_BrushMouseOver;
            this["GrayThemeUI.Internal.Theme.Overlay.Border.Brush.Focus"] = ThemeSettingData.ThemeOverlayBorder_BrushFocus;

            this["GrayThemeUI.Internal.Theme.Overlay.Mask.Brush.Disable"] = ThemeSettingData.ThemeOverlayMask_BrushDisable;
            this["GrayThemeUI.Internal.Theme.Overlay.Mask.Brush.Default"] = ThemeSettingData.ThemeOverlayMask_BrushDefault;
            this["GrayThemeUI.Internal.Theme.Overlay.Mask.Brush.MouseOver"] = ThemeSettingData.ThemeOverlayMask_BrushMouseOver;
            this["GrayThemeUI.Internal.Theme.Overlay.Mask.Brush.Focus"] = ThemeSettingData.ThemeOverlayMask_BrushFocus;

            ThemeSettingData.PropertyChanged += OnGlobalVariableChanged;
        }

        private void OnGlobalVariableChanged(object? sender, PropertyChangedEventArgs e)
        {
#pragma warning disable CS8604
            this[e.PropertyName] = typeof(ThemeSetting).GetProperty(e.PropertyName)?.GetValue(null);
#pragma warning restore CS8604
        }
    }
}
