using SimpleVisualTheme.Theme.Data;
using SimpleVisualTheme.Theme.Data.Internal;
using System.Collections.Generic;
using System.Threading;

namespace SimpleVisualTheme.Theme.Current
{
    /// <summary></summary>
    public class Current
    {
        // Singleton Instance
        public static Current Instance { get; } = new Current();
        private Current()
        {
            _themeData = ThemeDataGroup.Instance.GetData("Current");
        }

        private string _themeName = "";
        private readonly ReaderWriterLockSlim _themeNameLock = new();

        /// <summary></summary>
        public string ThemeName
        {
            get
            {
                _themeNameLock.EnterReadLock();
                try
                {
                    return _themeName;
                }
                finally
                {
                    _themeNameLock.ExitReadLock();
                }
            }
            set
            {

                bool changed = false;
                _themeNameLock.EnterWriteLock();
                try
                {
                    if (_themeName != value)
                    {
                        _themeName = value;
                        changed = true;
                    }
                }
                finally
                {
                    _themeNameLock.ExitWriteLock();
                }
                if (changed is true)
                {
                    ChangedThemeName();
                }
            }
        }

        private IThemeData? _themeData = null;
        public bool AutoSave { get; set; } = true;
        // 









        // 전체의 딕셔너리 변경
        private void ChangedThemeName()
        {
            var themeData = ThemeDataGroup.Instance.GetData(ThemeName);
            if (themeData is null)
                return;
            themeData.Clone();

            var propertyKeys = themeData.PropertyKeys();
            foreach (var propertyKey in propertyKeys) {
                var property = themeData.GetProperty(propertyKey);
                if (property is null)
                    continue;
                ThemeResourceDictionary.Instance.SetThemeProperty(propertyKey, property.Value);
            }

            // 하고 항목들에 대한 어나운스....

            //어나운스 대상은 app의 루트 기준.

            // 또한 하위에서 사용중인 해당 항목이 있다면 그건 중복임으로 삭제를 하고싶어요.

        }

    }
}
