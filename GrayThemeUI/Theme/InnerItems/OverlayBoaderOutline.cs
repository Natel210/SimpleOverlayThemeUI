﻿using System.Windows.Media;
using utility.ini;

namespace GrayThemeUI.Theme.InnerItems
{
    public class OverlayBoaderOutline : IThemeItem
    {
        internal static class BaceValue
        {
            public static string Section { get; } = "OverlayBoader.Outline";
            public static Color Disable { get; } = Color.FromArgb(37, 128, 128, 128);
            public static Color Default { get; } = Color.FromArgb(0, 0, 0, 0); // Color.FromArgb(80, 0, 0, 0)
            public static Color MouseOver { get; } = Color.FromArgb(208, 0, 0, 0);
            public static Color Active { get; } = Color.FromArgb(255, 0, 0, 0);
        }

        internal static class BaceValueDark
        {
            public static Color Disable { get; } = Color.FromArgb(37, 128, 128, 128);
            public static Color Default { get; } = Color.FromArgb(0, 0, 0, 0); // Color.FromArgb(51, 235, 235, 235)
            public static Color MouseOver { get; } = Color.FromArgb(128, 235, 235, 235);
            public static Color Active { get; } = Color.FromArgb(255, 235, 235, 235);
        }

        public IniItem<Color> Disable { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "Disable",
            Value = BaceValue.Disable,
            DefaultValue = BaceValue.Disable
        };

        public IniItem<Color> Default { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "Default",
            Value = BaceValue.Default,
            DefaultValue = BaceValue.Default
        };

        public IniItem<Color> MouseOver { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "MouseOver",
            Value = BaceValue.MouseOver,
            DefaultValue = BaceValue.MouseOver
        };

        public IniItem<Color> Active { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "Active",
            Value = BaceValue.Active,
            DefaultValue = BaceValue.Active
        };

        public bool SetValue_Form(IniFile? iniFile)
        {
            if (iniFile is null)
                return false;
            bool result = false;
            result |= !iniFile.SetValue(Disable);
            result |= !iniFile.SetValue(Default);
            result |= !iniFile.SetValue(MouseOver);
            result |= !iniFile.SetValue(Active);
            return !result;
        }

        public bool GetValue_Form(IniFile? iniFile)
        {
            if (iniFile is null)
                return false;
            Disable.DefaultValue = iniFile.GetValue(Disable) ?? Disable.DefaultValue;
            Default.DefaultValue = iniFile.GetValue(Default) ?? Default.DefaultValue;
            MouseOver.DefaultValue = iniFile.GetValue(MouseOver) ?? MouseOver.DefaultValue;
            Active.DefaultValue = iniFile.GetValue(Active) ?? Active.DefaultValue;
            ResetDefault();
            return true;
        }

        public void ResetDefault()
        {
            Disable.Value = Disable.DefaultValue;
            Default.Value = Default.DefaultValue;
            MouseOver.Value = MouseOver.DefaultValue;
            Active.Value = Active.DefaultValue;
        }

        public OverlayBoaderOutline() { }

        public OverlayBoaderOutline(OverlayBoaderOutline dest)
        {
            Disable = new(dest.Disable);
            Default = new(dest.Default);
            MouseOver = new(dest.MouseOver);
            Active = new(dest.Active);
        }
    }
}
