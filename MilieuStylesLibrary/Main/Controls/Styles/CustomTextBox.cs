using System.Windows;
using System.Windows.Controls;

namespace MilieuStylesLibrary.Main
{
    public class CustomTextBox : TextBox
    {
        static CustomTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomTextBox), new FrameworkPropertyMetadata(typeof(CustomTextBox)));
        }

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder",
            typeof(string),
            typeof(CustomTextBox),
            new UIPropertyMetadata(""),
            new ValidateValueCallback(ValidatePlaceholderProperty));

        public static bool ValidatePlaceholderProperty(object value)
        {            
            return true;
        }
    }
}
