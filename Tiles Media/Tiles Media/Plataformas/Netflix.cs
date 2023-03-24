using CommunityToolkit.WinUI.UI.Controls;
using Herramientas;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.Windows.ApplicationModel.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System;
using Windows.UI;
using static Tiles_Media.MainWindow;

namespace Plataformas
{
    public static class Netflix
    {
        public static void Cargar()
        {
            Objetos.botonNetflixBuscar.Click += BuscarClick;
            Objetos.botonNetflixBuscar.PointerEntered += Animaciones.EntraRatonBoton2;
            Objetos.botonNetflixBuscar.PointerExited += Animaciones.SaleRatonBoton2;

            Objetos.tbNetflixBuscar.KeyDown += BuscarPulsar;

            Objetos.cbOpcionesNetflixModo.SelectionChanged += CambiarModoEjecucion;
            Objetos.cbOpcionesNetflixModo.PointerEntered += Animaciones.EntraRatonComboCaja2;
            Objetos.cbOpcionesNetflixModo.PointerExited += Animaciones.SaleRatonComboCaja2;

            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
           
            if (datos.Values["OpcionesNetflixModo"] != null)
            {
                if ((int)datos.Values["OpcionesNetflixModo"] == -1)
                {
                    Objetos.cbOpcionesNetflixModo.SelectedIndex = 0;
                }
                else
                {
                    Objetos.cbOpcionesNetflixModo.SelectedIndex = (int)datos.Values["OpcionesNetflixModo"];
                }
            }
            else
            {
                Objetos.cbOpcionesNetflixModo.SelectedIndex = 0;
            }

            if (datos.Values["OpcionesNetflixAPIID"] == null)
            {
                Objetos.tbOpcionesNetflixAPIID.Text = "AIzaSyC2mAim7jYXCR8ePfx59BdwU8zCTTNaURs";
                datos.Values["OpcionesNetflixAPIID"] = Objetos.tbOpcionesNetflixAPIID.Text;
            }
            else
            {
                Objetos.tbOpcionesNetflixAPIID.Text = datos.Values["OpcionesNetflixAPIID"].ToString();
            }

            Objetos.tbOpcionesNetflixAPIID.TextChanged += DetectarAPIID;

            if (datos.Values["OpcionesNetflixSearchID"] == null)
            {
                Objetos.tbOpcionesNetflixSearchID.Text = "e6760ff33b21c479a";
                datos.Values["OpcionesNetflixSearchID"] = Objetos.tbOpcionesNetflixSearchID.Text;
            }
            else
            {
                Objetos.tbOpcionesNetflixSearchID.Text = datos.Values["OpcionesNetflixSearchID"].ToString();
            }

            Objetos.tbOpcionesNetflixSearchID.TextChanged += DetectarSearchID;

            Objetos.botonOpcionesNetflixAPIAyuda.Click += AbrirAyudaClick;
            Objetos.botonOpcionesNetflixAPIAyuda.PointerEntered += Animaciones.EntraRatonBoton2;
            Objetos.botonOpcionesNetflixAPIAyuda.PointerExited += Animaciones.SaleRatonBoton2;
        }

        private static void CambiarModoEjecucion(object sender, SelectionChangedEventArgs e)
        {
            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
            datos.Values["OpcionesNetflixModo"] = Objetos.cbOpcionesNetflixModo.SelectedIndex;
        }

        private static async void AbrirAyudaClick(object sender, RoutedEventArgs e)
        {
            ResourceLoader recursos = new ResourceLoader();

            TabView tb = new TabView
            {
                IsAddTabButtonVisible = false
            };

            ImageEx imagen1 = new ImageEx
            {
                Source = "Assets\\Ayuda\\google1.png",
                IsCacheEnabled = true,
                EnableLazyLoading = true,
                CornerRadius = new CornerRadius(5)
            };

            TabViewItem item1 = new TabViewItem
            {
                Header = recursos.GetString("APIID"),
                Content = imagen1,
                IsClosable = false
            };

            tb.TabItems.Add(item1);

            ImageEx imagen2 = new ImageEx
            {
                Source = "Assets\\Ayuda\\google2.png",
                IsCacheEnabled = true,
                EnableLazyLoading = true,
                CornerRadius = new CornerRadius(5)
            };

            TabViewItem item2 = new TabViewItem
            {
                Header = recursos.GetString("SearchID"),
                Content = imagen2,
                IsClosable = false
            };

            tb.TabItems.Add(item2);

            ContentDialog ventana = new ContentDialog
            {
                RequestedTheme = ElementTheme.Dark,
                PrimaryButtonText = recursos.GetString("APIIDOpen"),
                SecondaryButtonText = recursos.GetString("SearchIDOpen"),
                CloseButtonText = recursos.GetString("Close"),
                Content = tb,
                XamlRoot = Objetos.ventana.Content.XamlRoot
            };

            ventana.PrimaryButtonClick += AbrirEnlace1;
            ventana.SecondaryButtonClick += AbrirEnlace2;

            await ventana.ShowAsync();
        }

        private static async void AbrirEnlace1(ContentDialog ventana, ContentDialogButtonClickEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://developers.google.com/custom-search/v1/introduction?hl=es-419"));
        }

        private static async void AbrirEnlace2(ContentDialog ventana, ContentDialogButtonClickEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://programmablesearchengine.google.com/controlpanel/all"));
        }

        private static void DetectarAPIID(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb.Text.Trim().Length > 0)
            {
                ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
                datos.Values["OpcionesNetflixAPIID"] = tb.Text;
            }
        }

        private static void DetectarSearchID(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb.Text.Trim().Length > 0)
            {
                ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
                datos.Values["OpcionesNetflixSearchID"] = tb.Text;
            }
        }

        private static void BuscarClick(object sender, RoutedEventArgs e)
        {
            Buscar();
        }

        private static void BuscarPulsar(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                Buscar();
            }
        }

        private async static void Buscar()
        {
            if (Objetos.tbNetflixBuscar.Text.Trim().Length > 3)
            {
                ActivarDesactivar(false);
                Objetos.prNetflixResultados.Visibility = Visibility.Visible;

                ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
                Objetos.gvNetflixResultados.Items.Clear();

                await Task.Delay(100);
                List<string> resultados = Google.Buscar(Objetos.tbNetflixBuscar.Text.Trim(), datos.Values["OpcionesNetflixAPIID"].ToString(), datos.Values["OpcionesNetflixSearchID"].ToString(), "netflix");

                if (resultados.Count > 0)
                {
                    foreach (string resultado in resultados)
                    {
                        if (resultado.Contains("netflix.com/title/") == true)
                        {
                            NetflixClase streaming = new NetflixClase();

                            string id = resultado;
                            id = id.Replace("https://www.netflix.com/title/", null);

                            string htmlAPI = await Decompiladores.CogerHtml("https://unogs.com/api/title/detail?netflixid=" + id);

                            if (htmlAPI != null)
                            {
                                List<NetflixAPIDatos> json = JsonConvert.DeserializeObject<List<NetflixAPIDatos>>(htmlAPI);

                                if (json != null)
                                {
                                    if (json.Count > 0)
                                    {
                                        streaming.nombre = json[0].titulo;

                                        string htmlAPI2 = await Decompiladores.CogerHtml("https://unogs.com/api/title/bgimages?netflixid=" + id);

                                        NetflixAPIImagenes json2 = JsonConvert.DeserializeObject<NetflixAPIImagenes>(htmlAPI2);

                                        if (json2 != null)
                                        {
                                            if (json2.imagenesAnchas != null && json2.imagenesVerticales != null)
                                            {
                                                streaming.imagenPequeña = json2.imagenesAnchas[0].enlace;
                                                streaming.imagenMedianayGrande = json2.imagenesVerticales[0].enlace;

                                                if ((int)datos.Values["OpcionesNetflixModo"] == 0)
                                                {
                                                    streaming.enlace = resultado;
                                                }
                                                else if ((int)datos.Values["OpcionesNetflixModo"] == 1)
                                                {
                                                    streaming.enlace = "netflix:/app?playVideoId=" + id;
                                                }

                                                ImageEx imagen = new ImageEx
                                                {
                                                    IsCacheEnabled = true,
                                                    EnableLazyLoading = true,
                                                    Stretch = Stretch.UniformToFill,
                                                    Source = streaming.imagenMedianayGrande,
                                                    CornerRadius = new CornerRadius(2)
                                                };

                                                Button2 botonItem = new Button2
                                                {
                                                    Content = imagen,
                                                    Margin = new Thickness(0),
                                                    Padding = new Thickness(0),
                                                    BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]),
                                                    BorderThickness = new Thickness(2),
                                                    Tag = streaming,
                                                    MaxWidth = 250,
                                                    CornerRadius = new CornerRadius(5)
                                                };

                                                botonItem.Click += ImagenItemClick;
                                                botonItem.PointerEntered += Animaciones.EntraRatonBoton2;
                                                botonItem.PointerExited += Animaciones.SaleRatonBoton2;

                                                TextBlock tbTt = new TextBlock
                                                {
                                                    Text = streaming.nombre
                                                };

                                                ToolTipService.SetToolTip(botonItem, tbTt);
                                                ToolTipService.SetPlacement(botonItem, PlacementMode.Bottom);

                                                GridViewItem item = new GridViewItem
                                                {
                                                    Content = botonItem,
                                                    Margin = new Thickness(5, 0, 5, 10)
                                                };

                                                Objetos.gvNetflixResultados.Items.Add(item);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                ActivarDesactivar(true);
                Objetos.prNetflixResultados.Visibility = Visibility.Collapsed;
            }
        }

        private static void ImagenItemClick(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            NetflixClase streaming = boton.Tag as NetflixClase;
            Random azar = new Random();

            Tiles.PrecargarMedia(streaming.nombre,
                    streaming.enlace, "netflix" + azar.Next(10000).ToString(),
                    streaming.imagenPequeña,
                    streaming.imagenMedianayGrande);
        }

        private static void ActivarDesactivar(bool estado)
        {
            Objetos.botonNetflixBuscar.IsEnabled = estado;
            Objetos.tbNetflixBuscar.IsEnabled = estado;
            Objetos.cbOpcionesNetflixModo.IsEnabled = estado;
        }
    }

    public class NetflixClase
    {
        public string nombre { get; set; }
        public string imagenPequeña { get; set; }
        public string imagenMedianayGrande { get; set; }
        public string enlace { get; set; }
    }
}
