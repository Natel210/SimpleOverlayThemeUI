using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

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

        public static readonly DependencyProperty PlusImageBrushProperty
            = DependencyProperty.Register(
                nameof(PlusImageBrush),
                typeof(ImageBrush),
                typeof(NumericUpDown),
                new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));

        [Category("GrayThemeUI.NumericUpDown.Image")]
        public ImageBrush PlusImageBrush
        {
            get { return (ImageBrush)GetValue(PlusImageBrushProperty); }
            set { SetValue(PlusImageBrushProperty, value); }
        }

        public static readonly DependencyProperty MinusImageBrushProperty
            = DependencyProperty.Register(
                nameof(MinusImageBrush),
                typeof(ImageBrush),
                typeof(NumericUpDown),
                new FrameworkPropertyMetadata(null, _frameworkPropertyMetadataOptions));

        [Category("GrayThemeUI.NumericUpDown.Image")]
        public ImageBrush MinusImageBrush
        {
            get { return (ImageBrush)GetValue(MinusImageBrushProperty); }
            set { SetValue(MinusImageBrushProperty, value); }
        }

    }

    public partial class NumericUpDown
    {

        /// <summary>
        /// Based on [Increase/Decrease's PushingCount],
        /// the index increases for each specific number of counts.
        /// </summary>
        private readonly int _exponentialLevelUpCount = 50;
        private readonly int _exponentialMaxLevel = 5;
        private int _increasePushingCount = 0;
        private int _decreasePushingCount = 0;

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
                decreaseButton.PreviewMouseUp += DecreaseButton_PreviewMouseUp;
            }
            
            if (GetTemplateChild("valueTextBox") is TextBox valueTextBox)
            {
                valueTextBox.MouseWheel += ValueTextBox_MouseWheel;
                valueTextBox.LostFocus += ValueTextBox_LostFocus;
                valueTextBox.TextChanged += ValueTextBox_TextChanged;
            }

            

        }


        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            ++_increasePushingCount;
            double currentExponentialLevel = Convert.ToDouble(_increasePushingCount / _exponentialLevelUpCount);
            if (_exponentialMaxLevel < currentExponentialLevel)
                currentExponentialLevel = _exponentialMaxLevel;
            Value += (Interval * Convert.ToInt32(Math.Pow(10.0, currentExponentialLevel)));
            if (Value > Maximum)
                Value = Maximum;
        }
        private void IncreaseButton_PreviewMouseUp(object sender, RoutedEventArgs e)
        {
            _increasePushingCount = 0;
        }
        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            ++_decreasePushingCount;
            double currentExponentialLevel = Convert.ToDouble(_decreasePushingCount / _exponentialLevelUpCount);
            if (_exponentialMaxLevel < currentExponentialLevel)
                currentExponentialLevel = _exponentialMaxLevel;
            Value -= (Interval * Convert.ToInt32(Math.Pow(10.0, currentExponentialLevel)));
            if (Value < Minimum)
                Value = Minimum;
        }
        private void DecreaseButton_PreviewMouseUp(object sender, RoutedEventArgs e)
        {
            _decreasePushingCount = 0;
        }
        private void ValueTextBox_MouseWheel(object sender, RoutedEventArgs e)
        {

        }
        private void ValueTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is null)
                return;
            TextBox? valueTextBox = sender as TextBox;
            if (valueTextBox is null)
                return;
            int curCursor = valueTextBox.SelectionStart; // save current cursor pos.

            if (double.TryParse(valueTextBox.Text, out double newValue))
            {
                if (UseInteger)
                    newValue = Math.Round(newValue);
                else
                    newValue = Math.Round(newValue, DecimalPlaces);

                if (newValue != Value)
                    Value = newValue;
            }
            if (Value > Maximum)
                Value = Maximum;
            else if (Value < Minimum)
                Value = Minimum;
            UpdateText(); // update text.
            curCursor = Math.Min(curCursor, valueTextBox.Text.Length);
            valueTextBox.SelectionStart = curCursor; // recovery cursor pos.
        }
        private void ValueTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            // Limit Increase Button
            if (GetTemplateChild("increaseButton") is RepeatButton increaseButton)
            {
                if (Value >= Maximum)
                    increaseButton.IsEnabled = false;
                else
                    increaseButton.IsEnabled = true;
            }
            // Limit Decrease Button
            if (GetTemplateChild("decreaseButton") is RepeatButton decreaseButton)
            {
                if (Value <= Minimum)
                    decreaseButton.IsEnabled = false;
                else
                    decreaseButton.IsEnabled = true;
            }
        }
    }


    public partial class NumericUpDown
    {


        private void UpdateText()
        {
            var valueTextBox = GetTemplateChild("valueTextBox") as TextBox;
            if (valueTextBox is null)
                return;
            
            if (UseInteger)
            {
                int integerValue = Convert.ToInt32(Math.Round(Value));
                if (integerValue >= Maximum)
                    integerValue = Convert.ToInt32(Maximum);
                if (integerValue <= Minimum)
                    integerValue = Convert.ToInt32(Minimum);
                valueTextBox.Text = integerValue.ToString();
            }
            else
            {
                double roundedValue = Math.Round(Value, DecimalPlaces);
                if (roundedValue >= Maximum)
                    roundedValue = Maximum;
                if (roundedValue <= Minimum)
                    roundedValue = Minimum;
                valueTextBox.Text = roundedValue.ToString();
            }
        }
    }
}


