using System.IO;
using System.Text;
using System.Windows;
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

        public void MakeDummyXaml(DirectoryInfo superDirectoryInfo)
        {
            StringBuilder xamlBuilder = new StringBuilder();
            xamlBuilder.AppendLine("<ResourceDictionary xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"");
            xamlBuilder.AppendLine("                    xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"");
            xamlBuilder.AppendLine("                    xmlns:System=\"clr-namespace:System;assembly=mscorlib\">");
            xamlBuilder.AppendLine("");
            xamlBuilder.AppendLine("<!-- It is intended for use in WPF design mode. -->");
            xamlBuilder.AppendLine("<!-- Please make sure it does not load during actual use. -->");
            xamlBuilder.AppendLine("");
            xamlBuilder.AppendLine($"<!-- ============================== -->");
            xamlBuilder.AppendLine($"<!-- | * {Name} Theme * -->");
            xamlBuilder.AppendLine($"<!-- ============================== -->");
            xamlBuilder.AppendLine("");
            xamlBuilder.AppendLine("<!-- Theme -->");
            xamlBuilder.AppendLine($"<System:String x:Key=\"{CurrentThemeName_DictionaryKey}\">{Name}</System:String>");
            xamlBuilder.AppendLine("");
            xamlBuilder.AppendLine("<!-- Font Sizes -->");
            xamlBuilder.AppendLine($"<System:Double x:Key=\"{FontSize_Header1_DictionaryKey}\">{FontSize.Header1.Value}</System:Double>");
            xamlBuilder.AppendLine($"<System:Double x:Key=\"{FontSize_Header2_DictionaryKey}\">{FontSize.Header2.Value}</System:Double>");
            xamlBuilder.AppendLine($"<System:Double x:Key=\"{FontSize_Header3_DictionaryKey}\">{FontSize.Header3.Value}</System:Double>");
            xamlBuilder.AppendLine($"<System:Double x:Key=\"{FontSize_Header4_DictionaryKey}\">{FontSize.Header4.Value}</System:Double>");
            xamlBuilder.AppendLine($"<System:Double x:Key=\"{FontSize_Header5_DictionaryKey}\">{FontSize.Header5.Value}</System:Double>");
            xamlBuilder.AppendLine($"<System:Double x:Key=\"{FontSize_Header6_DictionaryKey}\">{FontSize.Header6.Value}</System:Double>");
            xamlBuilder.AppendLine($"<System:Double x:Key=\"{FontSize_Default_DictionaryKey}\">{FontSize.Default.Value}</System:Double>");
            xamlBuilder.AppendLine("");
            xamlBuilder.AppendLine("<!-- Thickness -->");
            xamlBuilder.AppendLine($"<Thickness x:Key=\"{Thickness_Default_DictionaryKey}\">1.0</Thickness>");
            xamlBuilder.AppendLine($"<Thickness x:Key=\"{Thickness_Zero_DictionaryKey}\">0.0</Thickness>");
            xamlBuilder.AppendLine("");
            xamlBuilder.AppendLine("<!-- Default Brush -->");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{DefaultBrush_Foreground_DictionaryKey}\" Color=\"{DefaultBrush.Foreground.Color.ToString()}\"/>");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{DefaultBrush_Foreground_Disable_DictionaryKey}\" Color=\"{DefaultBrush.Foreground_Disable.Color.ToString()}\"/>");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{DefaultBrush_Background_DictionaryKey}\" Color=\"{DefaultBrush.Background.Color.ToString()}\"/>");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{DefaultBrush_Outline_DictionaryKey}\" Color=\"{DefaultBrush.Outline.Color.ToString()}\"/>");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{DefaultBrush_Line_DictionaryKey}\" Color=\"{DefaultBrush.Line.Color.ToString()}\"/>");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{DefaultBrush_Highlight_DictionaryKey}\" Color=\"{DefaultBrush.Highlight.Color.ToString()}\"/>");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{DefaultBrush_Selection_DictionaryKey}\" Color=\"{DefaultBrush.Selection.Color.ToString()}\"/>");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{DefaultBrush_Mask_DictionaryKey}\" Color=\"{DefaultBrush.Mask.Color.ToString()}\"/>");
            xamlBuilder.AppendLine("");
            xamlBuilder.AppendLine("<!-- Overlay Boader Background -->");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{OverlayBoaderBackground_Disable_DictionaryKey}\" Color=\"{OverlayBoaderBackground.Disable.Color.ToString()}\"/>");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{OverlayBoaderBackground_Default_DictionaryKey}\" Color=\"{OverlayBoaderBackground.Default.Color.ToString()}\"/>");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{OverlayBoaderBackground_MouseOver_DictionaryKey}\" Color=\"{OverlayBoaderBackground.MouseOver.Color.ToString()}\"/>");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{OverlayBoaderBackground_Active_DictionaryKey}\" Color=\"{OverlayBoaderBackground.Active.Color.ToString()}\"/>");
            xamlBuilder.AppendLine("");
            xamlBuilder.AppendLine("<!-- Overlay Boader Outline -->");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{OverlayBoaderOutline_Disable_DictionaryKey}\" Color=\"{OverlayBoaderOutline.Disable.Color.ToString()}\"/>");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{OverlayBoaderOutline_Default_DictionaryKey}\" Color=\"{OverlayBoaderOutline.Default.Color.ToString()}\"/>");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{OverlayBoaderOutline_MouseOver_DictionaryKey}\" Color=\"{OverlayBoaderOutline.MouseOver.Color.ToString()}\"/>");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{OverlayBoaderOutline_Active_DictionaryKey}\" Color=\"{OverlayBoaderOutline.Active.Color.ToString()}\"/>");
            xamlBuilder.AppendLine("");
            xamlBuilder.AppendLine("<!-- Overlay Mask Foreground -->");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{OverlayMaskForeground_Disable_DictionaryKey}\" Color=\"{OverlayMaskForeground.Disable.Color.ToString()}\"/>");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{OverlayMaskForeground_Default_DictionaryKey}\" Color=\"{OverlayMaskForeground.Default.Color.ToString()}\"/>");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{OverlayMaskForeground_MouseOver_DictionaryKey}\" Color=\"{OverlayMaskForeground.MouseOver.Color.ToString()}\"/>");
            xamlBuilder.AppendLine($"<SolidColorBrush x:Key=\"{OverlayMaskForeground_Active_DictionaryKey}\" Color=\"{OverlayMaskForeground.Active.Color.ToString()}\"/>");
            xamlBuilder.AppendLine("");
            xamlBuilder.AppendLine("</ResourceDictionary>");
            if (superDirectoryInfo.Exists is false)
                superDirectoryInfo.Create();
            var getPath = Path.Combine(superDirectoryInfo.FullName, $"{Name}ModeDummy.xaml");
            File.WriteAllText(getPath, xamlBuilder.ToString());
        }
        #region Dictionary Key

        //Theme
        internal static string CurrentThemeName_DictionaryKey { get; } = $"GrayThemeUI.Internal.CurrentThemeName";

        //FontSize
        private static readonly string _fontSizeDictionaryKey = "GrayThemeUI.Internal.FontSize";
        internal static string FontSize_Header1_DictionaryKey { get; } = $"{_fontSizeDictionaryKey}.Header1";
        internal static string FontSize_Header2_DictionaryKey { get; } = $"{_fontSizeDictionaryKey}.Header2";
        internal static string FontSize_Header3_DictionaryKey { get; } = $"{_fontSizeDictionaryKey}.Header3";
        internal static string FontSize_Header4_DictionaryKey { get; } = $"{_fontSizeDictionaryKey}.Header4";
        internal static string FontSize_Header5_DictionaryKey { get; } = $"{_fontSizeDictionaryKey}.Header5";
        internal static string FontSize_Header6_DictionaryKey { get; } = $"{_fontSizeDictionaryKey}.Header6";
        internal static string FontSize_Default_DictionaryKey { get; } = $"{_fontSizeDictionaryKey}.Default";

        // Thickness
        internal static string Thickness_Default_DictionaryKey { get; } = $"GrayThemeUI.Internal.Thickness.Default";
        internal static string Thickness_Zero_DictionaryKey { get; } = $"GrayThemeUI.Internal.Thickness.Zero";

        //Default Brush
        private static readonly string _defaultBrushDictionaryKey = "GrayThemeUI.Internal.DefaultBrush";
        internal static string DefaultBrush_Foreground_DictionaryKey { get; } = $"{_defaultBrushDictionaryKey}.Foreground";
        internal static string DefaultBrush_Foreground_Disable_DictionaryKey { get; } = $"{_defaultBrushDictionaryKey}.Foreground.Disable";
        internal static string DefaultBrush_Background_DictionaryKey { get; } = $"{_defaultBrushDictionaryKey}.Background";
        internal static string DefaultBrush_Outline_DictionaryKey { get; } = $"{_defaultBrushDictionaryKey}.Outline";
        internal static string DefaultBrush_Line_DictionaryKey { get; } = $"{_defaultBrushDictionaryKey}.Line";
        internal static string DefaultBrush_Highlight_DictionaryKey { get; } = $"{_defaultBrushDictionaryKey}.Highlight";
        internal static string DefaultBrush_Selection_DictionaryKey { get; } = $"{_defaultBrushDictionaryKey}.Selection";
        internal static string DefaultBrush_Mask_DictionaryKey { get; } = $"{_defaultBrushDictionaryKey}.Mask";
        //Overlay Boader Background
        private static readonly string _overlayBoaderBackgroundDictionaryKey = "GrayThemeUI.Internal.OverlayBoader.Background";
        internal static string OverlayBoaderBackground_Disable_DictionaryKey { get; } = $"{_overlayBoaderBackgroundDictionaryKey}.Disable";
        internal static string OverlayBoaderBackground_Default_DictionaryKey { get; } = $"{_overlayBoaderBackgroundDictionaryKey}.Default";
        internal static string OverlayBoaderBackground_MouseOver_DictionaryKey { get; } = $"{_overlayBoaderBackgroundDictionaryKey}.MouseOver";
        internal static string OverlayBoaderBackground_Active_DictionaryKey { get; } = $"{_overlayBoaderBackgroundDictionaryKey}.Active";
        //Overlay Boader Outline
        private static readonly string _overlayBoaderOutlineDictionaryKey = "GrayThemeUI.Internal.OverlayBoader.Outline";
        internal static string OverlayBoaderOutline_Disable_DictionaryKey { get; } = $"{_overlayBoaderOutlineDictionaryKey}.Disable";
        internal static string OverlayBoaderOutline_Default_DictionaryKey { get; } = $"{_overlayBoaderOutlineDictionaryKey}.Default";
        internal static string OverlayBoaderOutline_MouseOver_DictionaryKey { get; } = $"{_overlayBoaderOutlineDictionaryKey}.MouseOver";
        internal static string OverlayBoaderOutline_Active_DictionaryKey { get; } = $"{_overlayBoaderOutlineDictionaryKey}.Active";
        //Overlay Mask Foreground
        private static readonly string _overlayMaskForegroundDictionaryKey = "GrayThemeUI.Internal.OverlayMask.Foreground";
        internal static string OverlayMaskForeground_Disable_DictionaryKey { get; } = $"{_overlayMaskForegroundDictionaryKey}.Disable";
        internal static string OverlayMaskForeground_Default_DictionaryKey { get; } = $"{_overlayMaskForegroundDictionaryKey}.Default";
        internal static string OverlayMaskForeground_MouseOver_DictionaryKey { get; } = $"{_overlayMaskForegroundDictionaryKey}.MouseOver";
        internal static string OverlayMaskForeground_Active_DictionaryKey { get; } = $"{_overlayMaskForegroundDictionaryKey}.Active";
        #endregion
    }


}
