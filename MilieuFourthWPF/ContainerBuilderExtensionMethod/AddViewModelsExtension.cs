using Autofac;

namespace MilieuFourthWPF
{
    public static class AddViewModelsExtension
    {
        public static ContainerBuilder AddViewModels(this ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationWindowViewModel>().SingleInstance();
            builder.RegisterType<SideNavigationMenuViewModel>().InstancePerLifetimeScope();

            return builder;
        }
    }
}
