using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace SimpleOverlayTheme.Helpers
{
    public class DataGridRowHeaderHelper : APropertyHelper
    {
        ////////////////////////////////////////
        // HeaderWidth
        ////////////////////////////////////////

        /// <summary></summary>
        public static readonly DependencyProperty HeaderWidthProperty
            = GeneratorProperty("HeaderWidth",
                typeof(double), typeof(DataGridRowHeaderHelper), 20.0);

        /// <summary></summary>
        [Browsable(true)]
        [Category(nameof(DataGridRowHeaderHelper))]
        [DisplayName("HeaderWidth")]
        [AttachedPropertyBrowsableForType(typeof(DataGrid))]
        [AttachedPropertyBrowsableForType(typeof(DataGridRowHeader))]
        public static double GetHeaderWidth(UIElement element)
            => (double)element.GetValue(HeaderWidthProperty);

        /// <summary></summary>
        public static void SetHeaderWidth(UIElement element, double value)
            => element.SetValue(HeaderWidthProperty, value);
    }
}
