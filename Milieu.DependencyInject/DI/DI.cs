using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milieu.DependencyInject.DI
{
    public static class DI
    {
        public static IServiceProvider ServiceProvider { get; }
        //Не знаю насколько это плохо
        public static IConfiguration Configuration { get; }

        static DI()
        {
            ServiceCollection services = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<ClientDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("ClientDataBaseConnection"));
                //options.UseSqlite("Data Source=MilieuClientData.db");
            });
            //Addsingleton
            services.AddSingleton<MainWindow>();
            services.AddSingleton<ApplicationWindowViewModel>();
            services.AddSingleton<HttpClient>();
            services.AddSingleton<CardsPage>();
            //Addsingleton


            services.AddScoped<HttpServer>();
            services.AddScoped<IClientRepo, ClientRepository>();

            //services.AddScoped<NavigationAndAppViewModel>();
        }

    }
}
