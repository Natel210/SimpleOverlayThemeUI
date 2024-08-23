using GrayThemeUI.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;

namespace GrayThemeUI
{
    public static class Main
    {
        public static class FontSize
        {
            private static double _header1 = 10.0;
            public static double Header1
            {
                get => _header1;
                set
                {
                    if (_header1 != value)
                    {
                        _header1 = value;
                        OnPropertyChanged(nameof(Header1));
                    }
                }
            }











            public static event PropertyChangedEventHandler? PropertyChanged;
            private static void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
            }






        }


        



    //        <sys:Double x:Key="GrayThemeUI.Common.FontSize.Header1">20.0</sys:Double>
    //<sys:Double x:Key="GrayThemeUI.Common.FontSize.Header2">16.0</sys:Double>
    //<sys:Double x:Key="GrayThemeUI.Common.FontSize.Default">12.0</sys:Double>
    //<Thickness x:Key="GrayThemeUI.Common.BorderThickness">1</Thickness>

    //<SolidColorBrush x:Key="GrayThemeUI.Common.LineColor" Color="Gray"/>
    //<SolidColorBrush x:Key="GrayThemeUI.Common.HighlightColor" Color="#50FFFFFF"/>
    //<SolidColorBrush x:Key="GrayThemeUI.Common.CommonSelectionBrush" Color="#FF808080"/>
    //<SolidColorBrush x:Key="GrayThemeUI.Common.MaskColor" Color="#A0808080"/>




        private static readonly Uri _themeDark = new("pack://application:,,,/GrayThemeUI;component/Theme/Dark.xaml");
        private static readonly Uri _themeLight = new("pack://application:,,,/GrayThemeUI;component/Theme/Light.xaml");

        public static void ThemeDark()
        {
            var findingTheme = Application.Current.Resources.MergedDictionaries.Where(d => d.Source == _themeLight).ToList();
            foreach (var item in findingTheme)
                Application.Current.Resources.MergedDictionaries.Remove(item);
            var resourceDictionary = new ResourceDictionary {
                Source = new Uri("pack://application:,,,/GrayThemeUI;component/Theme/Dark.xaml",
                UriKind.Absolute)
            };
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }
        public static void ThemeLight()
        {
            var findingTheme = Application.Current.Resources.MergedDictionaries.Where(d => d.Source == _themeDark).ToList();
            foreach (var item in findingTheme)
                Application.Current.Resources.MergedDictionaries.Remove(item);
            var resourceDictionary = new ResourceDictionary {
                Source = new Uri("pack://application:,,,/GrayThemeUI;component/Theme/Light.xaml",
                UriKind.Absolute)
            };
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }
    }
}
