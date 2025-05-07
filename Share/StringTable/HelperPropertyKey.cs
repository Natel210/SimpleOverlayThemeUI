using System.Windows.Controls.Primitives;

namespace SimpleOverlayTheme.Share.StringTable
{
    static public class HelperPropertyKey
    {
        public const string CategoryName = $"SimpleOverlayTheme";

        static public class Common
        {
            public const string CategoryName = $"{HelperPropertyKey.CategoryName}.{nameof(Common)}";

            static public class State
            {
                public const string PropertyName = $"{nameof(State)}";
                public const string DisplayName = $"{nameof(State)}";
            }

            static public class Mask
            {
                static public class DefaultImage
                {
                    public const string PropertyName = $"{nameof(DefaultImage)}";
                    public const string DisplayName = $"{nameof(Mask)}.{nameof(DefaultImage)}";
                }

                static public class UseCustomImage
                {
                    static public class Active
                    {
                        public const string PropertyName = $"{nameof(UseCustomImage)}{nameof(Active)}";
                        public const string DisplayName = $"{nameof(Mask)}.{nameof(UseCustomImage)}.{nameof(Active)}";
                    }
                    static public class Disable
                    {
                        public const string PropertyName = $"{nameof(UseCustomImage)}{nameof(Disable)}";
                        public const string DisplayName = $"{nameof(Mask)}.{nameof(UseCustomImage)}.{nameof(Disable)}";
                    }
                    static public class MouseOver
                    {
                        public const string PropertyName = $"{nameof(UseCustomImage)}{nameof(MouseOver)}";
                        public const string DisplayName = $"{nameof(Mask)}.{nameof(UseCustomImage)}.{nameof(MouseOver)}";
                    }
                }

                static public class CustomImage
                {
                    static public class Active
                    {
                        public const string PropertyName = $"{nameof(CustomImage)}{nameof(Active)}";
                        public const string DisplayName = $"{nameof(Mask)}.{nameof(CustomImage)}.{nameof(Active)}";
                    }
                    static public class Disable
                    {
                        public const string PropertyName = $"{nameof(CustomImage)}{nameof(Disable)}";
                        public const string DisplayName = $"{nameof(Mask)}.{nameof(CustomImage)}.{nameof(Disable)}";
                    }
                    static public class MouseOver
                    {
                        public const string PropertyName = $"{nameof(CustomImage)}{nameof(MouseOver)}";
                        public const string DisplayName = $"{nameof(Mask)}.{nameof(CustomImage)}.{nameof(MouseOver)}";
                    }
                }
            }
        }

        static public class Button
        {
            public const string CategoryName = $"{HelperPropertyKey.CategoryName}.{nameof(Button)}";

            static public class Mask
            {
                static public class FollowMode
                {
                    public const string PropertyName = $"{nameof(FollowMode)}";
                    public const string DisplayName = $"{nameof(Button)}.{nameof(Mask)}.{nameof(FollowMode)}";
                }
            }

            static public class Border
            {
                static public class CornerRadius
                {
                    public const string PropertyName = $"{nameof(CornerRadius)}";
                    public const string DisplayName = $"{nameof(Button)}.{nameof(Border)}.{nameof(CornerRadius)}";
                }
            }
        }

        static public class Overlay
        {
            public const string CategoryName = $"{HelperPropertyKey.CategoryName}.{nameof(Overlay)}";
            static public class Display
            {
                static public class Background
                {
                    public const string PropertyName = $"{nameof(Display)}{nameof(Background)}";
                    public const string DisplayName = $"{nameof(Display)}.{nameof(Background)}";
                }
                static public class Outline
                {
                    public const string PropertyName = $"{nameof(Display)}{nameof(Outline)}";
                    public const string DisplayName = $"{nameof(Display)}.{nameof(Outline)}";
                }
                static public class DefaultBackground
                {
                    public const string PropertyName = $"{nameof(Display)}{nameof(DefaultBackground)}";
                    public const string DisplayName = $"{nameof(Display)}.{nameof(DefaultBackground)}";
                }
                static public class DefaultOutline
                {
                    public const string PropertyName = $"{nameof(Display)}{nameof(DefaultOutline)}";
                    public const string DisplayName = $"{nameof(Display)}.{nameof(DefaultOutline)}";
                }
            }


        }
    }
}
