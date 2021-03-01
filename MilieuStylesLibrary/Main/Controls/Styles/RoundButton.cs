
using System;
using System.Windows;
using System.Windows.Controls;

namespace MilieuStylesLibrary.Main
{
    public class RoundButton : Button
    {
        static RoundButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RoundButton), new FrameworkPropertyMetadata(typeof(RoundButton)));
        }
        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius",
            typeof(int),
            typeof(RoundButton),
            new UIPropertyMetadata(0),
            new ValidateValueCallback(ValidateCornerRadius));

        public static bool ValidateCornerRadius(object value)
        {
            return Convert.ToInt32(value) >= 0;
        }

    }
}
