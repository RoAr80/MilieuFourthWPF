using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilieuFourthWPF
{
    public class ApplicationWindowUserControlConverter : BaseValueConverter<ApplicationWindowUserControlConverter>
    {
        
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            // Find the appropriate page
            switch (value)
            {
                case NavigationAndAppViewModel c:
                    return new NavigationAndAppPage(c);
                case LoginAndRegViewModel c:
                    return new LoginAndRegPage(c);
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }        
    }
}
