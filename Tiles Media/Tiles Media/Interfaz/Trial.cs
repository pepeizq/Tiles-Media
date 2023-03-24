using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Services.Store;
using Windows.System;
using static Tiles_Media.MainWindow;

namespace Interfaz
{
    public static class Trial
    {
        public static async void Cargar()
        {
            if (await Detectar() == true)
            {
                Objetos.botonPresentacionTrialComprar.Click += BotonAbrirCompra;
                Objetos.botonPresentacionTrialComprar.PointerEntered += Animaciones.EntraRatonBoton2;
                Objetos.botonPresentacionTrialComprar.PointerExited += Animaciones.SaleRatonBoton2;

                Objetos.spPresentacionTrial.Visibility = Visibility.Visible;
            }
            else
            {
                Objetos.spPresentacionTrial.Visibility = Visibility.Collapsed;
            }  
        }

        public static async Task<bool> Detectar()
        {
            bool enTrial = false;

            IReadOnlyList<User> usuarios = await User.FindAllAsync();

            if (usuarios != null)
            {
                if (usuarios.Count > 0)
                {
                    User usuario = usuarios[0];
                    StoreContext contexto = StoreContext.GetForUser(usuario);
                    StoreAppLicense licencia = await contexto.GetAppLicenseAsync();

                    if (licencia.IsActive == true && licencia.IsTrial == false)
                    {
                        enTrial = false;           
                    }
                    else
                    {
                        enTrial = true;
                    }           
                }
            }

            return enTrial;
        }

        public static async void BotonAbrirCompra(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("ms-windows-store://pdp/?ProductId=" + AppDatos.IDTienda));
        }
    }
}
