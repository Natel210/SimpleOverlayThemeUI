using SimpleFileIO.State.Ini;
using SimpleFileIO.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOverlayTheme.CurrentThemeGeneraterToXaml
{
    /// <summary>
    /// Provides logic to convert a theme INI file to a WPF-compatible ResourceDictionary (.xaml).
    /// </summary>
    static public class XamlConverter
    {
        // INI parser state to load theme properties
        static private readonly IINIState _iniState;

        /// <summary>
        /// Initializes the INI state with a dummy default path. Must be overridden via SetSourcePathProperty().
        /// </summary>
        static XamlConverter()
        {
            _iniState = SimpleFileIO.Manager.CreateIniState("", new() { RootDirectory = new DirectoryInfo("./"), FileName = "Current", Extension = "ini" }) ??
                throw new ArgumentNullException("Failed to initialize INI state from default.");
        }

        /// <summary>
        /// Configures the input INI file path used for theme conversion.
        /// </summary>
        /// <param name="pathProperty">Full path to the .ini theme file.</param>
        static public void SetSourcePathProperty(string pathProperty)
        {
            _iniState.PathProperty = new PathProperty
            {
                RootDirectory = new DirectoryInfo(Path.GetDirectoryName(pathProperty) ?? string.Empty),
                FileName = Path.GetFileNameWithoutExtension(pathProperty),
                Extension = Path.GetExtension(pathProperty).TrimStart('.')
            };
        }

        /// <summary>
        /// Converts the loaded INI data into a WPF XAML file.
        /// </summary>
        /// <param name="outputPath">Destination path to save the generated XAML.</param>
        /// <returns>True if data was loaded from INI, false if fallback/default was used.</returns>
        static public bool Execute(FileInfo outputPath)
        {
            var toHex = (byte a, byte r, byte g, byte b) => { return $"#{a:X2}{r:X2}{g:X2}{b:X2}"; };
            bool result = _iniState.Load();
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"<ResourceDictionary xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"");
            stringBuilder.AppendLine($"                    xmlns:System=\"clr-namespace:System;assembly=mscorlib\"");
            stringBuilder.AppendLine($"                    xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">");
            stringBuilder.AppendLine($"    <!-- ============================== -->");
            stringBuilder.AppendLine($"    <!-- | * Current Theme Dummy (Only Design View * -->");
            stringBuilder.AppendLine($"    <!-- ============================== -->");
            stringBuilder.AppendLine($"    <!-- Theme -->");
            stringBuilder.AppendLine($"    <System:String x:Key=\"SimpleOverlayTheme.CurrentThemeName\">{_iniState.GetValue("Common", "ThemeName", "Temp")}</System:String>");
            stringBuilder.AppendLine($"");
            stringBuilder.AppendLine($"    <!-- Font Sizes -->");
            stringBuilder.AppendLine($"    <System:Double x:Key=\"SimpleOverlayTheme.ThemeKey.FontSize.Header1\">{_iniState.GetValue("Common", "FontSize_Header1", "32")}</System:Double>");
            stringBuilder.AppendLine($"    <System:Double x:Key=\"SimpleOverlayTheme.ThemeKey.FontSize.Header2\">{_iniState.GetValue("Common", "FontSize_Header2", "24")}</System:Double>");
            stringBuilder.AppendLine($"    <System:Double x:Key=\"SimpleOverlayTheme.ThemeKey.FontSize.Header3\">{_iniState.GetValue("Common", "FontSize_Header3", "18.72")}</System:Double>");
            stringBuilder.AppendLine($"    <System:Double x:Key=\"SimpleOverlayTheme.ThemeKey.FontSize.Header4\">{_iniState.GetValue("Common", "FontSize_Header4", "16")}</System:Double>");
            stringBuilder.AppendLine($"    <System:Double x:Key=\"SimpleOverlayTheme.ThemeKey.FontSize.Header5\">{_iniState.GetValue("Common", "FontSize_Header5", "13.28")}</System:Double>");
            stringBuilder.AppendLine($"    <System:Double x:Key=\"SimpleOverlayTheme.ThemeKey.FontSize.Header6\">{_iniState.GetValue("Common", "FontSize_Header6", "10.72")}</System:Double>");
            stringBuilder.AppendLine($"    <System:Double x:Key=\"SimpleOverlayTheme.ThemeKey.FontSize.Default\">{_iniState.GetValue("Common", "FontSize_Default", "10")}</System:Double>");
            stringBuilder.AppendLine($"");
            stringBuilder.AppendLine($"    <!-- Thickness -->");
            stringBuilder.AppendLine($"    <Thickness x:Key=\"SimpleOverlayTheme.DefaultThickness.Default\">1</Thickness>");
            stringBuilder.AppendLine($"    <Thickness x:Key=\"SimpleOverlayTheme.DefaultThickness.Zero\">0</Thickness>");
            stringBuilder.AppendLine($"");
            stringBuilder.AppendLine($"    <!-- Default Brush -->");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.ColorPalette.Foreground\" Color=\"{_iniState.GetValue("Common", "ColorPalette_Foreground", toHex(255, 21, 21, 21))}\"/>");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.ColorPalette.Foreground_Disable\" Color=\"{_iniState.GetValue("Common", "ColorPalette_Foreground_Disable", toHex(160, 128, 128, 128))}\"/>");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.ColorPalette.Background\" Color=\"{_iniState.GetValue("Common", "ColorPalette_Background", toHex(255, 255, 255, 255))}\"/>");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.ColorPalette.Outline\" Color=\"{_iniState.GetValue("Common", "ColorPalette_Outline", toHex(128, 128, 128, 128))}\"/>");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.ColorPalette.Line\" Color=\"{_iniState.GetValue("Common", "ColorPalette_Line", toHex(255, 128, 128, 128))}\"/>");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.ColorPalette.Highlight\" Color=\"{_iniState.GetValue("Common", "ColorPalette_Highlight", toHex(180, 21, 21, 21))}\"/>");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.ColorPalette.Selection\" Color=\"{_iniState.GetValue("Common", "ColorPalette_Selection", toHex(255, 128, 128, 128))}\"/>");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.ColorPalette.Mask\" Color=\"{_iniState.GetValue("Common", "ColorPalette_Mask", toHex(160, 128, 128, 128))}\"/>");
            stringBuilder.AppendLine($"");
            stringBuilder.AppendLine($"    <!-- Overlay Boader Background -->");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.Overlay.Border.Background.Disable\" Color=\"{_iniState.GetValue("Overlay", "BorderBackground_Disable", toHex(5, 128, 128, 128))}\"/>");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.Overlay.Border.Background.Default\" Color=\"{_iniState.GetValue("Overlay", "BorderBackground_Default", toHex(16, 128, 128, 128))}\"/>");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.Overlay.Border.Background.MouseOver\" Color=\"{_iniState.GetValue("Overlay", "BorderBackground_MouseOver", toHex(37, 128, 128, 128))}\"/>");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.Overlay.Border.Background.Active\" Color=\"{_iniState.GetValue("Overlay", "BorderBackground_Active", toHex(64, 128, 128, 128))}\"/>");
            stringBuilder.AppendLine($"");
            stringBuilder.AppendLine($"    <!-- Overlay Boader Outline -->");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.Overlay.Border.Outline.Disable\" Color=\"{_iniState.GetValue("Overlay", "BorderOutline_Disable", toHex(37, 128, 128, 128))}\"/>");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.Overlay.Border.Outline.Default\" Color=\"{_iniState.GetValue("Overlay", "BorderOutline_Default", toHex(51, 21, 21, 21))}\"/>");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.Overlay.Border.Outline.MouseOver\" Color=\"{_iniState.GetValue("Overlay", "BorderOutline_MouseOver", toHex(128, 21, 21, 21))}\"/>");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.Overlay.Border.Outline.Active\" Color=\"{_iniState.GetValue("Overlay", "BorderOutline_Active", toHex(255, 21, 21, 21))}\"/>");
            stringBuilder.AppendLine($"");
            stringBuilder.AppendLine($"    <!-- Overlay Mask Foreground -->");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.Overlay.Mask.Foreground.Disable\" Color=\"{_iniState.GetValue("Overlay", "MaskForeground_Disable", toHex(37, 21, 21, 21))}\"/>");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.Overlay.Mask.Foreground.Default\" Color=\"{_iniState.GetValue("Overlay", "MaskForeground_Default", toHex(80, 21, 21, 21))}\"/>");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.OverlayMask.Foreground.MouseOver\" Color=\"{_iniState.GetValue("Overlay", "MaskForeground_MouseOver", toHex(160, 21, 21, 21))}\"/>");
            stringBuilder.AppendLine($"    <SolidColorBrush x:Key=\"SimpleOverlayTheme.ThemeKey.Overlay.Mask.Foreground.Active\" Color=\"{_iniState.GetValue("Overlay", "MaskForeground_Active", toHex(240, 21, 21, 21))}\"/>");
            stringBuilder.AppendLine($"");
            stringBuilder.AppendLine($"</ResourceDictionary>");

            File.WriteAllText(outputPath.FullName, stringBuilder.ToString());

            return result;
        }
    }
}
