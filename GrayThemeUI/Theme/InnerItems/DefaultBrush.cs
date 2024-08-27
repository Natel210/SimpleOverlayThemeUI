using System.Windows.Media;
using utility.ini;

namespace GrayThemeUI.Theme.InnerItems
{
    public class DefaultBrush : IThemeItem
    {
        internal static class BaceValue
        {
            public static string Section { get; } = "DefaultBrush";
            public static Color Foreground { get; } = Color.FromArgb(255, 21, 21, 21);
            public static Color Foreground_Disable { get; } = Color.FromArgb(160, 128, 128, 128);
            public static Color Background { get; } = Color.FromArgb(255, 255, 255, 255);
            public static Color Line { get; } = Color.FromArgb(255, 128, 128, 128);
            public static Color Highlight { get; } = Color.FromArgb(80, 255, 255, 255);
            public static Color Selection { get; } = Color.FromArgb(255, 128, 128, 128);
            public static Color Mask { get; } = Color.FromArgb(160, 128, 128, 128);
        }

        internal static class BaceValueDark
        {
            public static Color Foreground { get; } = Color.FromArgb(255, 218, 218, 218);
            public static Color Foreground_Disable { get; } = Color.FromArgb(160, 128, 128, 128);
            public static Color Background { get; } = Color.FromArgb(255, 37, 37, 37);
        }

        public IniItem<Color> Foreground { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "Foreground",
            Value = BaceValue.Foreground,
            DefaultValue = BaceValue.Foreground
        };

        public IniItem<Color> Foreground_Disable { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "Foreground.Disable",
            Value = BaceValue.Foreground_Disable,
            DefaultValue = BaceValue.Foreground_Disable
        };

        public IniItem<Color> Background { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "Background",
            Value = BaceValue.Background,
            DefaultValue = BaceValue.Background
        };

        public IniItem<Color> Line { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "Line",
            Value = BaceValue.Line,
            DefaultValue = BaceValue.Line
        };

        public IniItem<Color> Highlight { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "Highlight",
            Value = BaceValue.Highlight,
            DefaultValue = BaceValue.Highlight
        };

        public IniItem<Color> Selection { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "Selection",
            Value = BaceValue.Selection,
            DefaultValue = BaceValue.Selection
        };

        public IniItem<Color> Mask { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "Mask",
            Value = BaceValue.Mask,
            DefaultValue = BaceValue.Mask
        };

        public bool SetValue_Form(IniFile? iniFile)
        {
            if (iniFile is null)
                return false;
            bool result = false;
            result |= !iniFile.SetValue(Foreground);
            result |= !iniFile.SetValue(Foreground_Disable);
            result |= !iniFile.SetValue(Background);
            result |= !iniFile.SetValue(Line);
            result |= !iniFile.SetValue(Highlight);
            result |= !iniFile.SetValue(Selection);
            result |= !iniFile.SetValue(Mask);
            return !result;
        }

        public bool GetValue_Form(IniFile? iniFile)
        {
            if (iniFile is null)
                return false;
            Foreground.DefaultValue = iniFile.GetValue(Foreground) ?? Foreground.DefaultValue;
            Foreground_Disable.DefaultValue = iniFile.GetValue(Foreground_Disable) ?? Foreground_Disable.DefaultValue;
            Background.DefaultValue = iniFile.GetValue(Background) ?? Background.DefaultValue;
            Line.DefaultValue = iniFile.GetValue(Line) ?? Line.DefaultValue;
            Highlight.DefaultValue = iniFile.GetValue(Highlight) ?? Highlight.DefaultValue;
            Selection.DefaultValue = iniFile.GetValue(Selection) ?? Selection.DefaultValue;
            Mask.DefaultValue = iniFile.GetValue(Mask) ?? Mask.DefaultValue;
            ResetDefault();
            return true;
        }

        public void ResetDefault()
        {
            Foreground.Value = Foreground.DefaultValue;
            Foreground_Disable.Value = Foreground_Disable.DefaultValue;
            Background.Value = Background.DefaultValue;
            Line.Value = Line.DefaultValue;
            Highlight.Value = Highlight.DefaultValue;
            Selection.Value = Selection.DefaultValue;
            Mask.Value = Mask.DefaultValue;
        }

        public DefaultBrush() { }

        public DefaultBrush(DefaultBrush dest)
        {
            Foreground = new(dest.Foreground);
            Foreground_Disable = new(dest.Foreground_Disable);
            Background = new(dest.Background);
            Line = new(dest.Line);
            Highlight = new(dest.Highlight);
            Selection = new(dest.Selection);
            Mask = new(dest.Mask);
        }
    }
}
