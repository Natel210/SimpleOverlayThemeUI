using SimpleFileIO.State.Ini;
using SimpleFileIO.Utility;
using SimpleOverlayTheme.Theme.Interface;

namespace SimpleOverlayTheme.Theme.ThemeProperty
{
    /// <summary>
    /// A generic theme property class that manages a value and its default.<br/>
    /// Uses <see cref="IniItem{T}"/> internally to store and synchronize values<br/>
    /// with an <see cref="IINIState"/> instance.
    /// </summary>
    internal partial class ThemePropertyValue<T> : IThemePropertyValue where T : notnull
    {
        private IniItem<T> _iniItem;
        private readonly Mutex _iniItemMutex;

        /// <summary>
        /// Constructor that initializes the value with a section, key, and default.
        /// </summary>
        /// <param name="section">The section name in the INI file.</param>
        /// <param name="key">The key name for this value.</param>
        /// <param name="defaultValue">The default value to be used.</param>
        internal ThemePropertyValue(string section, string key, T defaultValue)
        {
            _iniItemMutex = new Mutex();
            lock (_iniItemMutex)
            {
                _iniItem = new IniItem<T>
                {
                    Section = section,
                    Key = key,
                    Value = defaultValue,
                    DefaultValue = defaultValue
                };
            }
        }

        internal ThemePropertyValue<T> Clone()
        {
            return new ThemePropertyValue<T>(this._iniItem.Section, this._iniItem.Key, this.DefaultValue) { Value = this.Value };
        }

        /// <summary>
        /// Gets or sets the current value.<br/>
        /// A defensive deep copy is returned if supported by type.
        /// </summary>
        internal T Value
        {
            get => CopyValue(_iniItem.Value);
            set
            {
                lock (_iniItemMutex)
                {
                    if (!EqualityComparer<T>.Default.Equals(_iniItem.Value, value))
                        _iniItem.Value = CopyValue(value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
        internal T DefaultValue
        {
            get => CopyValue(_iniItem.DefaultValue);
            set
            {
                lock (_iniItemMutex)
                {
                    if (!EqualityComparer<T>.Default.Equals(_iniItem.DefaultValue, value))
                        _iniItem.DefaultValue = CopyValue(value);
                }
            }
        }

        /// <summary>
        /// Attempts to deep-copy a value using a copy constructor if available.<br/>
        /// If not available, returns the original reference or value.
        /// </summary>
        /// <param name="value">The value to copy.</param>
        /// <returns>A deep copy of the value if possible; otherwise, the original value.</returns>
        private static T CopyValue(T value)
        {
            //if (value == null)
            //    throw new ArgumentNullException(nameof(value));
            var copyCtor = typeof(T).GetConstructor(new[] { typeof(T) });
            if (copyCtor != null)
                return (T)copyCtor.Invoke(new object[] { value });
            return value; // Fallback
        }
    }

    #region ========== Interface - IThemePropertyValue ==========
    internal partial class ThemePropertyValue<T>
    {
        /// <inheritdoc />
        public bool Apply(IINIState? iniState)
        {
            if (iniState is null)
                return false;
            bool result;
            lock (_iniItemMutex)
                result = iniState.SetValue_UseParser(_iniItem);
            return result;
        }

        /// <inheritdoc />
        public bool Restore(IINIState? iniState)
        {
            if (iniState is null)
                return false;
            lock (_iniItemMutex)
                iniState.GetValue_UseParser(ref _iniItem);
            return true;
        }

        /// <inheritdoc />
        public void ResetValueToDefault()
        {
            lock (_iniItemMutex)
                _iniItem.Value = _iniItem.DefaultValue;
        }
    }
    #endregion
}

