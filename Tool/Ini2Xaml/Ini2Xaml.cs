using SimpleFileIO.State.Ini;
using SimpleFileIO.Utility;
using SimpleOverlayTheme.Share.StringTable;
using SimpleOverlayTheme.Share.StringTable.Item;
using System.Text;

namespace SimpleOverlayTheme.Ini2Xaml
{


    /// <summary>
    /// Provides logic to convert a theme INI file to a WPF-compatible ResourceDictionary (.xaml).
    /// </summary>
    static public class Ini2Xaml
    {
        // INI parser state to load theme properties
        static private readonly IINIState _iniState;

        /// <summary>
        /// Initializes the INI state with a dummy default path. Must be overridden via SetSourcePathProperty().
        /// </summary>
        static Ini2Xaml()
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
            _iniState.Load();

            var formatSection = (string section) => $"<!-- {section} -->";
            var formatString = (ThemePair themePair, string defaultValue) => $"<System:String x:Key=\"{themePair.Xaml}\">{_iniState.GetValue($"{themePair.Ini.Section}", $"{themePair.Ini.Key}", defaultValue)}</System:String>";
            var formatDouble = (ThemePair themePair, double defaultValue) => $"<System:Double x:Key=\"{themePair.Xaml}\">{_iniState.GetValue($"{themePair.Ini.Section}", $"{themePair.Ini.Key}", $"{defaultValue}")}</System:Double>";
            var formatTickness = (ThemePair themePair, string defaultValue) => $"<Thickness x:Key=\"{themePair.Xaml}\">{_iniState.GetValue($"{themePair.Ini.Section}", $"{themePair.Ini.Key}", $"{defaultValue}")}</Thickness>";

            var toHex = (string colorValue) => {
                string[] colorArray = colorValue.Split(',', StringSplitOptions.RemoveEmptyEntries);
                return colorArray.Length switch
                {
                    3 => $"#FF{byte.Parse(colorArray[0]):X2}{byte.Parse(colorArray[1]):X2}{byte.Parse(colorArray[2]):X2}",
                    4 => $"#{byte.Parse(colorArray[0]):X2}{byte.Parse(colorArray[1]):X2}{byte.Parse(colorArray[2]):X2}{byte.Parse(colorArray[3]):X2}",
                    _ => $"#00000000",
                };
            };
            var formatSolidColorBrush = (ThemePair themePair, string defaultValue) => $"<SolidColorBrush x:Key=\"{themePair.Xaml}\" Color=\"{toHex(_iniState.GetValue($"{themePair.Ini.Section}", $"{themePair.Ini.Key}", defaultValue))}\"/>";

            bool result = _iniState.Load();
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"<ResourceDictionary xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"");
            stringBuilder.AppendLine($"                    xmlns:System=\"clr-namespace:System;assembly=mscorlib\"");
            stringBuilder.AppendLine($"                    xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">");
            stringBuilder.AppendLine($"    <!-- ============================== -->");
            stringBuilder.AppendLine($"    <!-- | * Current Theme Dummy (Only Design View * -->");
            stringBuilder.AppendLine($"    <!-- ============================== -->");
            stringBuilder.AppendLine($"    {formatSection(ThemeKey.Common.ThemeName.Ini.Section)}");
            stringBuilder.AppendLine($"    {formatString(ThemeKey.Common.ThemeName, "Temp")}");
            stringBuilder.AppendLine($"");
            stringBuilder.AppendLine($"    {formatSection(ThemeKey.FontSize.Default.Ini.Section)}");
            stringBuilder.AppendLine($"    {formatDouble(ThemeKey.FontSize.Default, 10.00)}");
            stringBuilder.AppendLine($"    {formatDouble(ThemeKey.FontSize.Header1, 32.00)}");
            stringBuilder.AppendLine($"    {formatDouble(ThemeKey.FontSize.Header2, 24.00)}");
            stringBuilder.AppendLine($"    {formatDouble(ThemeKey.FontSize.Header3, 18.72)}");
            stringBuilder.AppendLine($"    {formatDouble(ThemeKey.FontSize.Header4, 16.00)}");
            stringBuilder.AppendLine($"    {formatDouble(ThemeKey.FontSize.Header5, 13.28)}");
            stringBuilder.AppendLine($"    {formatDouble(ThemeKey.FontSize.Header6, 10.72)}");
            stringBuilder.AppendLine($"");
            stringBuilder.AppendLine($"    {formatSection(ThemeKey.Thickness.Default.Ini.Section)}");
            stringBuilder.AppendLine($"    {formatTickness(ThemeKey.Thickness.Default, "1")}");
            stringBuilder.AppendLine($"");
            stringBuilder.AppendLine($"    {formatSection(ThemeKey.ColorPalette.Background.Ini.Section)}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.ColorPalette.Background, "255, 255, 255, 255")}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.ColorPalette.Foreground, "255, 21, 21, 21")}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.ColorPalette.Foreground_Disable, "160, 128, 128, 128")}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.ColorPalette.Highlight, "180, 21, 21, 21")}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.ColorPalette.Mask, "160, 128, 128, 128")}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.ColorPalette.Outline, "128, 128, 128, 128")}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.ColorPalette.Selection, "255, 128, 128, 128")}");
            stringBuilder.AppendLine($"");
            stringBuilder.AppendLine($"    {formatSection(ThemeKey.Overlay.Background.Active.Ini.Section)}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.Overlay.Background.Active, "5, 128, 128, 128")}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.Overlay.Background.Default, "16, 128, 128, 128")}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.Overlay.Background.Disable, "37, 128, 128, 128")}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.Overlay.Background.Mouseover, "64, 128, 128, 128")}");
            stringBuilder.AppendLine($"");
            stringBuilder.AppendLine($"    {formatSection(ThemeKey.Overlay.Outline.Active.Ini.Section)}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.Overlay.Outline.Active, "37, 128, 128, 128")}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.Overlay.Outline.Default, "51, 21, 21, 21")}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.Overlay.Outline.Disable, "128, 21, 21, 21")}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.Overlay.Outline.Mouseover, "255, 21, 21, 21")}");
            stringBuilder.AppendLine($"");
            stringBuilder.AppendLine($"    {formatSection(ThemeKey.Overlay.Mask.Background.Active.Ini.Section)}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.Overlay.Mask.Background.Active, "37, 21, 21, 21")}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.Overlay.Mask.Background.Default, "80, 21, 21, 21")}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.Overlay.Mask.Background.Disable, "160, 21, 21, 21")}");
            stringBuilder.AppendLine($"    {formatSolidColorBrush(ThemeKey.Overlay.Mask.Background.Mouseover, "240, 21, 21, 21")}");
            stringBuilder.AppendLine($"");
            stringBuilder.AppendLine($"</ResourceDictionary>");

            if (Directory.Exists(outputPath.DirectoryName) is false)
                Directory.CreateDirectory(outputPath.DirectoryName ?? string.Empty);
            File.WriteAllText(outputPath.FullName, stringBuilder.ToString());

            return result;
        }
    }
}
