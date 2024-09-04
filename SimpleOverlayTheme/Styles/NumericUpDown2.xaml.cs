using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GrayThemeUI
{
    public partial class NumericUpDown : UserControl
    {
        public NumericUpDown()
        {
            InitializeComponent();
            // Initialize Foreground with the resource value if not already set
            if (Foreground == null)
            {
                var brush = TryFindResource("GrayThemeUI.Theme.Foreground") as Brush;
                if (brush != null)
                {
                    Foreground = brush;
                }
            }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(NumericUpDown), new PropertyMetadata(0.0, ValuePropertyChanged));

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

        public static readonly DependencyProperty IntervalProperty =
            DependencyProperty.Register("Interval", typeof(double), typeof(NumericUpDown), new PropertyMetadata(1.0));

        public double Interval
        {
            get { return (double)GetValue(IntervalProperty); }
            set { SetValue(IntervalProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(double), typeof(NumericUpDown), new PropertyMetadata(double.MinValue));

        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(NumericUpDown), new PropertyMetadata(double.MaxValue));

        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty UseIntegerProperty =
            DependencyProperty.Register("UseInteger", typeof(bool), typeof(NumericUpDown), new PropertyMetadata(false));

        public bool UseInteger
        {
            get { return (bool)GetValue(UseIntegerProperty); }
            set { SetValue(UseIntegerProperty, value); }
        }

        public static readonly DependencyProperty DecimalPlacesProperty =
            DependencyProperty.Register("DecimalPlaces", typeof(int), typeof(NumericUpDown), new PropertyMetadata(3));

        public int DecimalPlaces
        {
            get { return (int)GetValue(DecimalPlacesProperty); }
            set { SetValue(DecimalPlacesProperty, value); }
        }

        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            Value += Interval;
            if (Value > Maximum)
                Value = Maximum;
        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            Value -= Interval;
            if (Value < Minimum)
                Value = Minimum;
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is null)
                return;
            TextBox? tb = sender as TextBox;
            if (tb is null)
                return;
            int curCursor = tb.SelectionStart; // save current cursor pos.

            if (double.TryParse(textBox.Text, out double newValue))
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
            curCursor = Math.Min(curCursor, tb.Text.Length);
            tb.SelectionStart = curCursor; // recovery cursor pos.
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Value >= Maximum)
                increaseButton.IsEnabled = false;
            else
                increaseButton.IsEnabled = true;

            if (Value <= Minimum)
                decreaseButton.IsEnabled = false;
            else
                decreaseButton.IsEnabled = true;
        }

        private void UpdateText()
        {
            if (UseInteger)
            {
                int integerValue = Convert.ToInt32(Math.Round(Value));
                if (integerValue >= Maximum)
                    integerValue = Convert.ToInt32(Maximum);
                if (integerValue <= Minimum)
                    integerValue = Convert.ToInt32(Minimum);
                textBox.Text = integerValue.ToString();
            }
            else
            {
                double roundedValue = Math.Round(Value, DecimalPlaces);
                if (roundedValue >= Maximum)
                    roundedValue = Maximum;
                if (roundedValue <= Minimum)
                    roundedValue = Minimum;
                textBox.Text = roundedValue.ToString();
            }
        }
    }
}