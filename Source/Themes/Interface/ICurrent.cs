using System.ComponentModel;

namespace SimpleOverlayTheme.Themes.Interface
{
    /// <summary>
    /// A composite interface of <see cref="ITheme"/> and <see cref="INotifyPropertyChanged"/>. <br/>
    /// Intended to be used as a ViewModel in MVVM architecture.
    /// </summary>
    public interface ICurrent : ITheme, INotifyPropertyChanged
    {
        /// <summary> System flag to automatically save the current theme. </summary>
        bool AutoSave { get; set; }

        /// <summary> Saves the current theme settings to the associated INI file. </summary>
        bool Save();

        /// <summary> Loads theme values from INI file and applies them to the current theme instance and UI. </summary>
        bool Load();

        /// <summary> Applies INI memory values to the current theme instance and reflects changes in UI. </summary>
        bool RestoreAndSyncUI();

        /// <summary>
        /// Resets all values in this theme to their predefined default values.
        /// </summary>
        void ResetValueToDefault();
    }
}
