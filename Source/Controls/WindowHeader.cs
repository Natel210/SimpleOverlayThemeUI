using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace SimpleOverlayTheme.Controls
{
    /// <summary> custom window header control. </summary>
    /// <remarks>
    /// <para>UI => [Title] [Tail] _ □ X </para>
    /// </remarks>
    public class WindowHeader : ContentControl
    {
        #region Property
        /// <summary> custom content area before the system buttons.</summary>
        /// <remarks> system buttons = > minimize, maximize, close</remarks>
        public object? TailContent { get { return GetValue(TailContentProperty); } set { SetValue(TailContentProperty, value); } }

        /// <summary> TailContent DataTemplate. </summary>
        public DataTemplate? TailContentTemplate { get { return GetValue(TailContentTemplateProperty) as DataTemplate; } set { SetValue(TailContentTemplateProperty, value); } }

        /// <summary>" _ "</summary>
        public DataTemplate? MinimizeButtonTemplate { get => GetValue(MinimizeButtonTemplateProperty) as DataTemplate; set => SetValue(MinimizeButtonTemplateProperty, value); }

        /// <summary>" X "</summary>
        public DataTemplate? CloseButtonTemplate { get => GetValue(CloseButtonTemplateProperty) as DataTemplate; set => SetValue(CloseButtonTemplateProperty, value); }

        /// <summary>" □ "</summary>
        public DataTemplate? MaximizeRestoreButtonTemplate { get => GetValue(MaximizeRestoreButtonTemplateProperty) as DataTemplate; set => SetValue(MaximizeRestoreButtonTemplateProperty, value); }

        /// <summary> true lock, false unlock </summary>
        public bool WindowUnlocked { get { return (bool)GetValue(WindowUnlockedProperty); } set { SetValue(WindowUnlockedProperty, value); } }

        /// <summary></summary>
        public Visibility VisibleClose { get => (Visibility)GetValue(VisibleCloseProperty); set => SetValue(VisibleCloseProperty, value); }

        /// <summary></summary>
        public Visibility VisibleMaximizeRestore { get => (Visibility)GetValue(VisibleMaximizeRestoreProperty); set => SetValue(VisibleMaximizeRestoreProperty, value); }

        /// <summary></summary>
        public Visibility VisibleMinimize { get => (Visibility)GetValue(VisibleMinimizeProperty); set => SetValue(VisibleMinimizeProperty, value); }

        /// <summary></summary>
        public Visibility VisibleTail { get { return (Visibility)GetValue(VisibleTailProperty); } set { SetValue(VisibleTailProperty, value); } }

        #endregion

        #region DependencyProperty

        /// <summary></summary>
        public static readonly DependencyProperty TailContentProperty = PropertyRegister(nameof(TailContent), typeof(object), null);

        /// <summary></summary>
        public static readonly DependencyProperty TailContentTemplateProperty = PropertyRegister(nameof(TailContentTemplate), typeof(DataTemplate), null);

        /// <summary></summary>
        public static readonly DependencyProperty MinimizeButtonTemplateProperty = PropertyRegister(nameof(MinimizeButtonTemplate), typeof(DataTemplate), null);

        /// <summary></summary>
        public static readonly DependencyProperty CloseButtonTemplateProperty = PropertyRegister(nameof(CloseButtonTemplate), typeof(DataTemplate), null);

        /// <summary></summary>
        public static readonly DependencyProperty MaximizeRestoreButtonTemplateProperty = PropertyRegister(nameof(MaximizeRestoreButtonTemplate), typeof(DataTemplate), null);

        /// <summary></summary>
        public static readonly DependencyProperty WindowUnlockedProperty = PropertyRegister(nameof(WindowUnlocked), typeof(bool), true);

        /// <summary></summary>
        public static readonly DependencyProperty VisibleCloseProperty = PropertyRegister(nameof(VisibleClose), typeof(Visibility), Visibility.Visible);

        /// <summary></summary>
        public static readonly DependencyProperty VisibleMaximizeRestoreProperty = PropertyRegister(nameof(VisibleMaximizeRestore), typeof(Visibility), Visibility.Visible);

        /// <summary></summary>
        public static readonly DependencyProperty VisibleMinimizeProperty = PropertyRegister(nameof(VisibleMinimize), typeof(Visibility), Visibility.Visible);

        /// <summary></summary>
        public static readonly DependencyProperty VisibleTailProperty = PropertyRegister(nameof(VisibleTail), typeof(Visibility), Visibility.Visible);

        #endregion

        #region Private

        static WindowHeader()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowHeader),
                new FrameworkPropertyMetadata(typeof(WindowHeader)));
        }

        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions
            = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        private static DependencyProperty PropertyRegister(string name, Type propertyType, object? defaultValue = null)
        {
            return DependencyProperty.Register(name, propertyType,
                typeof(WindowHeader), new FrameworkPropertyMetadata(defaultValue, _frameworkPropertyMetadataOptions));
        }

        #endregion


    }
}
