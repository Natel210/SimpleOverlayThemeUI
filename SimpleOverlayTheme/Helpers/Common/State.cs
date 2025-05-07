using System.ComponentModel;
using System.Windows;
using SimpleOverlayTheme.Share.StringTable;
using SimpleOverlayTheme.Share.Overlay;

namespace SimpleOverlayTheme.Helpers.Common
{
    /// <summary>
    /// 
    /// </summary>
    public partial class State : APropertyHelper {}

    #region ========== State ==========
    public partial class State
    {
        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static readonly DependencyProperty StateProperty
            = GeneratorProperty(HelperPropertyKey.Common.State.PropertyName,
                typeof(EState), typeof(State));

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [DisplayName(HelperPropertyKey.Common.State.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static EState GetState(UIElement element)
            => (EState)element.GetValue(StateProperty);

        /// <summary></summary>
        [Browsable(true)]
        [Category(HelperPropertyKey.Common.CategoryName)]
        [DisplayName(HelperPropertyKey.Common.State.DisplayName)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Border))]
        public static void SetState(UIElement element, EState value)
            => element.SetValue(StateProperty, value);
    }
    #endregion
}
