using SimpleFileIO.State.Ini;

namespace SimpleOverlayTheme.Themes.Interface
{
    /// <summary>
    /// Represents a generic interface for a single theme property value, <br/>
    /// providing methods for applying from and restoring to an INI state.
    /// </summary>
    internal interface IThemePropertyValue
    {
        /// <summary>
        /// Applies the value from the specified <see cref="IINIState"/> instance. <br/>
        /// This reads a value previously loaded from an INI file (temporary memory only).
        /// </summary>
        /// <param name="iniState">The INI state to apply from.</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        bool Apply(IINIState? iniState);

        /// <summary>
        /// Restores the current value into the specified <see cref="IINIState"/> instance. <br/>
        /// This stores the value in memory, but does not trigger a file save.
        /// </summary>
        /// <param name="iniState">The INI state to write into.</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        bool Restore(IINIState? iniState);

        /// <summary>
        /// Resets the current value to its default.
        /// </summary>
        void ResetValueToDefault();
    }
}
