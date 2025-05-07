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
    public class IniPair
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly string Section;

        /// <summary>
        /// 
        /// </summary>
        public readonly string Key;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        public IniPair(string section, string key)
        {
            Section = section;
            Key = key;
        }
    }
}
