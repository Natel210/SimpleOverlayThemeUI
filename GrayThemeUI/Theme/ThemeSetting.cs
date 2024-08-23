using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Utility.InI;

namespace GrayThemeUI.Theme
{
    public static partial class ThemeSettingData
    {
        private static readonly double _fontSizeHeader1_BaseValue = 32.0;
        private static readonly double _fontSizeHeader2_BaseValue = 24.0;
        private static readonly double _fontSizeHeader3_BaseValue = 18.72;
        private static readonly double _fontSizeHeader4_BaseValue = 16.0;
        private static readonly double _fontSizeHeader5_BaseValue = 13.28;
        private static readonly double _fontSizeHeader6_BaseValue = 10.72;
        private static readonly double _fontSizeDefault_BaseValue = 16.0;

        private static readonly double[] _borderThicknessDefault_BaseValue = [1.0, 1.0, 1.0, 1.0];
        private static readonly double[] _borderThicknessZero_BaseValue = [0.0, 0.0, 0.0, 0.0];

        private static readonly Color _lineColorBrush_Color_BaseValue
            = new(){ R = 128, G = 128, B = 128, A = 255 };
        private static readonly Color _highlightColorBrush_Color_BaseValue
            = new() { R = 255, G = 255, B = 255, A = 80 };
        private static readonly Color _selectionColorBrush_Color_BaseValue
            = new() { R = 128, G = 128, B = 128, A = 255 };
        private static readonly Color _maskColorBrush_Color_BaseValue
            = new() { R = 128, G = 128, B = 128, A = 160 };

        internal class ThemeBrushes
        {
            private static SolidColorBrush _emptyBrush = new ();
            internal Dictionary<string, SolidColorBrush> brushes = new() {
                {nameof(ThemeSettingData.ThemeForegroundBrush),_emptyBrush},
                {nameof(ThemeSettingData.ThemeForegroundDisableBrush),_emptyBrush},
                {nameof(ThemeSettingData.ThemeBackgroundBrush),_emptyBrush},
                {"Theme_Background_Default",_emptyBrush},
                {"Theme_Background_Default",_emptyBrush},
                {"Theme_Background_Default",_emptyBrush},
                {"Theme_Background_Default",_emptyBrush},
                {"Theme_Background_Default",_emptyBrush},
            };
        }

    }

    public static partial class ThemeSettingData
    {
#pragma warning disable CS8618
        static ThemeSettingData()
#pragma warning restore CS8618
        {
            if(iniFile.CheckFileExist() is false)
            {
                FontSizeHeader1 = _fontSizeHeader1_BaseValue;
                FontSizeHeader2 = _fontSizeHeader2_BaseValue;
                FontSizeHeader3 = _fontSizeHeader3_BaseValue;
                FontSizeHeader4 = _fontSizeHeader4_BaseValue;
                FontSizeHeader5 = _fontSizeHeader5_BaseValue;
                FontSizeHeader6 = _fontSizeHeader6_BaseValue;
                FontSizeDefault = _fontSizeDefault_BaseValue;

                BorderThicknessDefault = new(_borderThicknessDefault_BaseValue[0],
                    _borderThicknessDefault_BaseValue[1],
                    _borderThicknessDefault_BaseValue[2],
                    _borderThicknessDefault_BaseValue[3]);
                BorderThicknessZero = new(_borderThicknessZero_BaseValue[0],
                    _borderThicknessZero_BaseValue[1],
                    _borderThicknessZero_BaseValue[2],
                    _borderThicknessZero_BaseValue[3]);

                CommonLineBrush = new(_lineColorBrush_Color_BaseValue);
                CommonHighlightBrush = new(_highlightColorBrush_Color_BaseValue);
                CommonSelectionBrush = new(_selectionColorBrush_Color_BaseValue);
                CommonMaskBrush = new(_maskColorBrush_Color_BaseValue);



                SaveINI();
            }
            else
                LoadInI();


        }


        #region INI FILE

        
        private static readonly IniFile iniFile = new("../GrayThemeUI/ThemeSettingData.ini");
        public static void LoadInI()
        {
            Func<string, string, double, double> doubleParse = (section, key, defaultValue) => {
                var value = iniFile.GetValue(section, key, defaultValue.ToString());
                if (double.TryParse(value, out double parsingValue))
                    return parsingValue;
                return defaultValue;
            };
            FontSizeHeader1 = doubleParse("Common", "FontSize.Header1", _fontSizeHeader1_BaseValue);
            FontSizeHeader2 = doubleParse("Common", "FontSize.Header2", _fontSizeHeader2_BaseValue);
            FontSizeHeader3 = doubleParse("Common", "FontSize.Header3", _fontSizeHeader3_BaseValue);
            FontSizeHeader4 = doubleParse("Common", "FontSize.Header4", _fontSizeHeader4_BaseValue);
            FontSizeHeader5 = doubleParse("Common", "FontSize.Header5", _fontSizeHeader5_BaseValue);
            FontSizeHeader6 = doubleParse("Common", "FontSize.Header6", _fontSizeHeader6_BaseValue);
            FontSizeDefault = doubleParse("Common", "FontSize.Default", _fontSizeDefault_BaseValue);
            Func<string, string, double[], double[]> doubleArrayParse = (section, key, defaultValue) => {
                List<string> tempDefaultList = [];
                foreach (var item in defaultValue)
                    tempDefaultList.Add(item.ToString());
                var valueArray = iniFile.GetValueToStringList(section, key, [.. tempDefaultList]);
                if (valueArray is null)
                    return defaultValue;
                if (valueArray.Length is not 4)
                    return defaultValue;
                List<double> result = [];
                foreach (var item in valueArray)
                {
                    if (double.TryParse(item, out double parsingValue))
                        result.Add(parsingValue);
                    result = [.. defaultValue];
                    break;
                }
                return [.. defaultValue];
            };

            var tempBorderThicknessDefault =
                doubleArrayParse("Common", "BorderThickness.Default", _borderThicknessDefault_BaseValue);
            BorderThicknessDefault = new(tempBorderThicknessDefault[0],
                tempBorderThicknessDefault[1],
                tempBorderThicknessDefault[2],
                tempBorderThicknessDefault[3]);
            var tempBorderThicknessZreo =
                doubleArrayParse("Common", "BorderThickness.Zero", _borderThicknessZero_BaseValue);
            BorderThicknessDefault = new(tempBorderThicknessZreo[0],
                tempBorderThicknessZreo[1],
                tempBorderThicknessZreo[2],
                tempBorderThicknessZreo[3]);


        }

        public static void SaveINI()
        {
            iniFile.SetValue("Common", "FontSize.Header1", FontSizeHeader1.ToString());
            iniFile.SetValue("Common", "FontSize.Header2", FontSizeHeader2.ToString());
            iniFile.SetValue("Common", "FontSize.Header3", FontSizeHeader3.ToString());
            iniFile.SetValue("Common", "FontSize.Header4", FontSizeHeader4.ToString());
            iniFile.SetValue("Common", "FontSize.Header5", FontSizeHeader5.ToString());
            iniFile.SetValue("Common", "FontSize.Header6", FontSizeHeader6.ToString());
            iniFile.SetValue("Common", "FontSize.Default", FontSizeDefault.ToString());

            string[] tempBorderThicknessDefault = [
                BorderThicknessDefault.Left.ToString(),
                BorderThicknessDefault.Top.ToString(),
                BorderThicknessDefault.Right.ToString(),
                BorderThicknessDefault.Bottom.ToString()];
            iniFile.GetValueToStringList("Common", "BorderThickness.Default", tempBorderThicknessDefault);
            string[] tempBorderThicknessZero = [
                BorderThicknessDefault.Left.ToString(),
                BorderThicknessDefault.Top.ToString(),
                BorderThicknessDefault.Right.ToString(),
                BorderThicknessDefault.Bottom.ToString()];
            iniFile.GetValueToStringList("Common", "BorderThickness.Zero", tempBorderThicknessZero);

            foreach (var item in collection)
            {

            }




        }
        #endregion
        #region Theme
        internal static string CurrentTheme { get; private set; } = "";
        private static Dictionary<string, ThemeBrushes> _themeBrushs = new();
        public static void AddTheme(string addTheme)
        {
            ThemeBrushes themeBrushes = new();

            themeBrushes.brushes[nameof(ThemeSettingData.ThemeForegroundBrush)] = ThemeForegroundBrush;
            themeBrushes.brushes[nameof(ThemeSettingData.ThemeForegroundDisableBrush)] = ThemeForegroundDisableBrush;
            themeBrushes.brushes[nameof(ThemeSettingData.ThemeBackgroundBrush)] = ThemeBackgroundBrush;

            themeBrushes.brushes[nameof(ThemeSettingData.ThemeOverlayBackgroundDisableBrush)] =
                ThemeOverlayBackgroundDisableBrush;
            themeBrushes.brushes[nameof(ThemeSettingData.ThemeOverlayBackgroundDefaultBrush)] =
                ThemeOverlayBackgroundDefaultBrush;
            themeBrushes.brushes[nameof(ThemeSettingData.ThemeOverlayBackgroundMouseOverBrush)] =
                ThemeOverlayBackgroundMouseOverBrush;
            themeBrushes.brushes[nameof(ThemeSettingData.ThemeOverlayBackgroundFocusBrush)] =
                ThemeOverlayBackgroundFocusBrush;

            themeBrushes.brushes[nameof(ThemeSettingData.ThemeOverlayBackgroundDisableBrush)] =
                ThemeOverlayBackgroundDisableBrush;
            themeBrushes.brushes[nameof(ThemeSettingData.ThemeOverlayBackgroundDefaultBrush)] =
                ThemeOverlayBackgroundDefaultBrush;
            themeBrushes.brushes[nameof(ThemeSettingData.ThemeOverlayBackgroundMouseOverBrush)] =
                ThemeOverlayBackgroundMouseOverBrush;
            themeBrushes.brushes[nameof(ThemeSettingData.ThemeOverlayBackgroundFocusBrush)] =
                ThemeOverlayBackgroundFocusBrush;

        }

        public static void ChangedTheme(string changedTheme)
        {
            if (_themeBrushs.ContainsKey(changedTheme) is false)
                return;
            CurrentTheme = changedTheme;

            ThemeForegroundBrush = _themeBrushs[CurrentTheme].brushes[nameof(ThemeSettingData.ThemeForegroundBrush)];
            ThemeForegroundDisableBrush =
                _themeBrushs[CurrentTheme].brushes[nameof(ThemeSettingData.ThemeForegroundDisableBrush)];
            ThemeBackgroundBrush = _themeBrushs[CurrentTheme].brushes[nameof(ThemeSettingData.ThemeBackgroundBrush)];

            ThemeOverlayBackgroundDisableBrush = 
                _themeBrushs[CurrentTheme].brushes[nameof(ThemeSettingData.ThemeOverlayBackgroundDisableBrush)];
            ThemeOverlayBackgroundDefaultBrush =
                _themeBrushs[CurrentTheme].brushes[nameof(ThemeSettingData.ThemeOverlayBackgroundDefaultBrush)];
            ThemeOverlayBackgroundMouseOverBrush =
                _themeBrushs[CurrentTheme].brushes[nameof(ThemeSettingData.ThemeOverlayBackgroundMouseOverBrush)];
            ThemeOverlayBackgroundFocusBrush =
                _themeBrushs[CurrentTheme].brushes[nameof(ThemeSettingData.ThemeOverlayBackgroundFocusBrush)];

            ThemeOverlayBorderBrushDisableBrush =
                _themeBrushs[CurrentTheme].brushes[nameof(ThemeSettingData.ThemeOverlayBorderBrushDisableBrush)];
            ThemeOverlayBorderBrushDefaultBrush =
                _themeBrushs[CurrentTheme].brushes[nameof(ThemeSettingData.ThemeOverlayBorderBrushDefaultBrush)];
            ThemeOverlayBorderBrushMouseOverBrush =
                _themeBrushs[CurrentTheme].brushes[nameof(ThemeSettingData.ThemeOverlayBorderBrushMouseOverBrush)];
            ThemeOverlayBorderBrushFocusBrush =
                _themeBrushs[CurrentTheme].brushes[nameof(ThemeSettingData.ThemeOverlayBorderBrushFocusBrush)];
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
        private static double _fontSizeHeader1;
        public static double FontSizeHeader1
        {
            get => _fontSizeHeader1;
            set
            {
                if (_fontSizeHeader1 != value)
                {
                    _fontSizeHeader1 = value;
                    OnPropertyChanged(nameof(FontSizeHeader1));
                }
            }
        }
        private static double _fontSizeHeader2;
        public static double FontSizeHeader2
        {
            get => _fontSizeHeader2;
            set
            {
                if (_fontSizeHeader2 != value)
                {
                    _fontSizeHeader2 = value;
                    OnPropertyChanged(nameof(FontSizeHeader2));
                }
            }
        }
        private static double _fontSizeHeader3;
        public static double FontSizeHeader3
        {
            get => _fontSizeHeader3;
            set
            {
                if (_fontSizeHeader3 != value)
                {
                    _fontSizeHeader3 = value;
                    OnPropertyChanged(nameof(FontSizeHeader3));
                }
            }
        }
        private static double _fontSizeHeader4;
        public static double FontSizeHeader4
        {
            get => _fontSizeHeader4;
            set
            {
                if (_fontSizeHeader4 != value)
                {
                    _fontSizeHeader4 = value;
                    OnPropertyChanged(nameof(FontSizeHeader4));
                }
            }
        }
        private static double _fontSizeHeader5;
        public static double FontSizeHeader5
        {
            get => _fontSizeHeader5;
            set
            {
                if (_fontSizeHeader5 != value)
                {
                    _fontSizeHeader5 = value;
                    OnPropertyChanged(nameof(FontSizeHeader5));
                }
            }
        }
        private static double _fontSizeHeader6;
        public static double FontSizeHeader6
        {
            get => _fontSizeHeader6;
            set
            {
                if (_fontSizeHeader6 != value)
                {
                    _fontSizeHeader6 = value;
                    OnPropertyChanged(nameof(FontSizeHeader6));
                }
            }
        }
        private static double _fontSizeDefault;
        public static double FontSizeDefault
        {
            get => _fontSizeDefault;
            set
            {
                if (_fontSizeDefault != value)
                {
                    _fontSizeDefault = value;
                    OnPropertyChanged(nameof(FontSizeDefault));
                }
            }
        }
        #endregion
        #region Common.BorderThichness
        private static Thickness _borderThicknessDefault;
        public static Thickness BorderThicknessDefault
        {
            get => _borderThicknessDefault;
            set
            {
                if (_borderThicknessDefault != value)
                {
                    _borderThicknessDefault = value;
                    OnPropertyChanged(nameof(BorderThicknessDefault));
                }
            }
        }
        private static Thickness _borderThicknessZero;
        public static Thickness BorderThicknessZero
        {
            get => _borderThicknessZero;
            set
            {
                if (_borderThicknessZero != value)
                {
                    _borderThicknessZero = value;
                    OnPropertyChanged(nameof(BorderThicknessZero));
                }
            }
        }
        #endregion
        #region Common.Brush
        private static SolidColorBrush _lineBrush;
        public static SolidColorBrush CommonLineBrush
        {
            get => _lineBrush;
            set
            {
                if (_lineBrush != value)
                {
                    _lineBrush = value;
                    OnPropertyChanged(nameof(CommonLineBrush));
                }
            }
        }
        private static SolidColorBrush _highlightBrush;
        public static SolidColorBrush CommonHighlightBrush
        {
            get => _highlightBrush;
            set
            {
                if (_highlightBrush != value)
                {
                    _highlightBrush = value;
                    OnPropertyChanged(nameof(_highlightBrush));
                }
            }
        }
        private static SolidColorBrush _selectionBrush;
        public static SolidColorBrush CommonSelectionBrush
        {
            get => _selectionBrush;
            set
            {
                if (_selectionBrush != value)
                {
                    _selectionBrush = value;
                    OnPropertyChanged(nameof(CommonSelectionBrush));
                }
            }
        }
        private static SolidColorBrush _maskBrush;
        public static SolidColorBrush CommonMaskBrush
        {
            get => _maskBrush;
            set
            {
                if (_maskBrush != value)
                {
                    _maskBrush = value;
                    OnPropertyChanged(nameof(CommonMaskBrush));
                }
            }
        }
        #endregion
        #region Theme.Common.Brush
        private static SolidColorBrush _themeForegroundBrush;
        public static SolidColorBrush ThemeForegroundBrush
        {
            get => _themeForegroundBrush;
            set
            {
                if (_themeForegroundBrush != value)
                {
                    _themeForegroundBrush = value;
                    OnPropertyChanged(nameof(ThemeForegroundBrush));
                }
            }
        }
        private static SolidColorBrush _themeForegroundDisableBrush;
        public static SolidColorBrush ThemeForegroundDisableBrush
        {
            get => _themeForegroundDisableBrush;
            set
            {
                if (_themeForegroundDisableBrush != value)
                {
                    _themeForegroundDisableBrush = value;
                    OnPropertyChanged(nameof(ThemeForegroundDisableBrush));
                }
            }
        }
        private static SolidColorBrush _themeBackgroundBrush;
        public static SolidColorBrush ThemeBackgroundBrush
        {
            get => _themeBackgroundBrush;
            set
            {
                if (_themeBackgroundBrush != value)
                {
                    _themeBackgroundBrush = value;
                    OnPropertyChanged(nameof(ThemeBackgroundBrush));
                }
            }
        }
        #endregion
        #region Theme.Overlay.Background.Brush
        private static SolidColorBrush _themeOverlayBackgroundDisableBrush;
        public static SolidColorBrush ThemeOverlayBackgroundDisableBrush
        {
            get => _themeOverlayBackgroundDisableBrush;
            set
            {
                if (_themeOverlayBackgroundDisableBrush != value)
                {
                    _themeOverlayBackgroundDisableBrush = value;
                    OnPropertyChanged(nameof(ThemeOverlayBackgroundDisableBrush));
                }
            }
        }
        private static SolidColorBrush _themeOverlayBackgroundDefaultBrush;
        public static SolidColorBrush ThemeOverlayBackgroundDefaultBrush
        {
            get => _themeOverlayBackgroundDefaultBrush;
            set
            {
                if (_themeOverlayBackgroundDefaultBrush != value)
                {
                    _themeOverlayBackgroundDefaultBrush = value;
                    OnPropertyChanged(nameof(ThemeOverlayBackgroundDefaultBrush));
                }
            }
        }
        private static SolidColorBrush _themeOverlayBackgroundMouseOverBrush;
        public static SolidColorBrush ThemeOverlayBackgroundMouseOverBrush
        {
            get => _themeOverlayBackgroundMouseOverBrush;
            set
            {
                if (_themeOverlayBackgroundMouseOverBrush != value)
                {
                    _themeOverlayBackgroundMouseOverBrush = value;
                    OnPropertyChanged(nameof(ThemeOverlayBackgroundMouseOverBrush));
                }
            }
        }
        private static SolidColorBrush _themeOverlayBackgroundFocusBrush;
        public static SolidColorBrush ThemeOverlayBackgroundFocusBrush
        {
            get => _themeOverlayBackgroundFocusBrush;
            set
            {
                if (_themeOverlayBackgroundFocusBrush != value)
                {
                    _themeOverlayBackgroundFocusBrush = value;
                    OnPropertyChanged(nameof(ThemeOverlayBackgroundFocusBrush));
                }
            }
        }
        #endregion
        #region Theme.Overlay.BorderBrush.Brush
        private static SolidColorBrush _themeOverlayBorderBrushDisableBrush;
        public static SolidColorBrush ThemeOverlayBorderBrushDisableBrush
        {
            get => _themeOverlayBorderBrushDisableBrush;
            set
            {
                if (_themeOverlayBorderBrushDisableBrush != value)
                {
                    _themeOverlayBorderBrushDisableBrush = value;
                    OnPropertyChanged(nameof(ThemeOverlayBorderBrushDisableBrush));
                }
            }
        }
        private static SolidColorBrush _themeOverlayBorderBrushDefaultBrush;
        public static SolidColorBrush ThemeOverlayBorderBrushDefaultBrush
        {
            get => _themeOverlayBorderBrushDefaultBrush;
            set
            {
                if (_themeOverlayBorderBrushDefaultBrush != value)
                {
                    _themeOverlayBorderBrushDefaultBrush = value;
                    OnPropertyChanged(nameof(ThemeOverlayBorderBrushDefaultBrush));
                }
            }
        }
        private static SolidColorBrush _themeOverlayBorderBrushMouseOverBrush;
        public static SolidColorBrush ThemeOverlayBorderBrushMouseOverBrush
        {
            get => _themeOverlayBorderBrushMouseOverBrush;
            set
            {
                if (_themeOverlayBorderBrushMouseOverBrush != value)
                {
                    _themeOverlayBorderBrushMouseOverBrush = value;
                    OnPropertyChanged(nameof(ThemeOverlayBorderBrushMouseOverBrush));
                }
            }
        }
        private static SolidColorBrush _themeOverlayBorderBrushFocusBrush;
        public static SolidColorBrush ThemeOverlayBorderBrushFocusBrush
        {
            get => _themeOverlayBorderBrushFocusBrush;
            set
            {
                if (_themeOverlayBorderBrushFocusBrush != value)
                {
                    _themeOverlayBorderBrushFocusBrush = value;
                    OnPropertyChanged(nameof(ThemeOverlayBorderBrushFocusBrush));
                }
            }
        }
        #endregion
        #region Theme.Overlay.Mask.Brush
        private static SolidColorBrush _themeOverlayMaskDisableBrush;
        public static SolidColorBrush ThemeOverlayMaskDisableBrush
        {
            get => _themeOverlayMaskDisableBrush;
            set
            {
                if (_themeOverlayMaskDisableBrush != value)
                {
                    _themeOverlayMaskDisableBrush = value;
                    OnPropertyChanged(nameof(ThemeOverlayMaskDisableBrush));
                }
            }
        }
        private static SolidColorBrush _themeOverlayMaskDefaultBrush;
        public static SolidColorBrush ThemeOverlayMaskDefaultBrush
        {
            get => _themeOverlayMaskDefaultBrush;
            set
            {
                if (_themeOverlayMaskDefaultBrush != value)
                {
                    _themeOverlayMaskDefaultBrush = value;
                    OnPropertyChanged(nameof(ThemeOverlayMaskDefaultBrush));
                }
            }
        }
        private static SolidColorBrush _themeOverlayMaskMouseOverBrush;
        public static SolidColorBrush ThemeOverlayMaskMouseOverBrush
        {
            get => _themeOverlayMaskMouseOverBrush;
            set
            {
                if (_themeOverlayMaskMouseOverBrush != value)
                {
                    _themeOverlayMaskMouseOverBrush = value;
                    OnPropertyChanged(nameof(ThemeOverlayMaskMouseOverBrush));
                }
            }
        }
        private static SolidColorBrush _themeOverlayMaskFocusBrush;
        public static SolidColorBrush ThemeOverlayMaskFocusBrush
        {
            get => _themeOverlayMaskFocusBrush;
            set
            {
                if (_themeOverlayMaskFocusBrush != value)
                {
                    _themeOverlayMaskFocusBrush = value;
                    OnPropertyChanged(nameof(ThemeOverlayMaskFocusBrush));
                }
            }
        }
        #endregion
    }


    public class ThemeSetting : ResourceDictionary
    {
        public ThemeSetting()
        {
            this["Internal.Common.FontSize.Header1"] = ThemeSettingData.FontSizeHeader1;
            this["Internal.Common.FontSize.Header2"] = ThemeSettingData.FontSizeHeader2;
            this["Internal.Common.FontSize.Header3"] = ThemeSettingData.FontSizeHeader3;
            this["Internal.Common.FontSize.Header4"] = ThemeSettingData.FontSizeHeader4;
            this["Internal.Common.FontSize.Header5"] = ThemeSettingData.FontSizeHeader5;
            this["Internal.Common.FontSize.Header6"] = ThemeSettingData.FontSizeHeader6;
            this["Internal.Common.FontSize.Default"] = ThemeSettingData.FontSizeDefault;

            this["Internal.Common.BorderThickness.Default"] = ThemeSettingData.BorderThicknessDefault;
            this["Internal.Common.BorderThickness.Zero"] = ThemeSettingData.BorderThicknessZero;

            this["Internal.Brush.Common.Line"] = ThemeSettingData.CommonLineBrush;
            this["Internal.Brush.Common.Highlight"] = ThemeSettingData.CommonHighlightBrush;
            this["Internal.Brush.Common.Selection"] = ThemeSettingData.CommonSelectionBrush;
            this["Internal.Brush.Common.Mask"] = ThemeSettingData.CommonMaskBrush;

            this["Internal.Brush.Theme.Foreground"] = ThemeSettingData.ThemeForegroundBrush;
            this["Internal.Brush.Theme.Foreground.Disable"] = ThemeSettingData.ThemeForegroundDisableBrush;
            this["Internal.Brush.Theme.Background"] = ThemeSettingData.ThemeBackgroundBrush;

            this["Internal.Brush.Theme.Overlay.Background.Disable"]
                = ThemeSettingData.ThemeOverlayBackgroundDisableBrush;
            this["Internal.Brush.Theme.Overlay.Background.Default"]
                = ThemeSettingData.ThemeOverlayBackgroundDefaultBrush;
            this["Internal.Brush.Theme.Overlay.Background.MouseOver"]
                = ThemeSettingData.ThemeOverlayBackgroundMouseOverBrush;
            this["Internal.Brush.Theme.Overlay.Background.Focus"]
                = ThemeSettingData.ThemeOverlayBackgroundFocusBrush;

            this["Internal.Brush.Theme.Overlay.BorderBrush.Disable"]
                = ThemeSettingData.ThemeOverlayBorderBrushDisableBrush;
            this["Internal.Brush.Theme.Overlay.BorderBrush.Default"]
                = ThemeSettingData.ThemeOverlayBorderBrushDefaultBrush;
            this["Internal.Brush.Theme.Overlay.BorderBrush.MouseOver"]
                = ThemeSettingData.ThemeOverlayBorderBrushMouseOverBrush;
            this["Internal.Brush.Theme.Overlay.BorderBrush.Focus"]
                = ThemeSettingData.ThemeOverlayBorderBrushFocusBrush;

            this["Internal.Brush.Theme.Overlay.Mask.Disable"] = ThemeSettingData.ThemeOverlayMaskDisableBrush;
            this["Internal.Brush.Theme.Overlay.Mask.Default"] = ThemeSettingData.ThemeOverlayMaskDefaultBrush;
            this["Internal.Brush.Theme.Overlay.Mask.MouseOver"] = ThemeSettingData.ThemeOverlayMaskMouseOverBrush;
            this["Internal.Brush.Theme.Overlay.Mask.Focus"] = ThemeSettingData.ThemeOverlayMaskFocusBrush;


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
