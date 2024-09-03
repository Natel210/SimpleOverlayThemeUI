using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace GrayThemeUI.CustomControl
{
    public partial class NumericUpDown : Control
    {
        static NumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown),
                new FrameworkPropertyMetadata(typeof(NumericUpDown)));
        }

        private static readonly FrameworkPropertyMetadataOptions _frameworkPropertyMetadataOptions = FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure;

        public NumericUpDown()
        {
        }

        public static readonly DependencyProperty ValueProperty
            = DependencyProperty.Register(
                nameof(Value),
                typeof(double),
                typeof(NumericUpDown),
                new FrameworkPropertyMetadata(0.0, _frameworkPropertyMetadataOptions, ValuePropertyChanged));

        [Category("GrayThemeUI.NumericUpDown")]
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private static void ValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is NumericUpDown numericUpDown))
                return;
            numericUpDown.UpdateText();
        }

        public static readonly DependencyProperty IntervalProperty
            = DependencyProperty.Register(
                nameof(Interval),
                typeof(double),
                typeof(NumericUpDown),
                new FrameworkPropertyMetadata(1.0, _frameworkPropertyMetadataOptions));

        [Category("GrayThemeUI.NumericUpDown")]
        public double Interval
        {
            get { return (double)GetValue(IntervalProperty); }
            set { SetValue(IntervalProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty
            = DependencyProperty.Register(
                nameof(Minimum),
                typeof(double),
                typeof(NumericUpDown),
                new FrameworkPropertyMetadata(double.MinValue, _frameworkPropertyMetadataOptions));

        [Category("GrayThemeUI.NumericUpDown.Limit")]
        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty
            = DependencyProperty.Register(
                nameof(Maximum),
                typeof(double),
                typeof(NumericUpDown),
                new FrameworkPropertyMetadata(double.MaxValue, _frameworkPropertyMetadataOptions));

        [Category("GrayThemeUI.NumericUpDown.Limit")]
        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty UseIntegerProperty
            = DependencyProperty.Register(
                nameof(UseInteger),
                typeof(bool),
                typeof(NumericUpDown),
                new FrameworkPropertyMetadata(false, _frameworkPropertyMetadataOptions));

        [Category("GrayThemeUI.NumericUpDown.Limit")]
        public bool UseInteger
        {
            get { return (bool)GetValue(UseIntegerProperty); }
            set { SetValue(UseIntegerProperty, value); }
        }

        public static readonly DependencyProperty DecimalPlacesProperty
            = DependencyProperty.Register(
                "DecimalPlaces",
                typeof(int),
                typeof(NumericUpDown),
                new FrameworkPropertyMetadata(3, _frameworkPropertyMetadataOptions));

        [Category("GrayThemeUI.NumericUpDown.Limit")]
        [Description("Behavior when [UseInteger] is false")]
        public int DecimalPlaces
        {
            get { return (int)GetValue(DecimalPlacesProperty); }
            set { SetValue(DecimalPlacesProperty, value); }
        }



    }

    public partial class NumericUpDown
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //this.MouseWheel



            if (GetTemplateChild("increaseButton") is RepeatButton increaseButton)
            {
                increaseButton.Click += IncreaseButton_Click;
                increaseButton.PreviewMouseUp += IncreaseButton_PreviewMouseUp;
            }

            if (GetTemplateChild("decreaseButton") is RepeatButton decreaseButton)
            {
                decreaseButton.Click += DecreaseButton_Click;
                decreaseButton.PreviewMouseUp += IncreaseButton_PreviewMouseUp;
            }

            if (GetTemplateChild("valueTextBox") is TextBox valueTextBox)
            {
            }

            

        }


        private int _increasePusingCount = 0;
        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            ++_increasePusingCount;

            Value += (Interval * Math.Pow(10, _increasePusingCount / 10));
            if (Value > Maximum)
                Value = Maximum;
        }
        private void IncreaseButton_PreviewMouseUp(object sender, RoutedEventArgs e)
        {
            _increasePusingCount = 0;
        }

        private int _dncreasePusingCount = 0;
        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            ++_dncreasePusingCount;

            Value -= (Interval * Math.Pow(10, _increasePusingCount / 10));
            if (Value > Maximum)
                Value = Maximum;
        }
        private void DecreaseButton_PreviewMouseUp(object sender, RoutedEventArgs e)
        {
            _dncreasePusingCount = 0;
        }
    }


    public partial class NumericUpDown
    {


        private void UpdateText()
        {
            //if (UseInteger)
            //{
            //    int integerValue = Convert.ToInt32(Math.Round(Value));
            //    if (integerValue >= Maximum)
            //        integerValue = Convert.ToInt32(Maximum);
            //    if (integerValue <= Minimum)
            //        integerValue = Convert.ToInt32(Minimum);
            //    //textBox.Text = integerValue.ToString();
            //}
            //else
            //{
            //    double roundedValue = Math.Round(Value, DecimalPlaces);
            //    if (roundedValue >= Maximum)
            //        roundedValue = Maximum;
            //    if (roundedValue <= Minimum)
            //        roundedValue = Minimum;
            //    //textBox.Text = roundedValue.ToString();
            //}
        }
    }
}


