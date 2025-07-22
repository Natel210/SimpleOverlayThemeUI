using System.Threading;

namespace SimpleVisualTheme.Theme.Data.Internal
{
    /// <summary></summary>
    internal class ThemeDataProperty : IThemeDataProperty
    {
        private string _xamlKey = "";
        private readonly ReaderWriterLockSlim _xamlKeyLock = new();
        /// <summary></summary>
        public string XamlKey
        {
            get
            {
                _xamlKeyLock.EnterReadLock();
                try
                {
                    return _xamlKey;
                }
                finally
                {
                    _xamlKeyLock.ExitReadLock();
                }
            }
            set
            {
                _xamlKeyLock.EnterWriteLock();
                try
                {
                    _xamlKey = value;
                }
                finally
                {
                    _xamlKeyLock.ExitWriteLock();
                }
            }
        }

        private string _type = "";
        private readonly ReaderWriterLockSlim _typeLock = new();
        /// <summary></summary>
        public string Type
        {
            get
            {
                _typeLock.EnterReadLock();
                try
                {
                    return _type;
                }
                finally
                {
                    _typeLock.ExitReadLock();
                }
            }
            set
            {
                _typeLock.EnterWriteLock();
                try
                {
                    _type = value;
                }
                finally
                {
                    _typeLock.ExitWriteLock();
                }
            }
        }

        private string _value = "";
        private readonly ReaderWriterLockSlim _valueLock = new();
        /// <summary></summary>
        public string Value
        {
            get
            {
                _valueLock.EnterReadLock();
                try
                {
                    return _value;
                }
                finally
                {
                    _valueLock.ExitReadLock();
                }
            }
            set
            {
                _valueLock.EnterWriteLock();
                try
                {
                    _value = value;
                }
                finally
                {
                    _valueLock.ExitWriteLock();
                }
            }
        }

        /// <summary></summary>
        public IThemeDataProperty Clone() => new ThemeDataProperty { XamlKey = _xamlKey, Type = _type, Value = _value };
    }
}
