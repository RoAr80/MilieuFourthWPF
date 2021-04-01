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
        private IContainer _container;

        private readonly IHost _host;

        public App()
        {
            Configuration = CreateConfiguration().Build();
            _container = CreateContainerBuilder().Build();
        }

        public IConfigurationBuilder CreateConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder;
        }

        public ContainerBuilder CreateContainerBuilder()
        {
            return new ContainerBuilder()
                .AddLocalDbContext(Configuration)
                .AddModels()
                .AddViews()
                .AddViewModels()
                .AddViewModelsFactories()
                .AddServices()
                .AddHttpLocalServer()
                .AddRepos();
        }
        
        //ToDo: Плохо конечно, но что поделаешь
        private async void OnStartup(object sender, StartupEventArgs e)
        {            
            MainWindow mainWindow = _container.Resolve<MainWindow>();
            mainWindow.Show();

            //var appVM = DI.ServiceProvider.GetService<ApplicationWindowViewModel>();
            //await appVM.TryToAutoLoginAsync();

        }        
    }
}
