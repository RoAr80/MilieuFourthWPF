using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MilieuFourthWPF.Database.Repos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
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

        //ToDo: Плохо конечно, но что поделаешь
        private async void OnStartup(object sender, StartupEventArgs e)
        {            
            MainWindow mainWindow = DI.ServiceProvider.GetService<MainWindow>();            
            mainWindow.Show();

            var appVM = DI.ServiceProvider.GetService<ApplicationWindowViewModel>();
            await appVM.TryToAutoLoginAsync();

        }        
    }
}
