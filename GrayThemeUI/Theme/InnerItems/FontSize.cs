using System;
using utility.ini;

namespace GrayThemeUI.Theme.InnerItems
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

        public IniItem<double> Header1 { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "Header1",
            DefaultValue = BaceValue.Header1,
            Value = BaceValue.Header1,
        };

        public IniItem<double> Header2 { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "Header2",
            DefaultValue = BaceValue.Header2,
            Value = BaceValue.Header2,
        };

        public IniItem<double> Header3 { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "Header3",
            DefaultValue = BaceValue.Header3,
            Value = BaceValue.Header3,
        };

        public IniItem<double> Header4 { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "Header4",
            DefaultValue = BaceValue.Header4,
            Value = BaceValue.Header4,
        };

        public IniItem<double> Header5 { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "Header5",
            DefaultValue = BaceValue.Header5,
            Value = BaceValue.Header5,
        };

        public IniItem<double> Header6 { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "Header6",
            DefaultValue = BaceValue.Header6,
            Value = BaceValue.Header6,
        };

        public IniItem<double> Default { get; } = new()
        {
            Section = BaceValue.Section,
            Key = "Default",
            DefaultValue = BaceValue.Default,
            Value = BaceValue.Default,
        };

        public bool SetValue_Form(IniFile? iniFile)
        {
            if (iniFile is null)
                return false;
            bool result = false;
            result |= !iniFile.SetValue(Header1);
            result |= !iniFile.SetValue(Header2);
            result |= !iniFile.SetValue(Header3);
            result |= !iniFile.SetValue(Header4);
            result |= !iniFile.SetValue(Header5);
            result |= !iniFile.SetValue(Header6);
            result |= !iniFile.SetValue(Default);
            return !result;
        }

        public bool GetValue_Form(IniFile? iniFile)
        {
            if (iniFile is null)
                return false;
            Header1.DefaultValue = iniFile.GetValue(Header1) ?? Header1.DefaultValue;
            Header2.DefaultValue = iniFile.GetValue(Header2) ?? Header2.DefaultValue;
            Header3.DefaultValue = iniFile.GetValue(Header3) ?? Header3.DefaultValue;
            Header4.DefaultValue = iniFile.GetValue(Header4) ?? Header4.DefaultValue;
            Header5.DefaultValue = iniFile.GetValue(Header5) ?? Header5.DefaultValue;
            Header6.DefaultValue = iniFile.GetValue(Header6) ?? Header6.DefaultValue;
            Default.DefaultValue = iniFile.GetValue(Default) ?? Default.DefaultValue;
            ResetDefault();
            return true;
        }

        public void ResetDefault()
        {
            Header1.Value = Header1.DefaultValue;
            Header2.Value = Header2.DefaultValue;
            Header3.Value = Header3.DefaultValue;
            Header4.Value = Header4.DefaultValue;
            Header5.Value = Header5.DefaultValue;
            Header6.Value = Header6.DefaultValue;
            Default.Value = Default.DefaultValue;
        }

        public FontSize() { }

        public FontSize(FontSize dest)
        {
            Header1 = new(dest.Header1);
            Header2 = new(dest.Header2);
            Header3 = new(dest.Header3);
            Header4 = new(dest.Header4);
            Header5 = new(dest.Header5);
            Header6 = new(dest.Header6);
            Default = new(dest.Default);
        }
    }
}
