using SimpleFileIO.State.Ini;
using SimpleFileIO.Utility;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleOverlayTheme.ThemeSystem
{
    public class Data
    {

        private readonly IINIState _iniFile;

        private string _name;

        //Commons
        public Specific.FontSize FontSize { get; } = new();

        public Specific.DefaultBrush DefaultBrush { get; } = new();

        public Specific.OverlayBoaderBackground OverlayBoaderBackground { get; } = new();

        public Specific.OverlayBoaderOutline OverlayBoaderOutline { get; } = new();

        public Specific.OverlayMaskForeground OverlayMaskForeground { get; } = new();

        public PathProperty IniPathProperty
        {
            get => _iniFile.Properties;
            set => _iniFile.Properties = value;
        }

        public string Name
        {
            get => _name;
        }

        internal Data(string name, PathProperty properties)
        {
            _name = name;
            
            SimpleFileIO.Manager.CreateIniState($"{name}_ini", properties);
            _iniFile = SimpleFileIO.Manager.GetIniState($"{name}_ini") ?? throw new ArgumentNullException($"not make {name}_ini...");
            _iniFile.AddParser(typeof(Color), new()
            {
                TargetType = typeof(Color),

                // Converts a Color object to a string in the format "A,R,G,B".
                ObjectToString = (obj) => obj is Color color ? $"{color.A},{color.R},{color.G},{color.B}" : "0,0,0,0",

                // Converts a string in the format "A,R,G,B" or "R,G,B" to a Color object.
                // 1. If length is not 3 or 4, return null (invalid input).
                // 2. If length is 3, default Alpha (A) to 255.
                // 3. If length is 4, use the first value as Alpha (A).
                StringToObject = (str) =>
                {
                    var strArray = str.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    return (strArray.Length is 3 or 4)
                        ? Color.FromArgb(
                            strArray.Length == 4 ? byte.Parse(strArray[0]) : (byte)255, // Alpha
                            byte.Parse(strArray[^3]), // Red
                            byte.Parse(strArray[^2]), // Green
                            byte.Parse(strArray[^1])  // Blue
                        )
                        : null;
                }
            });

            Load();
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
            result |= !OverlayBoaderBackground.GetValue_Form(_iniFile);
            result |= !OverlayBoaderOutline.GetValue_Form(_iniFile);
            result |= !OverlayMaskForeground.GetValue_Form(_iniFile);
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
            string doubleForm = "<System:Double x:Key=\"{0}\">{1}</System:Double>";
            string thicknessForm = "<Thickness x:Key=\"{0}\">{1}</Thickness>";
            string brushForm = "<SolidColorBrush x:Key=\"{0}\" Color=\"{1}\"/>";
            

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
            xamlBuilder.AppendLine($"<System:String x:Key=\"{KeywordDictionary.ThemeSystemKey.CurrentThemeName}\">{Name}</System:String>");

            xamlBuilder.AppendLine("");
            xamlBuilder.AppendLine("<!-- Font Sizes -->");
            xamlBuilder.AppendLine(string.Format(doubleForm, KeywordDictionary.ThemeSystemKey.FontSize.Header1, FontSize.Header1));
            xamlBuilder.AppendLine(string.Format(doubleForm, KeywordDictionary.ThemeSystemKey.FontSize.Header2, FontSize.Header2));
            xamlBuilder.AppendLine(string.Format(doubleForm, KeywordDictionary.ThemeSystemKey.FontSize.Header3, FontSize.Header3));
            xamlBuilder.AppendLine(string.Format(doubleForm, KeywordDictionary.ThemeSystemKey.FontSize.Header4, FontSize.Header4));
            xamlBuilder.AppendLine(string.Format(doubleForm, KeywordDictionary.ThemeSystemKey.FontSize.Header5, FontSize.Header5));
            xamlBuilder.AppendLine(string.Format(doubleForm, KeywordDictionary.ThemeSystemKey.FontSize.Header6, FontSize.Header6));
            xamlBuilder.AppendLine(string.Format(doubleForm, KeywordDictionary.ThemeSystemKey.FontSize.Default, FontSize.Default));

            xamlBuilder.AppendLine("");
            xamlBuilder.AppendLine("<!-- Thickness -->");
            xamlBuilder.AppendLine(string.Format(thicknessForm, KeywordDictionary.ThemeSystemKey.DefaultThickness.Default, 1.0));
            xamlBuilder.AppendLine(string.Format(thicknessForm, KeywordDictionary.ThemeSystemKey.DefaultThickness.Zero, 0.0));

            xamlBuilder.AppendLine("");
            xamlBuilder.AppendLine("<!-- Default Brush -->");
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.DefaultBrush.Foreground,
                DefaultBrush.Foreground.Color.ToString()));
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.DefaultBrush.Foreground_Disable,
                DefaultBrush.Foreground_Disable.Color.ToString()));
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.DefaultBrush.Background,
                DefaultBrush.Background.Color.ToString()));
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.DefaultBrush.Outline,
                DefaultBrush.Outline.Color.ToString()));
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.DefaultBrush.Line,
                DefaultBrush.Line.Color.ToString()));
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.DefaultBrush.Highlight,
                DefaultBrush.Highlight.Color.ToString()));
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.DefaultBrush.Selection,
                DefaultBrush.Selection.Color.ToString()));
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.DefaultBrush.Mask,
                DefaultBrush.Mask.Color.ToString()));

            xamlBuilder.AppendLine("");
            xamlBuilder.AppendLine("<!-- Overlay Boader Background -->");
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.OverlayBoader.Background.Disable,
                OverlayBoaderBackground.Disable.Color.ToString()));
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.OverlayBoader.Background.Default,
                OverlayBoaderBackground.Default.Color.ToString()));
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.OverlayBoader.Background.MouseOver,
                OverlayBoaderBackground.MouseOver.Color.ToString()));
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.OverlayBoader.Background.Active,
                OverlayBoaderBackground.Active.Color.ToString()));

            xamlBuilder.AppendLine("");
            xamlBuilder.AppendLine("<!-- Overlay Boader Outline -->");
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.OverlayBoader.Outline.Disable,
                OverlayBoaderOutline.Disable.Color.ToString()));
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.OverlayBoader.Outline.Default,
                OverlayBoaderOutline.Default.Color.ToString()));
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.OverlayBoader.Outline.MouseOver,
                OverlayBoaderOutline.MouseOver.Color.ToString()));
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.OverlayBoader.Outline.Active,
                OverlayBoaderOutline.Active.Color.ToString()));

            xamlBuilder.AppendLine("");
            xamlBuilder.AppendLine("<!-- Overlay Mask Foreground -->");
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.OverlayMask.Foreground.Disable,
                OverlayMaskForeground.Disable.Color.ToString()));
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.OverlayMask.Foreground.Default,
                OverlayMaskForeground.Default.Color.ToString()));
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.OverlayMask.Foreground.MouseOver,
                OverlayMaskForeground.MouseOver.Color.ToString()));
            xamlBuilder.AppendLine(string.Format(brushForm, KeywordDictionary.ThemeSystemKey.OverlayMask.Foreground.Active,
                OverlayMaskForeground.Active.Color.ToString()));

            xamlBuilder.AppendLine("");
            xamlBuilder.AppendLine("</ResourceDictionary>");
            if (superDirectoryInfo.Exists is false)
                superDirectoryInfo.Create();
            var getPath = System.IO.Path.Combine(superDirectoryInfo.FullName, $"{Name}ModeDummy.xaml");
            File.WriteAllText(getPath, xamlBuilder.ToString());
        }
    }
}
