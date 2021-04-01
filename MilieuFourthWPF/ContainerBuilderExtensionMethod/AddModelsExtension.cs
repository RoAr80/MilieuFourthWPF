using Autofac;
using Milieu.ClientModels;
using Milieu.ClientModels.ClientSide.SideNavigationMenuModel;
using Milieu.ClientModels.Registration;

namespace MilieuFourthWPF
{
    public static class AddModelsExtension
    {
        public static ContainerBuilder AddModels(this ContainerBuilder builder)
        {
            builder.RegisterType<SideNavigationMenuModel>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationModel>().SingleInstance();
            builder.RegisterType<RegistrationModel>().SingleInstance();

            return builder;
        }
    }
}
