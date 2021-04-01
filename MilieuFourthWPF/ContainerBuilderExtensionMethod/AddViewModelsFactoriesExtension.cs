using Autofac;

namespace MilieuFourthWPF
{
    public static class AddViewModelsFactoriesExtension
    {
        public static ContainerBuilder AddViewModelsFactories(this ContainerBuilder builder)
        {
            builder.RegisterType<ViewModelAbstractFactory>().As<IViewModelAbstractFactory>().SingleInstance();
            builder.RegisterType<LoginAndRegViewModelFactory>().As<IViewModelFactory<LoginAndRegViewModel>>().SingleInstance();
            builder.RegisterType<SideNavigationMenuViewModelFactory>().As<IViewModelFactory<SideNavigationMenuViewModel>>().SingleInstance();
            builder.RegisterType<HomeViewModelFactory>().As<IViewModelFactory<HomeViewModel>>().SingleInstance();            

            return builder;
        }
    }
}
