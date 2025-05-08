
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleOverlayTheme.Helpers
{
    /// <summary></summary>
    static public class KeyWord
    {
        /// <summary></summary>
        private const string RootCategoryName = "SimpleOverlayTheme";



        /// <summary></summary>
        static public class BorderHelper
        {
            //State
            // - 

            //AddImage
            //DisplayImage




            /// <summary></summary>
            public const string CategoryName = $"{RootCategoryName}.{nameof(BorderHelper)}";

            /// <summary></summary>
            static public class OverlayState
            {
                /// <summary></summary>
                static public class CurrentOverlayState
                {
                    /// <summary></summary>
                    public const string CategoryName = $"Helper.{nameof(OverlayState)}";
                    /// <summary></summary>
                    public const string PropertyName = $"{nameof(CurrentOverlayState)}";
                    /// <summary></summary>
                    public const string GetFuncDisplayName = $"{nameof(OverlayState)}.{nameof(CurrentOverlayState)}";
                    /// <summary></summary>
                    public const string SetFuncDisplayName = $"{nameof(OverlayState)}.{nameof(CurrentOverlayState)}";
                }
            }

            /// <summary></summary>
            static public class ActiveImage
            {
                /// <summary></summary>
                static public class Use
                {
                    /// <summary></summary>
                    public const string PropertyName = $"{nameof(Use)}";
                    /// <summary></summary>
                    public const string GetFuncDisplayName = $"{nameof(ActiveImage)}.{nameof(Use)}";
                    /// <summary></summary>
                    public const string SetFuncDisplayName = $"{nameof(ActiveImage)}.{nameof(Use)}";
                }

                /// <summary></summary>
                static public class ImageBrush
                {
                    /// <summary></summary>
                    public const string PropertyName = $"{nameof(ImageBrush)}";
                    /// <summary></summary>
                    public const string GetFuncDisplayName = $"{nameof(ActiveImage)}.{nameof(ImageBrush)}";
                    /// <summary></summary>
                    public const string SetFuncDisplayName = $"{nameof(ActiveImage)}.{nameof(ImageBrush)}";
                }
            }

            /// <summary></summary>
            static public class DisableImage
            {
                /// <summary></summary>
                static public class Use
                {
                    /// <summary></summary>
                    public const string PropertyName = $"{nameof(Use)}";
                    /// <summary></summary>
                    public const string GetFuncDisplayName = $"{nameof(DisableImage)}.{nameof(Use)}";
                    /// <summary></summary>
                    public const string SetFuncDisplayName = $"{nameof(DisableImage)}.{nameof(Use)}";
                }

                /// <summary></summary>
                static public class ImageBrush
                {
                    /// <summary></summary>
                    public const string PropertyName = $"{nameof(ImageBrush)}";
                    /// <summary></summary>
                    public const string GetFuncDisplayName = $"{nameof(DisableImage)}.{nameof(ImageBrush)}";
                    /// <summary></summary>
                    public const string SetFuncDisplayName = $"{nameof(DisableImage)}.{nameof(ImageBrush)}";
                }
            }

            /// <summary></summary>
            static public class MouseOverImage
            {
                /// <summary></summary>
                static public class Use
                {
                    /// <summary></summary>
                    public const string PropertyName = $"{nameof(Use)}";
                    /// <summary></summary>
                    public const string GetFuncDisplayName = $"{nameof(MouseOverImage)}.{nameof(Use)}";
                    /// <summary></summary>
                    public const string SetFuncDisplayName = $"{nameof(MouseOverImage)}.{nameof(Use)}";
                }

                /// <summary></summary>
                static public class ImageBrush
                {
                    /// <summary></summary>
                    public const string PropertyName = $"{nameof(ImageBrush)}";
                    /// <summary></summary>
                    public const string GetFuncDisplayName = $"{nameof(MouseOverImage)}.{nameof(ImageBrush)}";
                    /// <summary></summary>
                    public const string SetFuncDisplayName = $"{nameof(MouseOverImage)}.{nameof(ImageBrush)}";
                }
            }

            /// <summary></summary>
            static public class OverlayBackground
            {
                /// <summary></summary>
                static public class Display
                {
                    /// <summary></summary>
                    public const string PropertyName = $"{nameof(Display)}";
                    /// <summary></summary>
                    public const string GetFuncDisplayName = $"{nameof(OverlayBackground)}.{nameof(Display)}";
                    /// <summary></summary>
                    public const string SetFuncDisplayName = $"{nameof(OverlayBackground)}.{nameof(Display)}";
                }

                /// <summary></summary>
                static public class DisplayDefaultBrush
                {
                    /// <summary></summary>
                    public const string PropertyName = $"{nameof(DisplayDefaultBrush)}";
                    /// <summary></summary>
                    public const string GetFuncDisplayName = $"{nameof(OverlayBackground)}.{nameof(DisplayDefaultBrush)}";
                    /// <summary></summary>
                    public const string SetFuncDisplayName = $"{nameof(OverlayBackground)}.{nameof(DisplayDefaultBrush)}";
                }
            }

            /// <summary></summary>
            static public class OverlayOutline
            {
                /// <summary></summary>
                static public class Display
                {
                    /// <summary></summary>
                    public const string PropertyName = $"{nameof(Display)}";
                    /// <summary></summary>
                    public const string GetFuncDisplayName = $"{nameof(OverlayOutline)}.{nameof(Display)}";
                    /// <summary></summary>
                    public const string SetFuncDisplayName = $"{nameof(OverlayOutline)}.{nameof(Display)}";
                }

                /// <summary></summary>
                static public class DisplayDefaultBrush
                {
                    /// <summary></summary>
                    public const string PropertyName = $"{nameof(DisplayDefaultBrush)}";
                    /// <summary></summary>
                    public const string GetFuncDisplayName = $"{nameof(OverlayOutline)}.{nameof(DisplayDefaultBrush)}";
                    /// <summary></summary>
                    public const string SetFuncDisplayName = $"{nameof(OverlayOutline)}.{nameof(DisplayDefaultBrush)}";
                }
            }
        }
    }
}
