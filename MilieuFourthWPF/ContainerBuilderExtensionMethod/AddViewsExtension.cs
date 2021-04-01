using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilieuFourthWPF
{
    public static class AddViewsExtension
    {
        public static ContainerBuilder AddViews(this ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>().SingleInstance();
            // ToDo: нужно ли для SideNavigation SingleInstance. Пересмотреть.
            builder.RegisterType<SideNavigationMenuControl>().SingleInstance();

            return builder;
        }
    }
}
