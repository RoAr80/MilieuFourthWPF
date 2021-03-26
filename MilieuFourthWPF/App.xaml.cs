using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Milieu.ClientModels.ClientSide.SideNavigationMenuModel;
using Milieu.ClientModels.Database.Repos;
using Milieu.Relational.Database;
using Milieu.Relational.Database.Repos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MilieuFourthWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {        
        public IConfiguration Configuration { get; private set; }
        private IContainer container;

        private readonly IHost _host;

        public App()
        {            
            var builder = new ContainerBuilder();

            // Add DbContext
            builder.Register(c =>
            {
                var opt = new DbContextOptionsBuilder<ClientDbContext>();
                opt.UseSqlite("Data Source=MilieuClientData.db");

                return new ClientDbContext(opt.Options);
            }).AsSelf();


            // Models
            builder.RegisterType<SideNavigationMenuModel>().InstancePerLifetimeScope();
            

            // Views
            builder.RegisterType<MainWindow>().SingleInstance();
            builder.RegisterType<SideNavigationMenuControl>().SingleInstance();

            // ViewModels
            builder.RegisterType<ApplicationWindowViewModel>().SingleInstance();
            builder.RegisterType<SideNavigationMenuViewModel>().SingleInstance();
            builder.RegisterType<HomeViewModel>().SingleInstance();

            // Services
            builder.RegisterType<HttpClient>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();

            // ViewModels Factories
            builder.RegisterType<ViewModelAbstractFactory>().As<IViewModelAbstractFactory>().SingleInstance();
            builder.RegisterType<LoginAndRegViewModelFactory>().As<IViewModelFactory<LoginAndRegViewModel>>().SingleInstance();
            builder.RegisterType<SideNavigationMenuViewModelFactory>().As<IViewModelFactory<SideNavigationMenuViewModel>>().SingleInstance();
            builder.RegisterType<HomeViewModelFactory>().As<IViewModelFactory<HomeViewModel>>().SingleInstance();


            builder.RegisterType<HttpServer>().SingleInstance();

            // Repos
            builder.RegisterType<ClientRepository>().As<IClientRepo>().InstancePerLifetimeScope();

            container = builder.Build();
            
        }
        
        //ToDo: Плохо конечно, но что поделаешь
        private async void OnStartup(object sender, StartupEventArgs e)
        {            
            MainWindow mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();

            //var appVM = DI.ServiceProvider.GetService<ApplicationWindowViewModel>();
            //await appVM.TryToAutoLoginAsync();

        }        
    }
}
