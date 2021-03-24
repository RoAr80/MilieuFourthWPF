using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Milieu.ClientModels.Database.Repos;
using Milieu.Relational.Database.Repos;
using System.Net.Http;

namespace MilieuFourthWPF
{
    public static class HostBuilderExtensionMethods
    {
        public static IHostBuilder AddConfiguration(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration(c =>
            {
                c.AddJsonFile("appsettings.json");
                c.AddEnvironmentVariables();
            });

            return host;
        }

        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                //Addsingleton
                services.AddSingleton<MainWindow>();
                services.AddSingleton<ApplicationWindowViewModel>();
                //services.AddSingleton<CardsPage>();
                services.AddSingleton<HttpClient>();

                services.AddSingleton<IViewModelAbstractFactory, ViewModelAbstractFactory>();
                services.AddSingleton<IViewModelFactory<LoginAndRegViewModel>, LoginAndRegViewModelFactory>();
                services.AddSingleton<IViewModelFactory<NavigationAndAppViewModel>, NavigationAndAppViewModelFactory>();
                //Addsingleton

                // ToDo: Должен ли он быть синглтон?
                services.AddSingleton<HttpServer>();
                services.AddScoped<IClientRepo, ClientRepository>();
            });

            return host;
        }
    }
}
