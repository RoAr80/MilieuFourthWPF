using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Milieu.ClientModels.Database.Repos;
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
            builder.RegisterType<MainWindow>().SingleInstance();
            builder.RegisterType<ApplicationWindowViewModel>().SingleInstance();
            builder.RegisterType<HttpClient>().SingleInstance();

            builder.RegisterType<ViewModelAbstractFactory>().As<IViewModelAbstractFactory>().SingleInstance();
            builder.RegisterType<LoginAndRegViewModelFactory>().As<IViewModelFactory<LoginAndRegViewModel>>().SingleInstance();
            builder.RegisterType<NavigationAndAppViewModelFactory>().As<IViewModelFactory<NavigationAndAppViewModel>>().SingleInstance();

            builder.RegisterType<HttpServer>().SingleInstance();
            builder.RegisterType<ClientRepository>().As<IClientRepo>().InstancePerLifetimeScope();

            container = builder.Build();
            
        }
        
        //ToDo: Плохо конечно, но что поделаешь
        private async void OnStartup(object sender, StartupEventArgs e)
        {
            //MainWindow mainWindow = _host.Services.GetService<MainWindow>();
            MainWindow mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();

            //var appVM = DI.ServiceProvider.GetService<ApplicationWindowViewModel>();
            //await appVM.TryToAutoLoginAsync();

        }        
    }
}
