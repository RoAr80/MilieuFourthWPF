using System;
using System.Diagnostics;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;


namespace MilieuFourthWPF
{
    /// <summary>
    /// Interaction logic for CardsPage.xaml
    /// </summary>
    public partial class CardsPage : UserControl
    {
        public CardsPage()
        {
            InitializeComponent();
            //HttpServer httpServer = DI.ServiceProvider.GetService<HttpServer>();
            // ToDo: попробовать решить bindingom
            //string uri = httpServer.GetServerUrl();
            //Trace.WriteLine(uri);
            //webView.Source = new Uri(uri + "index.html");
        }
    }
}
