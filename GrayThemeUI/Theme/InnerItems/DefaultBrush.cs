using System.Windows.Input;
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
            public static Color Outline { get; } = Color.FromArgb(255, 128, 128, 128);
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
            public static Color Outline { get; } = Color.FromArgb(255, 128, 128, 128);
        }

        private IniItem<Color> _foregroundItem = new()
        {
            Section = BaceValue.Section,
            Key = "Disable",
            Value = BaceValue.Foreground,
            DefaultValue = BaceValue.Foreground
        };
        private SolidColorBrush _foreground = new(BaceValue.Foreground);
        public SolidColorBrush Foreground
        {
            get => _foreground;
            set
            {
                if (_foreground != value)
                {
                    _foreground = value;
                    _foregroundItem.Value = _foreground.Color;
                }
            }
        }

        private IniItem<Color> _foreground_DisableItem = new()
        {
            Section = BaceValue.Section,
            Key = "Foreground.Disable",
            Value = BaceValue.Foreground_Disable,
            DefaultValue = BaceValue.Foreground_Disable
        };
        private SolidColorBrush _foreground_Disable = new(BaceValue.Foreground_Disable);
        public SolidColorBrush Foreground_Disable
        {
            get => _foreground_Disable;
            set
            {
                if (_foreground_Disable != value)
                {
                    _foreground_Disable = value;
                    _foreground_DisableItem.Value = _foreground_Disable.Color;
                }
            }
        }

        private IniItem<Color> _backgroundItem = new()
        {
            Section = BaceValue.Section,
            Key = "Background",
            Value = BaceValue.Background,
            DefaultValue = BaceValue.Background
        };
        private SolidColorBrush _background = new(BaceValue.Background);
        public SolidColorBrush Background
        {
            get => _background;
            set
            {
                if (_background != value)
                {
                    _background = value;
                    _backgroundItem.Value = _background.Color;
                }
            }
        }

        private IniItem<Color> _outlineItem = new()
        {
            Section = BaceValue.Section,
            Key = "Outline",
            Value = BaceValue.Outline,
            DefaultValue = BaceValue.Outline
        };
        private SolidColorBrush _outline = new(BaceValue.Outline);
        public SolidColorBrush Outline
        {
            get => _outline;
            set
            {
                if (_outline != value)
                {
                    _outline = value;
                    _outlineItem.Value = _outline.Color;
                }
            }
        }

        private IniItem<Color> _lineItem = new()
        {
            Section = BaceValue.Section,
            Key = "Line",
            Value = BaceValue.Line,
            DefaultValue = BaceValue.Line
        };
        private SolidColorBrush _line = new(BaceValue.Line);
        public SolidColorBrush Line
        {
            get => _line;
            set
            {
                if (_line != value)
                {
                    _line = value;
                    _lineItem.Value = _line.Color;
                }
            }
        }

        private IniItem<Color> _highlightItem = new()
        {
            Section = BaceValue.Section,
            Key = "Highlight",
            Value = BaceValue.Highlight,
            DefaultValue = BaceValue.Highlight
        };
        private SolidColorBrush _highlight = new(BaceValue.Highlight);
        public SolidColorBrush Highlight
        {
            get => _highlight;
            set
            {
                if (_highlight != value)
                {
                    _highlight = value;
                    _highlightItem.Value = _highlight.Color;
                }
            }
        }

        private IniItem<Color> _selectionItem = new()
        {
            Section = BaceValue.Section,
            Key = "Selection",
            Value = BaceValue.Selection,
            DefaultValue = BaceValue.Selection
        };
        private SolidColorBrush _selection = new(BaceValue.Selection);
        public SolidColorBrush Selection
        {
            get => _selection;
            set
            {
                if (_selection != value)
                {
                    _selection = value;
                    _selectionItem.Value = _selection.Color;
                }
            }
        }

        private IniItem<Color> _maskItem = new()
        {
            Section = BaceValue.Section,
            Key = "Mask",
            Value = BaceValue.Mask,
            DefaultValue = BaceValue.Mask
        };
        private SolidColorBrush _mask = new(BaceValue.Mask);
        public SolidColorBrush Mask
        {
            get => _mask;
            set
            {
                if (_mask != value)
                {
                    _mask = value;
                    _maskItem.Value = _mask.Color;
                }
            }
        }

        public bool SetValue_Form(IniFile? iniFile)
        {
            if (iniFile is null)
                return false;
            _foregroundItem.DefaultValue = _foregroundItem.Value;
            _foreground_DisableItem.DefaultValue = _foreground_DisableItem.Value;
            _backgroundItem.DefaultValue = _backgroundItem.Value;
            _lineItem.DefaultValue = _lineItem.Value;
            _lineItem.DefaultValue = _lineItem.Value;
            _highlightItem.DefaultValue = _highlightItem.Value;
            _selectionItem.DefaultValue = _selectionItem.Value;
            _maskItem.DefaultValue = _maskItem.Value;
            bool result = false;
            result |= !iniFile.SetValue(_foregroundItem);
            result |= !iniFile.SetValue(_foreground_DisableItem);
            result |= !iniFile.SetValue(_backgroundItem);
            result |= !iniFile.SetValue(_outlineItem);
            result |= !iniFile.SetValue(_lineItem);
            result |= !iniFile.SetValue(_highlightItem);
            result |= !iniFile.SetValue(_selectionItem);
            result |= !iniFile.SetValue(_maskItem);
            return !result;
        }

        public bool GetValue_Form(IniFile? iniFile)
        {
            if (iniFile is null)
                return false;
            _foregroundItem.DefaultValue = iniFile.GetValue(_foregroundItem);
            _foreground_DisableItem.DefaultValue = iniFile.GetValue(_foreground_DisableItem);
            _backgroundItem.DefaultValue = iniFile.GetValue(_backgroundItem);
            _lineItem.DefaultValue = iniFile.GetValue(_outlineItem);
            _lineItem.DefaultValue = iniFile.GetValue(_lineItem);
            _highlightItem.DefaultValue = iniFile.GetValue(_highlightItem);
            _selectionItem.DefaultValue = iniFile.GetValue(_selectionItem);
            _maskItem.DefaultValue = iniFile.GetValue(_maskItem);
            ResetDefault();
            return true;
        }

        public void ResetDefault()
        {
            Foreground = new(_foregroundItem.DefaultValue);
            Foreground_Disable = new(_foreground_DisableItem.DefaultValue);
            Background = new(_backgroundItem.DefaultValue);
            Outline = new(_outlineItem.DefaultValue);
            Line = new(_lineItem.DefaultValue);
            Highlight = new(_highlightItem.DefaultValue);
            Selection = new(_selectionItem.DefaultValue);
            Mask = new(_maskItem.DefaultValue);
        }

        public DefaultBrush() { }

        public DefaultBrush(DefaultBrush dest)
        {
            Foreground = new(dest.Foreground.Color);
            Foreground_Disable = new(dest.Foreground_Disable.Color);
            Background = new(dest.Background.Color);
            Outline = new(dest.Outline.Color);
            Line = new(dest.Line.Color);
            Highlight = new(dest.Highlight.Color);
            Selection = new(dest.Selection.Color);
            Mask = new(dest.Mask.Color);
        }
    }
}
