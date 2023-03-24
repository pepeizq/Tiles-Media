using Microsoft.UI.Xaml;
using System;
using Windows.System;

namespace Tiles_Media
{
    public partial class App : Application
    {
        private Window m_window;

        public App()
        {
            this.InitializeComponent();
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            bool abrirApp = false;
            string[] argumentos = Environment.GetCommandLineArgs();

            if (argumentos.Length > 1)
            {
                abrirApp = false;
            }
            else
            {
                abrirApp = true;
            }

            if (abrirApp == true)
            {
                m_window = new MainWindow();
                m_window.Activate();
            }
            else
            {
                await Launcher.LaunchUriAsync(new Uri(argumentos[1]));

                Application app = Application.Current;
                app.Exit();
            }
        } 
    }
}
