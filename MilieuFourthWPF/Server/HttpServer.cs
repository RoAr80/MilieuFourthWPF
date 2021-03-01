using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MilieuFourthWPF
{
    public class HttpServer
    {
        private readonly HttpListener _listener;

        private readonly string _prefix;

        private readonly string _serverRootDirectory;

        #region Constructor

        public HttpServer()
        {
            _listener = new HttpListener();
            
            _prefix = GetRandomUnusedLocalAddress();

            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            _serverRootDirectory = projectDirectory + "\\Server\\build";

            InitServer();
        }

        #endregion

        #region Server Methods

        private async Task InitServer()
        {
            AddListenersForAllInDir(_serverRootDirectory);

            await MakeResponseAsync();
        }

        private async Task MakeResponseAsync()
        {
            if (_listener.IsListening)
            {
                return;
            }

            _listener.Start();

            while (_listener.IsListening)
            {
                HttpListenerContext context = await _listener.GetContextAsync().ConfigureAwait(false);
                // Вроде как континюация
                try
                {
                    string url = context.Request.Url.ToString();

                    string filePath = _serverRootDirectory + "\\" + url.Replace(_prefix, "");
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        if (context == null) return;                        

                        fs.CopyTo(context.Response.OutputStream);
                    }


                }
                catch (Exception e)
                {
                    Trace.WriteLine("It is from catch " + e.Message);
                }
                finally
                {
                    if (context != null)
                    {
                        context.Response.OutputStream.Close();
                    }
                }
            }
            return;
        }

        private void CreateServerPaths()
        {            
            AddListenersForAllInDir(_serverRootDirectory);
            var showPrefixes = _listener.Prefixes;
        }

        private void AddListenersForAllInDir(string directory)
        {
            string[] files = Directory.GetFiles(directory);
            string[] directories = Directory.GetDirectories(directory);

            //if (files.Count() == 0 && dire)
            //    return;

            foreach(string file in files)
            {                
                string url = _prefix + Path.GetRelativePath(_serverRootDirectory, file).Replace("\\", "/") + "/";
                _listener.Prefixes.Add(url);
            }

            foreach(string dir in directories)
            {
                AddListenersForAllInDir(dir);
            }
        }
                

        #endregion

        #region Public Methods

        public string GetServerUrl()
        {
            return _prefix;
        }

        #endregion

        #region Methods for prefix

        private static string GetRandomUnusedLocalAddress()
        {
            /// <summary>
            /// Не знаю насколько хорош этот метод, но его использует Google.
            /// https://github.com/googlesamples/oauth-apps-for-windows/blob/a9c06c539adc21eab752537b234219c448356001/OAuthDesktopApp/OAuthDesktopApp/MainWindow.xaml.cs#L47
            /// </summary>
            /// <returns></returns>
            static string GetRandomUnusedPort()
            {
                var listener = new TcpListener(IPAddress.Loopback, 0);
                listener.Start();
                var port = ((IPEndPoint)listener.LocalEndpoint).Port;
                listener.Stop();
                return port.ToString();
            }

            var port = GetRandomUnusedPort();
            string localAddress = String.Format("http://localhost:{0}/", port);
            return localAddress;
        }

        
        

        #endregion
    }
}
