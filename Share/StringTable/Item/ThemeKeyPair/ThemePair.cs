using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOverlayTheme.Share.StringTable.Item
{
    /// <summary>
    /// 
    /// </summary>
    public class ThemePair
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly IniPair Ini;

        /// <summary>
        /// 
        /// </summary>
        public readonly string Xaml;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="xaml"></param>
        /// <param name="iniSection"></param>
        /// <param name="iniKey"></param>
        public ThemePair(string xaml, string iniSection, string iniKey)
        {
            Xaml = xaml;
            Ini = new(iniSection, iniKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xaml"></param>
        /// <param name="iniPair"></param>
        public ThemePair(string xaml, IniPair iniPair)
        {
            Xaml = "";
            Ini = iniPair;
        }

    }
}
