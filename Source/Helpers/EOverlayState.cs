namespace SimpleOverlayTheme.Helpers
{
    /// <summary>
    /// Represents the visual overlay state of a UI element.
    /// Used to define styling or behavior based on current UI interaction or logic.
    /// </summary>
    public enum EOverlayState
    {
        /// <summary> The active state, typically representing the selected or engaged status. </summary>
        Active,
        /// <summary> The default or idle state when no interaction is occurring. </summary>
        Default,
        /// <summary> The disabled state where the UI element is not interactive. </summary>
        Disable,
        /// <summary> The mouse-over (hover) state, indicating the pointer is over the element. </summary>
        Mouseover,
    }
}
