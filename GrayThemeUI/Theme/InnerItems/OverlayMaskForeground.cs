using System.Windows.Media;
using utility.ini;

namespace GrayThemeUI.Theme.InnerItems
{
    public class OverlayMaskForeground : IThemeItem
    {
        internal static class BaceValue
        {
            public static string Section { get; } = "OverlayMask.Foreground";
            public static Color Disable { get; } = Color.FromArgb(37, 128, 128, 128);
            public static Color Default { get; } = Color.FromArgb(0, 0, 0, 0); // Color.FromArgb(80, 15, 15, 15)
            public static Color MouseOver { get; } = Color.FromArgb(160, 21, 21, 21);
            public static Color Active { get; } = Color.FromArgb(240, 21, 21, 21);
        }

        internal static class BaceValueDark
        {
            public static Color Disable { get; } = Color.FromArgb(37, 128, 128, 128);
            public static Color Default { get; } = Color.FromArgb(0, 0, 0, 0); // Color.FromArgb(58, 128, 128, 128)
            public static Color MouseOver { get; } = Color.FromArgb(80, 235, 235, 235);
            public static Color Active { get; } = Color.FromArgb(160, 235, 235, 235);
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

        public bool SetValue_Form(IniFile? iniFile)
        {
            if (iniFile is null)
                return false;
            _disableItem.DefaultValue = _disableItem.Value;
            _defaultItem.DefaultValue = _defaultItem.Value;
            _mouseOverItem.DefaultValue = _mouseOverItem.Value;
            _activeItem.DefaultValue = _activeItem.Value;
            bool result = false;
            result |= !iniFile.SetValue(_disableItem);
            result |= !iniFile.SetValue(_defaultItem);
            result |= !iniFile.SetValue(_mouseOverItem);
            result |= !iniFile.SetValue(_activeItem);
            return !result;
        }

        public bool GetValue_Form(IniFile? iniFile)
        {
            if (iniFile is null)
                return false;
            _disableItem.DefaultValue = iniFile.GetValue(_disableItem);
            _defaultItem.DefaultValue = iniFile.GetValue(_defaultItem);
            _mouseOverItem.DefaultValue = iniFile.GetValue(_mouseOverItem);
            _activeItem.DefaultValue = iniFile.GetValue(_activeItem);
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

        public OverlayMaskForeground() { }

        public OverlayMaskForeground(OverlayMaskForeground dest)
        {
            Disable = new(dest.Disable.Color);
            Default = new(dest.Default.Color);
            MouseOver = new(dest.MouseOver.Color);
            Active = new(dest.Active.Color);
        }
    }
}