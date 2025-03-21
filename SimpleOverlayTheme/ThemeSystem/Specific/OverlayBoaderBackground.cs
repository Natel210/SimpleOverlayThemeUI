﻿using SimpleFileIO.State.Ini;
using SimpleFileIO.Utility;
using SimpleOverlayTheme.ThemeSystem.Interface;
using System.Windows.Media;

namespace SimpleOverlayTheme.ThemeSystem.Specific
{
    public class OverlayBoaderBackground : IThemeItem
    {
        internal static class BaceValue
        {
            public static string Section { get; } = "OverlayBoader.Background";
            public static Color Disable { get; } = Color.FromArgb(5, 128, 128, 128);
            public static Color Default { get; } = Color.FromArgb(16, 128, 128, 128);
            public static Color MouseOver { get; } = Color.FromArgb(37, 128, 128, 128);
            public static Color Active { get; } = Color.FromArgb(64, 128, 128, 128);
        }

        internal static class BaceValueDark
        {
            public static Color Disable { get; } = Color.FromArgb(5, 128, 128, 128);
            public static Color Default { get; } = Color.FromArgb(16, 128, 128, 128);
            public static Color MouseOver { get; } = Color.FromArgb(37, 128, 128, 128);
            public static Color Active { get; } = Color.FromArgb(64, 128, 128, 128);
        }

        private IniItem<Color> _disableItem = new()
        {
            Section = BaceValue.Section,
            Key = "Disable",
            Value = BaceValue.Disable,
            DefaultValue = BaceValue.Disable
        };

        private SolidColorBrush _disable = new(BaceValue.Disable);
        public SolidColorBrush Disable
        {
            get => _disable;
            set
            {
                if (_disable != value)
                {
                    _disable = value;
                    _disableItem.Value = _disable.Color;
                }
            }
        }

        private IniItem<Color> _defaultItem = new()
        {
            Section = BaceValue.Section,
            Key = "Default",
            Value = BaceValue.Default,
            DefaultValue = BaceValue.Default
        };
        private SolidColorBrush _default = new(BaceValue.Default);
        public SolidColorBrush Default
        {
            get => _default;
            set
            {
                if (_default != value)
                {
                    _default = value;
                    _defaultItem.Value = _default.Color;
                }
            }
        }

        private IniItem<Color> _mouseOverItem = new()
        {
            Section = BaceValue.Section,
            Key = "MouseOver",
            Value = BaceValue.MouseOver,
            DefaultValue = BaceValue.MouseOver
        };
        private SolidColorBrush _mouseOver = new(BaceValue.MouseOver);
        public SolidColorBrush MouseOver
        {
            get => _mouseOver;
            set
            {
                if (_mouseOver != value)
                {
                    _mouseOver = value;
                    _mouseOverItem.Value = _mouseOver.Color;
                }
            }
        }

        public IniItem<Color> _activeItem = new()
        {
            Section = BaceValue.Section,
            Key = "Active",
            Value = BaceValue.Active,
            DefaultValue = BaceValue.Active
        };
        private SolidColorBrush _active = new(BaceValue.Active);
        public SolidColorBrush Active
        {
            get => _active;
            set
            {
                if (_active != value)
                {
                    _active = value;
                    _activeItem.Value = _active.Color;
                }
            }
        }

        public bool SetValue_Form(IINIState? iniFile)
        {
            if (iniFile is null)
                return false;
            _disableItem.DefaultValue = _disableItem.Value;
            _defaultItem.DefaultValue = _defaultItem.Value;
            _mouseOverItem.DefaultValue = _mouseOverItem.Value;
            _activeItem.DefaultValue = _activeItem.Value;
            bool result = false;
            result |= !iniFile.SetValue_UseParser(_disableItem);
            result |= !iniFile.SetValue_UseParser(_defaultItem);
            result |= !iniFile.SetValue_UseParser(_mouseOverItem);
            result |= !iniFile.SetValue_UseParser(_activeItem);
            return !result;
        }

        public bool GetValue_Form(IINIState? iniFile)
        {
            if (iniFile is null)
                return false;
            _disableItem.DefaultValue = iniFile.GetValue_UseParser(ref _disableItem);
            _defaultItem.DefaultValue = iniFile.GetValue_UseParser(ref _defaultItem);
            _mouseOverItem.DefaultValue = iniFile.GetValue_UseParser(ref _mouseOverItem);
            _activeItem.DefaultValue = iniFile.GetValue_UseParser(ref _activeItem);
            ResetDefault();
            return true;
        }

        public void ResetDefault()
        {
            Disable = new(_disableItem.DefaultValue);
            Default = new(_defaultItem.DefaultValue);
            MouseOver = new(_mouseOverItem.DefaultValue);
            Active = new(_activeItem.DefaultValue);
        }

        public OverlayBoaderBackground() { }

        public OverlayBoaderBackground(OverlayBoaderBackground dest)
        {
            Disable = new(dest.Disable.Color);
            Default = new(dest.Default.Color);
            MouseOver = new(dest.MouseOver.Color);
            Active = new(dest.Active.Color);
        }
    }
}
