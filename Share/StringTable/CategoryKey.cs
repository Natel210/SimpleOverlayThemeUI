namespace SimpleOverlayTheme.Share.StringTable
{
    static internal class CategoryKey
    {
        internal const string App = "SimpleOverlayTheme";

        static internal class Overlay
        {
            internal const string This = $"{nameof(Overlay)}.{nameof(This)}";
            internal const string Mask = $"{nameof(Overlay)}.{nameof(Mask)}";
            internal const string Border = $"{nameof(Overlay)}.{nameof(Border)}";

            static internal class Background
            {
                internal const string This = $"{nameof(Overlay)}.{nameof(Background)}.{nameof(This)}";
                internal const string Checked = $"{nameof(Overlay)}.{nameof(Background)}.{nameof(Checked)}";
            }

        }


        
    }
}
