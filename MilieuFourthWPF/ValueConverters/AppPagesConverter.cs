using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Globalization;

namespace MilieuFourthWPF
{
    public class AppPagesConverter : BaseValueConverter<AppPagesConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page
            switch ((AppPageEnum)value)
            {
                case AppPageEnum.Home:
                    return new HomePage();
                case AppPageEnum.Cards:
                    return new CardsPage();
                case AppPageEnum.Stats:
                    return new StatsPage();
                case AppPageEnum.Settings:
                    return new SettingsPage();
                case AppPageEnum.Store:
                    return new StorePage();
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
