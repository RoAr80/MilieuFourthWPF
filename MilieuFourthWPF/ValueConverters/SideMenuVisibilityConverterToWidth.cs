using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MilieuFourthWPF
{
    public class SideMenuVisibilityConverterToWidth : BaseValueConverter<SideMenuVisibilityConverterToWidth>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Visibility)value == Visibility.Visible)
                return "*";
            else
                return 0;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
