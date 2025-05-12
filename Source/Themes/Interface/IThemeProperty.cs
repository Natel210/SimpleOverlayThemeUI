using SimpleFileIO.State.Ini;

namespace SimpleOverlayTheme.Themes.Interface
{
    /// <summary>
    /// Represents a group of theme-related properties that can be synchronized with an INI file. <br/>
    /// Used to manage multiple property values together for loading, saving, or resetting.
    /// </summary>
    internal interface IThemeProperty
    {
        /// <summary>
        /// Applies the values from the given <see cref="IINIState"/> instance. <br/>
        /// Typically called after loading the INI file to update the internal values.
        /// </summary>
        /// <param name="iniState">The INI state containing previously loaded values.</param>
        /// <returns>True if all values were applied successfully; otherwise, false.</returns>
        bool Apply(IINIState? iniState);

        /// <summary>
        /// Restores the current internal values into the specified <see cref="IINIState"/> instance. <br/>
        /// This does not save to disk; it only stores the values into the INI state temporarily.
        /// </summary>
        /// <param name="iniState">The INI state to populate with current values.</param>
        /// <returns>True if all values were stored successfully; otherwise, false.</returns>
        bool Restore(IINIState? iniState);

        /// <summary>
        /// Resets all values in the group to their default values.
        /// </summary>
        void ResetValueToDefault();
    }
}
