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
            switch ((ApplicationWindowPageEnum)value)
            {
                case ApplicationWindowPageEnum.Application:
                    return new NavigationAndAppPage();
                case ApplicationWindowPageEnum.LoginAndRegPage:
                    return new LoginAndRegPage();
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
