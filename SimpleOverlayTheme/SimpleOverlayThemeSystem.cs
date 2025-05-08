using SimpleOverlayTheme.Theme;
using SimpleOverlayTheme.Theme.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOverlayTheme
{
    static public class SimpleOverlayThemeSystem
    {
        /// <summary>
        /// 
        /// </summary>
        static public ICurrent Current { get; } = Theme.Current.Instance;

        static private Dictionary<string, ThemeObejct> _themes = new Dictionary<string, ThemeObejct>();


#pragma warning disable CA2255 // Module initializer should not be used in normal code
        /// <summary>
        /// 
        /// </summary>
        [ModuleInitializer]
        static public void Initialize()
        {
            Current.Load();

            Theme.Current.Instance.Initialize();
            Current.Save();
        }
#pragma warning restore CA2255

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static public bool CreateTheme(string name)
        {
            ThemeObejct themeObejct;
            if (_themes.ContainsKey(name))
            {
                themeObejct = _themes[name].CreateCopy();
            }
            else
            {
                themeObejct = Theme.Current.Instance.CreateCopy();
            }
            return false;
            //if (name )
            //{

            //}


            if (_themes.ContainsKey(name))
                return false;
            var theme = new ThemeObejct(name);
            _themes.Add(name, theme);
            return true;
        }



    }
}
