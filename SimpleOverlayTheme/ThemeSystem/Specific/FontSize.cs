using SimpleFileIO.State.Ini;
using SimpleFileIO.Utility;
using SimpleOverlayTheme.ThemeSystem.Interface;

namespace SimpleOverlayTheme.ThemeSystem.Specific
{
    public class FontSize : IThemeItem
    {
        internal static class BaceValue
        {
            public static string Section { get; } = "FontSize";
            public static double Header1 { get; } = 32.0;
            public static double Header2 { get; } = 24.0;
            public static double Header3 { get; } = 18.72;
            public static double Header4 { get; } = 16.0;
            public static double Header5 { get; } = 13.28;
            public static double Header6 { get; } = 10.72;
            public static double Default { get; } = 16.0;

        }

        private IniItem<double> _header1 = new()
        {
            Section = BaceValue.Section,
            Key = "Header1",
            DefaultValue = BaceValue.Header1,
            Value = BaceValue.Header1,
        };

        public double Header1
        {
            get => _header1.Value;
            set 
            {
                if (_header1.Value != value)
                    _header1.Value = value;
            }
        }

        private IniItem<double> _header2 = new()
        {
            Section = BaceValue.Section,
            Key = "Header2",
            DefaultValue = BaceValue.Header2,
            Value = BaceValue.Header2,
        };

        public double Header2
        {
            get => _header2.Value;
            set
            {
                if (_header2.Value != value)
                    _header2.Value = value;
            }
        }

        private IniItem<double> _header3 = new()
        {
            Section = BaceValue.Section,
            Key = "Header3",
            DefaultValue = BaceValue.Header3,
            Value = BaceValue.Header3,
        };

        public double Header3
        {
            get => _header3.Value;
            set
            {
                if (_header3.Value != value)
                    _header3.Value = value;
            }
        }

        private IniItem<double> _header4 = new()
        {
            Section = BaceValue.Section,
            Key = "Header4",
            DefaultValue = BaceValue.Header4,
            Value = BaceValue.Header4,
        };

        public double Header4
        {
            get => _header4.Value;
            set
            {
                if (_header4.Value != value)
                    _header4.Value = value;
            }
        }

        private IniItem<double> _header5 = new()
        {
            Section = BaceValue.Section,
            Key = "Header5",
            DefaultValue = BaceValue.Header5,
            Value = BaceValue.Header5,
        };

        public double Header5
        {
            get => _header5.Value;
            set
            {
                if (_header5.Value != value)
                    _header5.Value = value;
            }
        }

        private IniItem<double> _header6 = new()
        {
            Section = BaceValue.Section,
            Key = "Header6",
            DefaultValue = BaceValue.Header6,
            Value = BaceValue.Header6,
        };

        public double Header6
        {
            get => _header6.Value;
            set
            {
                if (_header6.Value != value)
                    _header6.Value = value;
            }
        }

        private IniItem<double> _default = new()
        {
            Section = BaceValue.Section,
            Key = "Default",
            DefaultValue = BaceValue.Default,
            Value = BaceValue.Default,
        };

        public double Default
        {
            get => _default.Value;
            set
            {
                if (_default.Value != value)
                    _default.Value = value;
            }
        }


        public bool SetValue_Form(IINIState? iniFile)
        {
            if (iniFile is null)
                return false;
            bool result = false;
            result |= !iniFile.SetValue_UseParser(_header1);
            result |= !iniFile.SetValue_UseParser(_header2);
            result |= !iniFile.SetValue_UseParser(_header3);
            result |= !iniFile.SetValue_UseParser(_header4);
            result |= !iniFile.SetValue_UseParser(_header5);
            result |= !iniFile.SetValue_UseParser(_header6);
            result |= !iniFile.SetValue_UseParser(_default);
            return !result;
        }

        public bool GetValue_Form(IINIState? iniFile)
        {
            if (iniFile is null)
                return false;
            _header1.DefaultValue = iniFile.GetValue_UseParser(ref _header1);
            _header2.DefaultValue = iniFile.GetValue_UseParser(ref _header2);
            _header3.DefaultValue = iniFile.GetValue_UseParser(ref _header3);
            _header4.DefaultValue = iniFile.GetValue_UseParser(ref _header4);
            _header5.DefaultValue = iniFile.GetValue_UseParser(ref _header5);
            _header6.DefaultValue = iniFile.GetValue_UseParser(ref _header6);
            _default.DefaultValue = iniFile.GetValue_UseParser(ref _default);
            ResetDefault();
            return true;
        }

        public void ResetDefault()
        {
            _header1.Value = _header1.DefaultValue;
            _header2.Value = _header2.DefaultValue;
            _header3.Value = _header3.DefaultValue;
            _header4.Value = _header4.DefaultValue;
            _header5.Value = _header5.DefaultValue;
            _header6.Value = _header6.DefaultValue;
            _default.Value = _default.DefaultValue;
        }

        public FontSize() { }

        public FontSize(FontSize dest)
        {
            Header1 = dest.Header1;
            Header2 = dest.Header2;
            Header3 = dest.Header3;
            Header4 = dest.Header4;
            Header5 = dest.Header5;
            Header6 = dest.Header6;
            Default = dest.Default;
        }
    }
}
