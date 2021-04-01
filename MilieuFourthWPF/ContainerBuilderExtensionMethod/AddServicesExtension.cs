using Autofac;
using Milieu.ClientModels.Web;
using System.Net.Http;

namespace MilieuFourthWPF
{
    public static class AddServicesExtension
    {
        public static ContainerBuilder AddServices(this ContainerBuilder builder)
        {
            // Services
            builder.RegisterType<HttpClient>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<WebRequestsService>().As<IWebRequestsService>().SingleInstance();

            return builder;
        }
    }
}
